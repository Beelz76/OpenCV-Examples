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

namespace MegaLABS
{
    public partial class Form1 : Form
    {
        private Image<Bgr, byte> _mainImg = null;
        private Image<Gray, byte> _cannyEdges = null;
        private VideoCapture _capture;
        private double _frameCount;
        private double _cannyTreshold;
        private double _cannyTresholdLinking;
        private double _colorThreshold;

        private void DefaultValues()
        {
            _cannyTreshold = 80.0;
            _cannyTresholdLinking = 40.0;
            _colorThreshold = 0.0;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextBoxVisibleFalse();
            ButtonVisibleFalse();
            DefaultValues();
        }

        //Фильтр Кэнни
        private void CannyFilter()
        {
            Image<Gray, byte> grayImg = _mainImg.Convert<Gray, byte>();

            var tempImg = grayImg.PyrDown();
            var destImg = tempImg.PyrUp();

            _cannyEdges = destImg.Canny(_cannyTreshold, _cannyTresholdLinking);

            imageBox4.Visible = false;
            imageBox2.Image = _cannyEdges.Resize(400, 400, Inter.Linear);
        }

        //Цветовой фильтр
        private void ThresholdFilter()
        {
            var cannyEdgesBgr = _cannyEdges.Convert<Bgr, byte>();
            var resultImg = _mainImg.Sub(cannyEdgesBgr);

            for (int channel = 0; channel < resultImg.NumberOfChannels; channel++)
                for (int y = 0; y < resultImg.Height; y++)
                    for (int x = 0; x < resultImg.Width; x++)
                    {
                        byte color = resultImg.Data[x, y, channel];
                        if (color <= 50 + _colorThreshold)
                            color = 0;
                        else if (color <= 100 + _colorThreshold)
                            color = 25;
                        else if (color <= 150 + _colorThreshold)
                            color = 180;
                        else if (color <= 200 + _colorThreshold)
                            color = 210;
                        else
                            color = 255;
                        resultImg.Data[x, y, channel] = color;
                    }

            imageBox3.Image = resultImg.Resize(400, 400, Inter.Linear);
        }

        //Часть с изображением
        private void button1_Click(object sender, EventArgs e)
        {
            TextBoxVisibleTrue();
            ImageBoxVisibleTrue();
            ChangeFiltersOn();
            button17.Visible = true;

            try
            {
                //Выбираем и загружаем изображение
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Формат(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _mainImg = new Image<Bgr, byte>(ofd.FileName);
                    imageBox1.Image = _mainImg.Resize(400, 400, Inter.Linear);

                    //Фильтр Кэнни
                    CannyFilter();

                    //Пороговый цветовой фильтр
                    ThresholdFilter();
                }
                else
                {
                    MessageBox.Show("Файл не выбран!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            TextBoxVisibleFalse();
            ButtonVisibleFalse();
            ImageBoxVisibleFalse();
            button17.Visible = false;

            imageBox1.Image = null;
            imageBox2.Image = null;
            imageBox3.Image = null;

            DefaultValues();
        }

        //Часть с веб-камерой
        private void button2_Click(object sender, EventArgs e)
        {
            TextBoxVisibleFalse();
            ImageBoxVisibleFalse();
            ChangeFiltersOff();
            button17.Visible = false;
            button4.Visible = true;
            imageBox4.Visible = true;

            _capture = new VideoCapture();
            _capture.ImageGrabbed += ProcessFrameWeb;
            _capture.Start();
        }

        private void ProcessFrameWeb(object sender, EventArgs e)
        {
            Mat frame = new Mat();
            _capture.Retrieve(frame);
            imageBox4.Image = frame.ToImage<Bgr, byte>().Flip(FlipType.Horizontal).Resize(800, 600, Inter.Linear);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            imageBox4.Visible = false;
            button4.Visible = false;

            _capture.Stop();
        }

        //Часть с видео
        private void button3_Click(object sender, EventArgs e)
        {
            ChangeFiltersOn();
            TextBoxVisibleTrue();
            ImageBoxVisibleTrue();
            button17.Visible = false;

            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Формат(*.mp4, *.avi, *.wmv, *.gif) | *.mp4; *.avi; *.wmv; *,gif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _capture = new VideoCapture(ofd.FileName);
                    _frameCount = _capture.GetCaptureProperty(CapProp.FrameCount);
                    _capture.ImageGrabbed += ProcessFrameVideo;
                    _capture.Start();
                    button18.Visible = true;
                }
                else
                {
                    MessageBox.Show("Файл не выбран!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessFrameVideo(object sender, EventArgs e)
        {
            Mat frame = new Mat();
            _capture.Retrieve(frame);
            _mainImg = frame.ToImage<Bgr, byte>();
            imageBox1.Image = _mainImg.Resize(400, 400, Inter.Linear);

            //Фильтр Кэнни
            CannyFilter();

            //Пороговый цветовой фильтр
            ThresholdFilter();

            _frameCount--;
            if (_frameCount == 0)
            {
                button18.Visible = false;
                MessageBox.Show("Видео закончилось!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _capture.Stop();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            button17.Visible = false;
            button18.Visible = false;

            DefaultValues();

            _capture.Stop();
        }

        //Часть с изменением значений для фильтров
        private void button5_Click(object sender, EventArgs e)
        {
            _cannyTreshold += 1.0;
            CannyFilter();
            ThresholdFilter();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _cannyTreshold -= 1.0;
            CannyFilter();
            ThresholdFilter();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _cannyTreshold += 10.0;
            CannyFilter();
            ThresholdFilter();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            _cannyTreshold -= 10.0;
            CannyFilter();
            ThresholdFilter();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            _cannyTresholdLinking -= 1.0;
            CannyFilter();
            ThresholdFilter();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            _cannyTresholdLinking += 1.0;
            CannyFilter();
            ThresholdFilter();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            _cannyTresholdLinking -= 10.0;
            CannyFilter();
            ThresholdFilter();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            _cannyTresholdLinking += 10.0;
            CannyFilter();
            ThresholdFilter();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            _colorThreshold -= 1.0;
            CannyFilter();
            ThresholdFilter();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            _colorThreshold += 1.0;
            CannyFilter();
            ThresholdFilter();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            _colorThreshold -= 10.0;
            CannyFilter();
            ThresholdFilter();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            _colorThreshold += 10.0;
            CannyFilter();
            ThresholdFilter();
        }

        //Интерфейс
        private void TextBoxVisibleFalse()
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
        }

        private void TextBoxVisibleTrue()
        {
            textBox1.Visible = true;
            textBox1.Text = "Оригинал";

            textBox2.Visible = true;
            textBox2.Text = "Фильтр Кэнни";

            textBox3.Visible = true;
            textBox3.Text = "Пороговый фильтр";
        }

        private void ImageBoxVisibleFalse()
        {
            imageBox1.Visible = false;
            imageBox2.Visible = false;
            imageBox3.Visible = false;
            imageBox4.Visible = false;
        }

        private void ImageBoxVisibleTrue()
        {
            imageBox1.Visible = true;
            imageBox2.Visible = true;
            imageBox3.Visible = true;
        }

        private void ButtonVisibleFalse()
        {
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
        }

        private void ChangeFiltersOn()
        {
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;
            button14.Visible = true;
            button15.Visible = true;
            button16.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
        }

        private void ChangeFiltersOff()
        {
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void imageBox4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void imageBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
