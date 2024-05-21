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
        //private Image<Bgr, byte> _mainImg = null; //Основная картинка
        private VideoCapture _capture; //Для захвата видео
        BackgroundSubtractorMOG2 subtractor;

        public Form1()
        {
            InitializeComponent();

            StartDisplay();
            DefaultValues();
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

                    if (_capture != null)
                    {
                        Mat frame = new Mat();
                        _capture.Retrieve(frame);
                        subtractor = new BackgroundSubtractorMOG2(1000, 32, true);
                        _capture.ImageGrabbed += ProcessFrameVideo;
                        _capture.Start();
                    }
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

        private void loadButton2_Click(object sender, EventArgs e)
        {
            resetButton.Visible = true;
            imageBox2.Visible = true;
            imageBox1.Visible = true;
            startButton.Visible = true;
            stopButton.Visible = true;
            webcamButton.Visible = false;

            LoadVideo(_capture);
        }

        private void ProcessFrameVideo(object sender, EventArgs e)
        {
            try
            {
                Mat frame = new Mat();
                _capture.Retrieve(frame);
                imageBox1.Image = frame.ToImage<Bgr, byte>().Flip(FlipType.Horizontal).Resize(400, 360, Inter.Linear);
                imageBox2.Image = ObjectDetection(frame.ToImage<Bgr, byte>(), subtractor).Flip(FlipType.Horizontal).Resize(400, 360, Inter.Linear);

                Thread.Sleep((int)_capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps));
            }
            catch (Exception ex)
            {
                _capture.Stop();
            }
        }

        //Фильтр на основе морфологических операций
        public static Image<Gray, byte> FilterMask(Image<Gray, byte> mask)
        {
            var anchor = new Point(-1, -1);
            var borderValue = new MCvScalar(1);

            var kernel = CvInvoke.GetStructuringElement(ElementShape.Ellipse, new Size(3, 3), anchor);

            var closing = mask.MorphologyEx(MorphOp.Close, kernel, anchor, 1, BorderType.Default, borderValue);
            var opening = closing.MorphologyEx(MorphOp.Open, kernel, anchor, 1,BorderType.Default, borderValue);

            var dilation = opening.Dilate(7);

            var threshold = dilation.ThresholdBinary(new Gray(240), new Gray(255));

            return threshold;
        }

        //Обнаружение и отрисовка
        public static Image<Bgr, byte> ObjectDetection(Image<Bgr, byte> frame, BackgroundSubtractorMOG2 subtractor)
        {
            var grayFrame = frame.Convert<Gray, byte>();
            var foregroundMask = grayFrame.CopyBlank();

            subtractor.Apply(grayFrame, foregroundMask);
            var foregroundMaskFiltered = FilterMask(foregroundMask);

            CvInvoke.Threshold(foregroundMaskFiltered, foregroundMaskFiltered, 200, 240, ThresholdType.Binary);
            CvInvoke.MorphologyEx(foregroundMaskFiltered, foregroundMaskFiltered, MorphOp.Close, Mat.Ones(7, 3, DepthType.Cv8U, 1), new Point(-1, -1), 1, BorderType.Reflect, new MCvScalar(0));

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(foregroundMaskFiltered, contours, null, RetrType.External, ChainApproxMethod.ChainApproxTc89L1);

            int minArea = 2500;

            for (int i = 0; i < contours.Size; i++)
            {
                if (CvInvoke.ContourArea(contours[i]) > minArea)
                {
                    Rectangle boundingRect = CvInvoke.BoundingRectangle(contours[i]);
                    CvInvoke.Rectangle(frame, boundingRect, new MCvScalar(0, 255, 0), 2);
                }
            }

            return frame;
        }

        //Веб камера
        private void webcamButton_Click(object sender, EventArgs e)
        {
            imageBox1.Visible = true;
            imageBox2.Visible = true;
            resetButton.Visible = true;
            startButton.Visible = true;
            stopButton.Visible = true;
            loadButton2.Visible = false;

            _capture = new VideoCapture();

            if (_capture != null)
            {
                subtractor = new BackgroundSubtractorMOG2(1000, 32, true);
                _capture.ImageGrabbed += ProcessFrameVideo;
                _capture.Start();
            }
        }

        private void startButton_Click_1(object sender, EventArgs e)
        {
            _capture.Start();
        }

        private void stopButton_Click_1(object sender, EventArgs e)
        {
            _capture.Stop();
        }

        //Интерфейс
        private void ComponentsVisibleFalse()
        {
            //нет элементов
        }

        private void ButtonsVisibleFalse()
        {
            resetButton.Visible = false;
            startButton.Visible = false;
            stopButton.Visible = false;
        }

        private void DefaultValues()
        {
            //нет значений
        }

        private void StartDisplay()
        {
            webcamButton.Visible = true;
            loadButton2.Visible = true;
            ComponentsVisibleFalse();
            ButtonsVisibleFalse();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            StartDisplay();
            DefaultValues();
            imageBox2.Image = null;
            imageBox1.Image = null;
            imageBox2.Visible = false;
            imageBox1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void imageBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
