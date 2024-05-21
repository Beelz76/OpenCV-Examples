using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.OCR;
using System.Text.RegularExpressions;
using Emgu.CV.UI;
using System.Threading;


namespace MegaLABS
{
    public partial class Form1 : Form
    {
        private Image<Bgr, byte> _mainImg = null; //Основная картинка
        private VideoCapture _capture; //Для захвата видео

        public Form1()
        {
            InitializeComponent();

            StartDisplay();
            DefaultValues();
        }

        //Загрузка изображения
        private void LoadImage(Image<Bgr, byte> img)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Формат(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    img = new Image<Bgr, byte>(ofd.FileName);
                    _mainImg = img;
                    imageBox1.Image = img.Resize(400, 360, Inter.Linear);
                }
                else
                {
                    MessageBox.Show("Файл не выбран!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Загрузка видео
        private void LoadVideo(VideoCapture video)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Формат(*.mp4, *.avi, *.wmv, *.gif) | *.mp4; *.avi; *.wmv; *,gif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _capture = new VideoCapture(ofd.FileName);
                    _capture.ImageGrabbed += ProcessFrameVideo;
                }
                else
                {
                    MessageBox.Show("Файл не выбран!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadButton1_Click_1(object sender, EventArgs e)
        {
            LoadImage(_mainImg);
        }

        private void loadButton2_Click(object sender, EventArgs e)
        {
            resetButton.Visible = true;
            startButton.Visible = true;
            stopButton.Visible = true;
            contoursButtonFaces.Visible = false;
            contoursButtonText.Visible = false;
            textBox1.Visible = false;
            LoadVideo(_capture);
            _capture.Start();
        }

        //Распознавание символов
        public StringBuilder CharacterRecognition(Image<Bgr, byte> img, VectorOfVectorOfPoint contours)
        {
            var strBuilder = new StringBuilder();

            for (int i = 0; i < contours.Size; i++)
            {
                if (CvInvoke.ContourArea(contours[i], false) > 50)
                {
                    Rectangle rectangle = CvInvoke.BoundingRectangle(contours[i]);
                    img.ROI = rectangle;

                    Image<Bgr, byte> roiImg;
                    roiImg = img.Clone();
                    img.ROI = Rectangle.Empty;

                    var _ocr = new Tesseract("D:\\tessdata-main", "eng", OcrEngineMode.TesseractLstmCombined);
                    _ocr.SetImage(roiImg);
                    _ocr.Recognize();

                    Tesseract.Character[] words = _ocr.GetCharacters();

                    for (; i < words.Length; i++)
                    {
                        strBuilder.Append(words[i].Text);
                    }
                }
            }

            return strBuilder;
        }

        //Выделение участков текста
        private Image<Bgr, byte> ContoursText(Image<Bgr, byte> img)
        {
            var grayImg = img.Clone().Convert<Gray, byte>();
            grayImg._ThresholdBinaryInv(new Gray(128), new Gray(255));
            grayImg._Dilate(4);

            var contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(grayImg, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);

            var resultImg = img.Copy();

            for (int i = 0; i < contours.Size; i++)
            {
                if (CvInvoke.ContourArea(contours[i], false) > 50)
                {
                    Rectangle rectangle = CvInvoke.BoundingRectangle(contours[i]);
                    resultImg.Draw(rectangle, new Bgr(Color.Yellow), 2);
                }
            }

            var ocrFromContours = CharacterRecognition(img, contours);
            textBox1.Text = ocrFromContours.ToString();

            return resultImg;
        }

        private void contoursButtonText_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                textBox1.Visible = true;
                resetButton.Visible = true;
                imageBox2.Image = ContoursText(_mainImg).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Обнаружение лиц
        public Image<Bgr, byte> FaceDetect(Image<Bgr, byte> img)
        {
            var resultImg = img.Clone();

            List<Rectangle> faces = new List<Rectangle>();

            using (CascadeClassifier face = new CascadeClassifier("D:\\opencv-master\\data\\haarcascades\\haarcascade_frontalface_default.xml"))
            {
                using (Mat ugray = new Mat())
                {
                    CvInvoke.CvtColor(img, ugray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                    Rectangle[] facesDetected = face.DetectMultiScale(ugray, 1.1, 10, new Size(20, 20));

                    faces.AddRange(facesDetected);
                }
            }

            foreach (Rectangle rectangle in faces)
            {
                resultImg.Draw(rectangle, new Bgr(Color.Yellow), 2);
            }

            return resultImg;
        }

        private void ProcessFrameVideo(object sender, EventArgs e)
        {
            try
            {
                Mat frame = new Mat();
                _capture.Retrieve(frame);

                var frameImg = frame.ToImage<Bgr, byte>();
                imageBox1.Image = frameImg.Resize(400, 360, Inter.Linear);
                imageBox2.Image = FaceDetect(frameImg).Resize(400, 360, Inter.Linear);

                Thread.Sleep((int)_capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps));
            }
            catch (Exception ex)
            {
                _capture.Stop();
            }
        }

        private void contoursButtonFaces_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                textBox1.Visible = false;
                resetButton.Visible = true;
                imageBox2.Image = FaceDetect(_mainImg).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            _capture.Start();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _capture.Stop();
        }

        //Интерфейс
        private void ComponentsVisibleFalse()
        {
            textBox1.Visible = false;
        }

        private void ButtonsVisibleFalse()
        {
            resetButton.Visible = false;
            startButton.Visible = false;
            stopButton.Visible = false;
        }

        private void DefaultValues()
        {

        }

        private void StartDisplay()
        {
            contoursButtonText.Visible = true;
            contoursButtonFaces.Visible = true;
            ComponentsVisibleFalse();
            ButtonsVisibleFalse();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            StartDisplay();
            DefaultValues();
            resetButton.Visible = false;
            imageBox2.Image = null;
            textBox1.Text = null;
            textBox1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void imageBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
