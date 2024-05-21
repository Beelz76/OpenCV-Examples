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
        private Image<Bgr, byte> _mainImg = null; //Основная картинка
        private Image<Gray, byte> _secondImg = null; //Для итоговой картинки
        private int _choice; //Для ползунков

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

        private void loadButton1_Click_1(object sender, EventArgs e)
        {
            LoadImage(_mainImg);
        }

        //Размытие по Гауссу
        private Image<Gray, byte> GaussianBlur(Image<Bgr, byte> img)
        {
            var grayImage = img.Convert<Gray, byte>();
            int kernelSize = 5;
            var bluredImage = grayImage.SmoothGaussian(kernelSize);

            return bluredImage;
        }

        private void processingButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                ComponentsVisibleFalse();
                DefaultValues();
                resetButton.Visible = true;
                _secondImg = GaussianBlur(_mainImg);
                imageBox2.Image = Binarization(_secondImg, thresholdTrackBar.Value).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Бинаризация или фильтр Кэнни
        /*private Image<Gray,byte> CannyFilter(Image<Gray, byte> img, int cannyThreshold, int cannyThresholdLinking)
        {
            var _cannyEdges = img.Canny(cannyThreshold, cannyThresholdLinking);

            return _cannyEdges;
        }*/

        private Image<Gray, byte> Binarization(Image<Gray, byte> img, int thr)
        {
            var threshold = new Gray(thr);
            var color = new Gray(255);
            var binarizedImage = img.ThresholdBinary(threshold, color);

            return binarizedImage;
        }

        private void thresholdTrackBar_Scroll(object sender, EventArgs e)
        {
            thresholdLabel.Text = "Пороговое значение: " + thresholdTrackBar.Value.ToString();
            _secondImg = GaussianBlur(_mainImg);

            switch (_choice)
            {
                case 1:
                    imageBox2.Image = FindContour(Binarization(_secondImg, thresholdTrackBar.Value)).Resize(400, 360, Inter.Linear);
                    break;
                case 2:
                    imageBox2.Image = FindPrimitives(Binarization(_secondImg, thresholdTrackBar.Value), minSquareTrackBar.Value, 0, 0).Resize(400, 360, Inter.Linear);
                    break;
                case 3:
                    imageBox2.Image = FindPrimitives(Binarization(_secondImg, thresholdTrackBar.Value), minSquareTrackBar.Value, 3, 1).Resize(400, 360, Inter.Linear);
                    break;
                case 4:
                    imageBox2.Image = FindPrimitives(Binarization(_secondImg, thresholdTrackBar.Value), minSquareTrackBar.Value, 4, 1).Resize(400, 360, Inter.Linear);
                    break;
            }
        }

        //Поиск контуров
        private Image<Bgr, byte> FindContour(Image<Gray, byte> img)
        {
            var contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(img, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);

            var contoursImg = _mainImg.CopyBlank();

            for(int i = 0; i < contours.Size; i++)
            {
                var points = contours[i].ToArray();
                contoursImg.Draw(points, new Bgr(Color.Yellow), 2);
            }

            return contoursImg;
        }

        private void contourButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                DefaultValues();
                _choice = 1;
                thresholdLabel.Visible = true;
                thresholdTrackBar.Visible = true;
                minSquareTrackBar.Visible = false;
                minSquareLabel.Visible = false;
                resetButton.Visible = true;
                thresholdLabelCircle.Visible = false;
                thresholdTrackBarCircle.Visible = false;
                minDistanceLabel.Visible = false;
                minDistanceTrackBar.Visible = false;
                thresholdLabel.Text = "Пороговое значение: " + thresholdTrackBar.Value.ToString();

                _secondImg = GaussianBlur(_mainImg);
                imageBox2.Image = FindContour(Binarization(_secondImg, thresholdTrackBar.Value)).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Поиск примитивов
        private Image<Bgr, byte> FindPrimitives(Image<Gray, byte> img, int square,int a, int b)
        {
            int minArea = square;
            Image<Bgr, byte> contoursImg;

            var contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(img, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);

            if (b == 0)
            {
                contoursImg = _mainImg.CopyBlank();
            }
            else
            {
                contoursImg = _mainImg.Copy(); //Поверх изображения
            }

            for (int i = 0; i < contours.Size; i++)
            {
                var approxContour = new VectorOfPoint();
                CvInvoke.ApproxPolyDP(contours[i], approxContour, CvInvoke.ArcLength(contours[i], true) * 0.05, true);
                var points = approxContour.ToArray();

                if (a == 0)
                {
                    if (CvInvoke.ContourArea(approxContour, false) > minArea)
                    {
                        contoursImg.Draw(points, new Bgr(Color.Yellow), 2);
                    }
                }
                else if (a == 3)
                {
                    if (approxContour.Size == 3) //Для треугольников
                    {
                        if (CvInvoke.ContourArea(approxContour, false) > minArea)
                        {
                            contoursImg.Draw(new Triangle2DF(points[0], points[1], points[2]), new Bgr(Color.Yellow), 2);
                        }
                    }
                }
                else if (a == 4) //Для четырехугольников
                {
                    if (CvInvoke.ContourArea(approxContour, false) > minArea)
                    {
                        if (isRectangle(points))
                        {
                            contoursImg.Draw(CvInvoke.MinAreaRect(approxContour), new Bgr(Color.Yellow), 2);
                        }
                    }
                }
            }

            return contoursImg;
        }

        private void primitivesButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                DefaultValues();
                _choice = 2;
                thresholdLabel.Visible = true;
                thresholdTrackBar.Visible = true;
                minSquareLabel.Visible = true;
                minSquareTrackBar.Visible = true;
                resetButton.Visible = true;
                thresholdLabelCircle.Visible = false;
                thresholdTrackBarCircle.Visible = false;
                minDistanceLabel.Visible = false;
                minDistanceTrackBar.Visible = false;
                thresholdLabel.Text = "Пороговое значение: " + thresholdTrackBar.Value.ToString();

                _secondImg = GaussianBlur(_mainImg);
                imageBox2.Image = FindPrimitives(Binarization(_secondImg, thresholdTrackBar.Value), minSquareTrackBar.Value, 0, 0).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void primitivesButtonTriagnel_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                DefaultValues();
                _choice = 3;
                thresholdLabel.Visible = true;
                thresholdTrackBar.Visible = true;
                minSquareLabel.Visible = true;
                minSquareTrackBar.Visible = true;
                resetButton.Visible = true;
                thresholdLabelCircle.Visible = false;
                thresholdTrackBarCircle.Visible = false;
                minDistanceLabel.Visible = false;
                minDistanceTrackBar.Visible = false;
                thresholdLabel.Text = "Пороговое значение: " + thresholdTrackBar.Value.ToString();

                _secondImg = GaussianBlur(_mainImg);
                imageBox2.Image = FindPrimitives(Binarization(_secondImg, thresholdTrackBar.Value), minSquareTrackBar.Value, 3, 1).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void minSquareTrackBar_Scroll(object sender, EventArgs e)
        {
            minSquareLabel.Text = "Минимальная площадь контуров: " + minSquareTrackBar.Value.ToString();
            _secondImg = GaussianBlur(_mainImg);

            switch (_choice)
            {
                case 2:
                    imageBox2.Image = FindPrimitives(Binarization(_secondImg, thresholdTrackBar.Value), minSquareTrackBar.Value, 0, 0).Resize(400, 360, Inter.Linear);
                    break;
                case 3:
                    imageBox2.Image = FindPrimitives(Binarization(_secondImg, thresholdTrackBar.Value), minSquareTrackBar.Value, 3, 1).Resize(400, 360, Inter.Linear);
                    break;
                case 4:
                    imageBox2.Image = FindPrimitives(Binarization(_secondImg, thresholdTrackBar.Value), minSquareTrackBar.Value, 4, 1).Resize(400, 360, Inter.Linear);
                    break;
            }
        }

        //Контуры четырехугольников
        private bool isRectangle(Point[] points)
        {
            int delta = 10;
            LineSegment2D[] edges = PointCollection.PolyLine(points, true);

            for (int i = 0; i < edges.Length; i++) 
            {
                double angle = Math.Abs(edges[(i + 1) % edges.Length].GetExteriorAngleDegree(edges[i]));

                if (angle < 90 - delta || angle > 90 + delta)
                {
                    return false;
                }
            }

            return true;
        }

        private void primitivesButtonRectangle_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                DefaultValues();
                _choice = 4;
                thresholdLabel.Visible = true;
                thresholdTrackBar.Visible = true;
                minSquareLabel.Visible = true;
                minSquareTrackBar.Visible = true;
                resetButton.Visible = true;
                thresholdLabelCircle.Visible = false;
                thresholdTrackBarCircle.Visible = false;
                minDistanceLabel.Visible = false;
                minDistanceTrackBar.Visible = false;
                thresholdLabel.Text = "Пороговое значение: " + thresholdTrackBar.Value.ToString();

                _secondImg = GaussianBlur(_mainImg);
                imageBox2.Image = FindPrimitives(Binarization(_secondImg, thresholdTrackBar.Value), minSquareTrackBar.Value, 4, 1).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Контуры окружностей
        private Image<Bgr, byte> FindCircles(Image<Bgr, byte> img, int minDistance, int acThreshold)
        {
            var grayImage = img.Convert<Gray, byte>();
            var bluredImage = grayImage.SmoothGaussian(9);

            List<CircleF> circles = new List<CircleF>(CvInvoke.HoughCircles(bluredImage, HoughModes.Gradient, 1.0, minDistance, 100, acThreshold, 0, 1000));

            var resultImg = img.Copy();

            foreach (CircleF circle in circles)
            {
                resultImg.Draw(circle, new Bgr(Color.Yellow), 2);
            }

            return resultImg;
        }

        private void primitivesButtonCircle_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                DefaultValues();
                thresholdLabel.Visible = false;
                thresholdTrackBar.Visible = false;
                minSquareLabel.Visible = false;
                minSquareTrackBar.Visible = false;
                resetButton.Visible = true;
                thresholdLabelCircle.Visible = true;
                thresholdTrackBarCircle.Visible = true;
                minDistanceLabel.Visible = true;
                minDistanceTrackBar.Visible = true;
                thresholdLabelCircle.Text = "Пороговое значение: " + thresholdTrackBarCircle.Value.ToString();
                minDistanceLabel.Text = "Минимальная дистанция: " + minDistanceTrackBar.Value.ToString();

                _secondImg = GaussianBlur(_mainImg);
                imageBox2.Image = FindCircles(_mainImg, thresholdTrackBarCircle.Value, minDistanceTrackBar.Value).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void minDistanceTrackBar_Scroll(object sender, EventArgs e)
        {
            minDistanceLabel.Text = "Минимальная дистанция: " + minDistanceTrackBar.Value.ToString();
            imageBox2.Image = FindCircles(_mainImg, thresholdTrackBarCircle.Value, minDistanceTrackBar.Value).Resize(400, 360, Inter.Linear);
        }

        private void thresholdTrackBarCircle_Scroll(object sender, EventArgs e)
        {
            thresholdLabelCircle.Text = "Пороговое значение: " + thresholdTrackBarCircle.Value.ToString();
            imageBox2.Image = FindCircles(_mainImg, thresholdTrackBarCircle.Value, minDistanceTrackBar.Value).Resize(400, 360, Inter.Linear);
        }

        //Интерфейс
        private void ComponentsVisibleFalse()
        {
            minSquareTrackBar.Visible = false;
            minSquareLabel.Visible = false;
            thresholdLabel.Visible = false;
            thresholdTrackBar.Visible = false;
            minDistanceLabel.Visible = false;
            minDistanceTrackBar.Visible = false;
            thresholdTrackBarCircle.Visible = false;
            thresholdLabelCircle.Visible = false;
        }

        private void ButtonsVisibleFalse()
        {
            resetButton.Visible = false;
        }

        private void DefaultValues()
        {
            thresholdTrackBar.Value = 100;
            minSquareTrackBar.Value = 200;
            thresholdTrackBarCircle.Value = 100;
            minDistanceTrackBar.Value = 50;
            _choice = 0;
        }

        private void StartDisplay()
        {
            ComponentsVisibleFalse();
            ButtonsVisibleFalse();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            StartDisplay();
            DefaultValues();
            resetButton.Visible = false;
            imageBox2.Image = null;
            _secondImg = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void imageBox1_Click(object sender, EventArgs e)
        {

        }

        private void minSquareLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
