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
        private Image<Bgr, byte> _secondImg = null; //Для гомографии
        private int _border = 0; //Для сдвига
        private int _centerX = 0; //Для поворота
        private int _centerY = 0; //Для поворота

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
                    img = new Image<Bgr, byte>(ofd.FileName).Resize(400, 360, Inter.Linear);
                    _mainImg = img;
                    _secondImg = img.Resize(400, 360, Inter.Linear);
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

        //Масштабирование изображения
        private Image<Bgr, byte> ScalingImage(Image<Bgr, byte> img, double sX, double sY)
        {
            if (sY == 0.7)
            {
                sY = 0.71;
            }

            img = img.Resize(400, 360, Inter.Linear);
            var resultImg = new Image<Bgr, byte>((int)(img.Width * sX), (int)(img.Height * sY));

            for (int channel = 0; channel < img.NumberOfChannels; channel++) 
            { 
                for (int x = 0; x < img.Width; x++)
                {
                    for (int y = 0; y < img.Height; y++)
                    {
                        int newX, newY;

                        if (sX > 1 || sY > 1)
                        {
                            try
                            {
                                newX = (int)(x / sX);
                                newY = (int)(y / sY);
                                resultImg.Data[y, x, channel] = BilinearFilter(img, newX, newY, channel);
                            }
                            catch
                            {
                                continue;
                            }
                        }
                        else
                        {
                            newX = (int)(x * sX);
                            newY = (int)(y * sY);
                            resultImg[newY, newX] = img[y, x];
                        }
                        
                        
                    }
                }
            }

            return resultImg;
        }

        private void scalingButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                ScalingDisplay();
                scalingLabelX.Text = "X: " + (scalingTrackBarX.Value / 10.0).ToString();
                scalingLabelY.Text = "Y: " + (scalingTrackBarX.Value / 10.0).ToString();
                imageBox2.Image = ScalingImage(_mainImg, 1, 1);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void scalingTrackBarX_Scroll(object sender, EventArgs e)
        {
            scalingLabelX.Text = "X: " + (scalingTrackBarX.Value / 10.0).ToString();
            imageBox2.Image = ScalingImage(_mainImg, scalingTrackBarX.Value / 10.0, scalingTrackBarY.Value / 10.0);
        }

        private void scalingTrackBarY_Scroll(object sender, EventArgs e)
        {
            scalingLabelY.Text = "Y: " + (scalingTrackBarY.Value / 10.0).ToString();
            imageBox2.Image = ScalingImage(_mainImg, scalingTrackBarX.Value / 10.0, scalingTrackBarY.Value / 10.0);
        }

        //Сдвиг изображения
        private Image<Bgr,byte> ShearingImage(Image<Bgr, byte> img, double shift, int a)
        {
            img = img.Resize(400, 360, Inter.Linear);
            var resultImg = new Image<Bgr, byte>(img.Size);

            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    int newX, newY;

                    switch (a)
                    {
                        case 1: 
                            //горизонтальный сдвиг
                            if ((int)(x + shift * (img.Height - y)) >= img.Width)
                            {
                                newX = img.Width - 1;
                                newY = y;
                            }
                            else if ((int)(x + shift * (img.Height - y)) < 0)
                            {
                                newX = 0;
                                newY = y;
                            }
                            else
                            {
                                newX = (int)(x + shift * (img.Height - y));
                                newY = y;
                            }
                            break;
                        case 2: 
                            //вертикальный сдвиг
                            if ((int)(y + shift * (img.Width - x)) >= img.Height)
                            {
                                newY = img.Height - 1;
                                newX = x;
                            }
                            else if ((int)(y + shift * (img.Width - x)) < 0)
                            {
                                newY = 0;
                                newX = x;
                            }
                            else
                            {
                                newY = (int)(y + shift * (img.Width - x));
                                newX = x;
                            }
                            break;
                        default:
                            newX = x;
                            newY = y;
                            break;
                    }

                    resultImg[newY, newX] = img[y, x];
                }
            }

            return resultImg;
        }

        private void shearingButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                ShearingDisplay();
                shiftLabel.Text = "Shift: " + (shiftTrackBar.Value / 10.0).ToString();
                imageBox2.Image = ShearingImage(_mainImg, 0, 0).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void shiftTrackBar_Scroll(object sender, EventArgs e)
        {
            shiftLabel.Text = "Shift: " + (shiftTrackBar.Value / 10.0).ToString();
            imageBox2.Image = ShearingImage(_mainImg, (shiftTrackBar.Value / 10.0), _border);
        }

        private void shearingButtonHorizontal_Click(object sender, EventArgs e)
        {
            DefaultValues();
            _border = 1;
            shiftLabel.Text = "Shift: " + (shiftTrackBar.Value / 10.0).ToString();
            imageBox2.Image = ShearingImage(_mainImg, (shiftTrackBar.Value / 10.0), _border);
        }

        private void shearingButtonVertical_Click(object sender, EventArgs e)
        {
            DefaultValues();
            _border = 2;
            shiftLabel.Text = "Shift: " + (shiftTrackBar.Value / 10.0).ToString();
            imageBox2.Image = ShearingImage(_mainImg, (shiftTrackBar.Value / 10.0), _border);
        }

        //Поворот изображения
        private Image<Bgr, byte> RotateImage(Image<Bgr, byte> img, double angle, int _centerX, int _centerY)
        {
            angle = (Math.PI * angle) / 180;
            img = img.Resize(400, 360, Inter.Linear);
            var resultImg = new Image<Bgr, byte>(img.Size);

            for (int channel = 0; channel < img.NumberOfChannels; channel++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    for (int y = 0; y < img.Height; y++)
                    {
                        int newX = (int)(Math.Cos(angle) * (x - _centerX) - Math.Sin(angle) * (y - _centerY) + _centerX);
                        int newY = (int)(Math.Sin(angle) * (x - _centerX) + Math.Cos(angle) * (y - _centerY) + _centerY);

                        if (newX >= img.Width || newX < 0 || newY >= img.Height || newY < 0)
                        {
                            continue;
                        }
                        else
                        {
                            resultImg.Data[y, x, channel] = BilinearFilter(img, newX, newY, channel);
                            //resultImg[newY, newX] = img[y, x];
                        }
                    }
                }
            }

            return resultImg;
        }

        private void rotateButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                RotateDisplay();
                rotateLabel.Text = "Angle: " + rotateTrackBar.Value.ToString() + "°";
                imageBox2.Image = RotateImage(_mainImg, rotateTrackBar.Value, _centerX, _centerY).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void rotateTrackBar_Scroll(object sender, EventArgs e)
        {
            rotateLabel.Text = "Angle: " + rotateTrackBar.Value.ToString() + "°";
            imageBox2.Image = RotateImage(_mainImg, rotateTrackBar.Value, _centerX, _centerY);
        }

        private void rotateLeftTopButton_Click(object sender, EventArgs e)
        {
            DefaultValues();
            rotateLabel.Text = "Angle: " + rotateTrackBar.Value.ToString() + "°";
            imageBox2.Image = RotateImage(_mainImg, rotateTrackBar.Value, _centerX, _centerY);
        }

        private void rotateRightTopButton_Click(object sender, EventArgs e)
        {
            DefaultValues();
            _centerX = _mainImg.Width;
            _centerY = 0;
            rotateLabel.Text = "Angle: " + rotateTrackBar.Value.ToString() + "°";
            imageBox2.Image = RotateImage(_mainImg, rotateTrackBar.Value, _centerX, _centerY);
        }

        private void rotateLeftBottomButton_Click(object sender, EventArgs e)
        {
            DefaultValues();
            _centerX = 0;
            _centerY = _mainImg.Height;
            rotateLabel.Text = "Angle: " + rotateTrackBar.Value.ToString() + "°";
            imageBox2.Image = RotateImage(_mainImg, rotateTrackBar.Value, _centerX, _centerY);
        }

        private void rotateRightBottomButton_Click(object sender, EventArgs e)
        {
            DefaultValues();
            _centerX = _mainImg.Width;
            _centerY = _mainImg.Height;
            rotateLabel.Text = "Angle: " + rotateTrackBar.Value.ToString() + "°";
            imageBox2.Image = RotateImage(_mainImg, rotateTrackBar.Value, _centerX, _centerY);
        }

        //Отражение изображения
        private Image<Bgr, byte> ReflectionImage(Image<Bgr, byte> img, int qX, int qY)
        {
            img = img.Resize(400, 360, Inter.Linear);
            var resultImg = new Image<Bgr, byte>(img.Size);

            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {        
                    int newX, newY;

                    if (qX == 1)
                    {
                        //по горизонтали (1, -1)
                        newX = x;
                        newY = y * qY + img.Height - 1;
                    }
                    else
                    {
                        //по вертикали (-1, 1)
                        newX = x * qX + img.Width - 1;
                        newY = y;
                    }

                    resultImg[newY, newX] = img[y, x];
                }
            }

            return resultImg;
        }

        private void reflectionButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                ReflectionDisplay();
                _secondImg = _mainImg;
                imageBox2.Image = _secondImg.Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void reflectionButtonVertical_Click(object sender, EventArgs e)
        {
            _secondImg = ReflectionImage(_secondImg, -1, 1);
            imageBox2.Image = _secondImg.Resize(400, 360, Inter.Linear);
        }

        private void reflectionButtonHorizontal_Click(object sender, EventArgs e)
        {
            _secondImg = ReflectionImage(_secondImg, 1, -1);
            imageBox2.Image = _secondImg.Resize(400, 360, Inter.Linear);
        }

        //Билинейная фильтрация
        private byte BilinearFilter(Image<Bgr, byte> img, double x, double y, int channel)
        {
            byte q, q1, q2;

            var xFloor = Math.Floor(x);
            var xCeil = Math.Min(img.Width - 1, Math.Ceiling(x));

            var yFloor = Math.Floor(y);
            var yCeil = Math.Min(img.Height - 1, Math.Ceiling(y));

            if (xCeil == xFloor && yCeil == yFloor)
            {
                q = img.Data[(int)(y), (int)(x), channel];
            }
            else if (xCeil == xFloor)
            {
                q1 = img.Data[(int)yFloor, (int)x, channel];
                q2 = img.Data[(int)yCeil, (int)x, channel];
                q = Convert.ToByte(q1 * (yCeil - y) + q2 * (y - yFloor));
            }
            else if (yCeil == yFloor)
            {
                q1 = img.Data[(int)y, (int)xFloor, channel];
                q2 = img.Data[(int)y, (int)xCeil, channel];
                q = Convert.ToByte(q1 * (xCeil - x) + q2 * (x - xFloor));
            }
            else
            {
                var v1 = img.Data[(int)yFloor, (int)xFloor, channel];
                var v2 = img.Data[(int)yFloor, (int)xCeil, channel];
                var v3 = img.Data[(int)yCeil, (int)xFloor, channel];
                var v4 = img.Data[(int)yCeil, (int)xCeil, channel];
                
                q1 = Convert.ToByte(v1 * (xCeil - x) + v2 * (x - xFloor));
                q2 = Convert.ToByte(v3 * (xCeil - x) + v4 * (x - xFloor));
                q = Convert.ToByte(q1 * (yCeil - y) + q2 * (y - yFloor));
            }
            
            return q;
        }

        //Проекция изображения
        public struct Cordinate
        {
            int x, y;

            public Cordinate(int xx, int yy)
            {
                x = xx;
                y = yy;
            }

            public void SetCord(int xx, int yy)
            {
                x = xx;
                y = yy;
            }

            public int X { get { return x; } }
            public int Y { get { return y; } }
        }

        List<Cordinate> src = new List<Cordinate>();

        private void imageBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (src.Count < 4)
            {
                int x = (int)(e.Location.X / imageBox1.ZoomScale);
                int y = (int)(e.Location.Y / imageBox1.ZoomScale);

                Cordinate crd = new Cordinate();
                crd.SetCord(x, y);

                src.Add(crd);

                Point center = new Point(x, y);
                int radius = 2;
                int thickness = 2;
                var color = new Bgr(Color.Yellow).MCvScalar;

                CvInvoke.Circle(_secondImg, center, radius, color, thickness);
                imageBox1.Image = _secondImg.Resize(400, 360, Inter.Linear);
            }
            else
            {
                return;
            }
        }

        private void projectionButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                ProjectionDisplay();

                var srcPoints = new PointF[]
                {
                    new PointF(src[0].X, src[0].Y),
                    new PointF(src[1].X, src[1].Y),
                    new PointF(src[2].X, src[2].Y),
                    new PointF(src[3].X, src[3].Y),
                };


                var destPoints = new PointF[]
                {
                    new PointF(0, 0),
                    new PointF(0, _mainImg.Height - 1),
                    new PointF(_mainImg.Width - 1, _mainImg.Height - 1),
                    new PointF(_mainImg.Width - 1, 0),
                };

                var homographyMatrix = CvInvoke.GetPerspectiveTransform(srcPoints, destPoints);
                var destImage = new Image<Bgr, byte>(_mainImg.Size);
                CvInvoke.WarpPerspective(_mainImg, destImage, homographyMatrix, destImage.Size);

                imageBox2.Image = destImage;
                src.Clear();

                imageBox1.Image = _mainImg.Resize(400, 360, Inter.Linear);

                _secondImg = new Image<Bgr, byte>(_mainImg.Size);

                for(int y = 0; y < _mainImg.Height; y++) 
                {
                    for (int x = 0; x < _mainImg.Width; x++)
                    {
                        _secondImg[y, x] = _mainImg[y, x];
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Интерфейс
        private void ProjectionDisplay()
        {
            resetButton.Visible = true;
            reflectionButton.Visible = false;
            shearingButton.Visible = false;
            scalingButton.Visible = false;
            rotateButton.Visible = false;
            projectionButton.Visible = false;
        }

        private void ReflectionDisplay()
        {
            resetButton.Visible = true;
            reflectionButton.Visible = false;
            shearingButton.Visible = false;
            scalingButton.Visible = false;
            rotateButton.Visible = false;
            projectionButton.Visible = false;

            reflectionButtonHorizontal.Visible = true;
            reflectionButtonVertical.Visible = true;

        }

        private void RotateDisplay()
        {
            resetButton.Visible = true;
            rotateLabel.Visible = true;
            rotateTrackBar.Visible = true;
            rotateLeftBottomButton.Visible = true;
            rotateRightBottomButton.Visible = true;
            rotateRightTopButton.Visible = true;
            rotateLeftTopButton.Visible = true;

            shearingButton.Visible = false;
            scalingButton.Visible = false;
            rotateButton.Visible = false;
            reflectionButton.Visible = false;
            projectionButton.Visible = false;
        }

        private void ShearingDisplay()
        {
            resetButton.Visible = true;
            shiftLabel.Visible = true;
            shiftTrackBar.Visible = true;

            shearingButtonHorizontal.Visible = true;
            shearingButtonVertical.Visible = true;

            scalingButton.Visible = false;
            shearingButton.Visible = false;
            rotateButton.Visible = false;
            reflectionButton.Visible = false;
            projectionButton.Visible = false;
        }

        private void ScalingDisplay()
        {
            scalingLabelX.Visible = true;
            scalingLabelY.Visible = true;
            scalingTrackBarX.Visible = true;
            scalingTrackBarY.Visible = true;
            resetButton.Visible = true;


            shearingButton.Visible = false;
            scalingButton.Visible = false;
            rotateButton.Visible = false;
            reflectionButton.Visible = false;
            projectionButton.Visible = false;
        }

        private void ComponentsVisibleFalse()
        {
            scalingLabelX.Visible = false;
            scalingLabelY.Visible = false;
            scalingTrackBarX.Visible = false;
            scalingTrackBarY.Visible = false;

            shiftTrackBar.Visible = false;
            shiftLabel.Visible = false;

            rotateTrackBar.Visible = false;
            rotateLabel.Visible = false;
        }

        private void ButtonsVisibleFalse()
        {
            shearingButtonHorizontal.Visible = false;
            shearingButtonVertical.Visible = false;

            rotateLeftBottomButton.Visible = false;
            rotateRightBottomButton.Visible = false;
            rotateRightTopButton.Visible = false;
            rotateLeftTopButton.Visible = false;

            reflectionButtonHorizontal.Visible = false;
            reflectionButtonVertical.Visible = false;
        }

        private void DefaultValues()
        {
            _border = 0;
            _centerX = 0;
            _centerY = 0;

            scalingTrackBarX.Value = 10;
            scalingTrackBarY.Value = 10;

            shiftTrackBar.Value = 0;

            rotateTrackBar.Value = 0;
        }

        private void StartDisplay()
        {
            resetButton.Visible = false;
            scalingButton.Visible = true;
            shearingButton.Visible = true;
            rotateButton.Visible = true;
            reflectionButton.Visible = true;
            projectionButton.Visible = true;

            ComponentsVisibleFalse();
            ButtonsVisibleFalse();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            StartDisplay();
            DefaultValues();
            resetButton.Visible = false;
            imageBox2.Image = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void imageBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
