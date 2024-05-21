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
        private Image<Bgr, byte> _secondImg = null; //Вторая картинка
        private int _choice = 0; //Для интерфейса

        public Form1()
        {
            InitializeComponent();

            StartDisplay();
            DefaultValues();
            ButtonVisibleFalse();
            loadButton2.Visible = false;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            StartDisplay();
            StartButtons();
            _choice = 0;
        }

        private void resetButton1_Click(object sender, EventArgs e)
        {
            DefaultValues();
            resetButton1.Visible = false;
            imageBox2.Image = null;
            imageBox3.Image = null;
        }

        private void resetButton2_Click(object sender, EventArgs e)
        {
            DefaultValues();

            switch (_choice)
            {
                case 0:
                case 5:
                    imageBox2.Image = _mainImg.Resize(400, 360, Inter.Linear);
                    break;
                case 4:
                    imageBox2.Image = hsvFilter(_mainImg, 150, 0, 0).Resize(400, 360, Inter.Linear);
                    break;
                case 6:
                    imageBox2.Image = _secondImg.Resize(400, 360, Inter.Linear);
                    imageBox3.Image = null;
                    numericUpDownOper1.Visible = true;
                    numericUpDownOper2.Visible = true;
                    break;
                default:
                    imageBox2.Image = _secondImg.Resize(400, 360, Inter.Linear);
                    imageBox3.Image = null;
                    numericUpDownOper1.Visible = false;
                    numericUpDownOper2.Visible = false;
                    cartoonNumericUpDown1.Visible = false;
                    cartoonNumericUpDown2.Visible = false;
                    break;
            }
        }

        //Загрузка изображения
        private void LoadImage(Image<Bgr, byte> img, int a)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Формат(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    img = new Image<Bgr, byte>(ofd.FileName);
                    if (a == 1)
                    {
                        _mainImg = img;
                        imageBox1.Image = img.Resize(400, 360, Inter.Linear);
                    }
                    else
                    {
                        _secondImg = img;
                        imageBox2.Image = img.Resize(400, 360, Inter.Linear);
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

        private void loadButton1_Click(object sender, EventArgs e)
        {
            LoadImage(_mainImg, 1);

            StartButtons();
            loadButton2.Visible = true;
        }

        private void loadButton2_Click(object sender, EventArgs e)
        {
            LoadImage(_secondImg, 2);

            ButtonVisibleFalse();
            resetButton1.Visible = true;
            operationsButton.Visible = true;
            watercolorButton.Visible = true;
            backButton.Visible = true;
        }

        //Каналы изображения
        private Image<Bgr, byte> GetChannel(Image<Bgr, byte> img, int channelIndex)
        {
            var channel = img.Split()[channelIndex];

            /*VectorOfMat vm = new VectorOfMat();
            vm.Push(channel[0]);
            CvInvoke.Merge(vm, img);*/

            return channel.Convert<Bgr, byte>();
        }

        private void getChannelButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                ButtonVisibleFalse();
                blueChannelButton.Visible = true;
                greenChannelButton.Visible = true;
                redChannelButton.Visible = true;
                backButton.Visible = true;
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void blueChannelButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                imageBox2.Image = GetChannel(_mainImg, 0).Resize(400, 360, Inter.Linear);
            }
        }

        private void greenChannelButton_Click_1(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                imageBox2.Image = GetChannel(_mainImg, 1).Resize(400, 360, Inter.Linear);
            }
        }

        private void redChannelButton_Click_1(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                imageBox2.Image = GetChannel(_mainImg, 2).Resize(400, 360, Inter.Linear);
            }
        }

        //Сложение для цвета
        private double AddColors(double fColor, double sColor)
        {
            if (fColor + sColor > 255)
            {
                return 255;
            }
            else if (fColor + sColor < 0)
            {
                return 0;
            }

            return fColor + sColor;
        }

        //Умножение для цвета
        private double MultiplyColors(double fColor, double sColor)
        {
            if (fColor * sColor > 255)
            {
                return 255;
            }
            else if (fColor * sColor < 0)
            {
                return 0;
            }

            return fColor * sColor;
        }

        //Вычитание для цвета
        private double subtractionColors(double fColor, double sColor)
        {
            if (fColor - sColor < 0)
            {
                return 0;
            }

            return fColor - sColor;
        }

        //Изменение яркости и контраста
        private Image<Bgr, byte> ChangeBrightnessСontrast(Image<Bgr, byte> img, double brightness, double contrast)
        {
            brightness = Convert.ToDouble(brightnessTrackBar.Value);
            contrast = Convert.ToDouble(contrastTrackBar.Value);

            var resultImg = new Image<Bgr, byte>(img.Size);

            for (int channel = 0; channel < resultImg.NumberOfChannels; channel++) 
            {
                for (int x = 0; x < resultImg.Width; x++)
                {
                    for (int y = 0; y < resultImg.Height; y++)
                    {
                        byte color = _mainImg.Data[y, x, channel];

                        color = Convert.ToByte(AddColors(color, brightness));
                        color = Convert.ToByte(MultiplyColors(color, contrast));

                        resultImg.Data[y, x, channel] = color;
                    }
                }
            }

            return resultImg;
        }

        private void brightnessContrastButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                ButtonVisibleFalse();
                BrightnessContrastDisplay();
                _choice = 5;

                label1.Text = "Яркость: " + brightnessTrackBar.Value.ToString();
                label2.Text = "Контраст: " + contrastTrackBar.Value.ToString();

                imageBox2.Image = ChangeBrightnessСontrast(_mainImg, brightnessTrackBar.Value, contrastTrackBar.Value).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void brightnessTrackBar_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Яркость: " + brightnessTrackBar.Value.ToString();

            if (_choice == 6)
            {
                imageBox3.Image = WatercolorFilter(_mainImg, _secondImg, numericUpDownOper1.Value, numericUpDownOper2.Value, brightnessTrackBar.Value, contrastTrackBar.Value).Resize(400, 360, Inter.Linear);
            }
            else
            { 
                imageBox2.Image = ChangeBrightnessСontrast(_mainImg, brightnessTrackBar.Value, contrastTrackBar.Value).Resize(400, 360, Inter.Linear);
            }
        }

        private void contrastTrackBar_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Контраст: " + contrastTrackBar.Value.ToString();

            if (_choice == 6)
            {
                imageBox3.Image = WatercolorFilter(_mainImg, _secondImg, numericUpDownOper1.Value, numericUpDownOper2.Value, brightnessTrackBar.Value, contrastTrackBar.Value).Resize(400, 360, Inter.Linear);
            }
            else
            {
                imageBox2.Image = ChangeBrightnessСontrast(_mainImg, brightnessTrackBar.Value, contrastTrackBar.Value).Resize(400, 360, Inter.Linear);
            }
        }

        //Черно-белое изображение
        private Image<Gray, byte> BlackWhite(Image<Bgr, byte> img)
        {
            var grayImg = new Image<Gray, byte>(img.Size);

            for (int x = 0; x < grayImg.Width; x++)
            {
                for (int y = 0; y < grayImg.Height; y++)
                {
                    grayImg.Data[y, x, 0] = Convert.ToByte(0.299 * img.Data[y, x, 2] 
                        + 0.587 * img.Data[y, x, 1] + 0.114 * img.Data[y, x, 0]);
                }
            }

            return grayImg;
        }

        private void blackWhiteButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                resetButton1.Visible = true;
                imageBox2.Image = BlackWhite(_mainImg).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Сепия
        private Image<Bgr, byte> Sepia(Image <Bgr, byte> img)
        {
            double k1 = 0.393, k2 = 0.769, k3 = 0.189, k4 = 0.349, k5 = 0.686, k6 = 0.168, k7 = 0.272, k8 = 0.534, k9 = 0.131, k10 = 0.99;
            var sepiaImg = new Image<Bgr, byte>(img.Size);
            bool isOverflow = true;

            while (isOverflow)
            {
                try
                {
                    for (int x = 0; x < sepiaImg.Width; x++)
                    {
                        for (int y = 0; y < sepiaImg.Height; y++)
                        {
                            sepiaImg.Data[y, x, 0] = Convert.ToByte(k7 * img.Data[y, x, 2] 
                                + k8 * img.Data[y, x, 1] + k9 * img.Data[y, x, 0]);
                            sepiaImg.Data[y, x, 1] = Convert.ToByte(k4 * img.Data[y, x, 2] 
                                + k5 * img.Data[y, x, 1] + k6 * img.Data[y, x, 0]);
                            sepiaImg.Data[y, x, 2] = Convert.ToByte(k1 * img.Data[y, x, 2] 
                                + k2 * img.Data[y, x, 1] + k3 * img.Data[y, x, 0]);
                        }
                    }

                    isOverflow = false;
                }
                catch (OverflowException)
                {
                    k1 *= k10; k2 *= k10; k3 *= k10; k4 *= k10; k5 *= k10; k6 *= k10; k7 *= k10; k8 *= k10; k9 *= k10;
                    isOverflow = true;
                }
            }

            return sepiaImg;
        }

        private void sepiaButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                resetButton1.Visible = true;
                imageBox2.Image = Sepia(_mainImg).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Логические операции
        private void operationsButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null && imageBox2.Image != null)
            {
                ButtonVisibleFalse();
                OperationsDisplay();
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Дополнение
        private Image<Bgr, byte> AdditionImages(Image<Bgr, byte> first, Image<Bgr,byte> second, decimal fcoef = 1, decimal scoef = 1)
        {
            double a = Convert.ToDouble(fcoef);
            double b = Convert.ToDouble(scoef);

            var secondImg = second.Resize(first.Width, first.Height, Inter.Linear);
            var img = new Image<Bgr, byte>(first.Size);

            for (int channel = 0; channel < first.NumberOfChannels; channel++)
            {
                for (int x = 0; x < first.Width; x++)
                {
                    for (int y = 0; y < first.Height; y++)
                    {
                        byte colorFirst = first.Data[y, x, channel];
                        byte colorSecond = secondImg.Data[y, x, channel];

                        img.Data[y, x, channel] = Convert.ToByte(AddColors(MultiplyColors(colorFirst, a), MultiplyColors(colorSecond, b)));
                    }
                }
            }

            return img;
        }

        private void additionButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null && imageBox2.Image != null)
            {
                _choice = 1;
                numericUpDownOper1.Visible = true;
                numericUpDownOper2.Visible = true;
                imageBox3.Image = AdditionImages(_mainImg, _secondImg, numericUpDownOper1.Value, numericUpDownOper2.Value).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
 
        }

        //Исключение
        private Image<Bgr, byte> SubtractionImages(Image<Bgr, byte> first, Image<Bgr, byte> second, decimal fcoef, decimal scoef)
        {
            double a = Convert.ToDouble(fcoef);
            double b = Convert.ToDouble(scoef);

            var secondImg = second.Resize(first.Width, first.Height, Inter.Linear);
            var img = new Image<Bgr, byte>(first.Size);

            for (int channel = 0; channel < first.NumberOfChannels; channel++)
            {
                for (int x = 0; x < first.Width; x++)
                {
                    for (int y = 0; y < first.Height; y++)
                    {
                        byte colorFirst = first.Data[y, x, channel];
                        byte colorSecond = secondImg.Data[y, x, channel];

                        img.Data[y, x, channel] = Convert.ToByte(subtractionColors(MultiplyColors(colorFirst, a), MultiplyColors(colorSecond, b)));
                    }
                }
            }

            return img;
        }

        private void subtractionButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null && imageBox2.Image != null)
            {
                _choice = 2;
                numericUpDownOper1.Visible = true;
                numericUpDownOper2.Visible = true;
                imageBox3.Image = SubtractionImages(_mainImg, _secondImg, numericUpDownOper1.Value, numericUpDownOper2.Value).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Пересечение
        private Image<Bgr, byte> IntersectionImages(Image<Bgr, byte> first, Image<Bgr, byte> second, decimal fcoef = 1, decimal scoef = 1)
        {
            double a = Convert.ToDouble(fcoef);
            double b = Convert.ToDouble(scoef);

            var secondImg = second.Resize(first.Width, first.Height, Inter.Linear);
            var img = new Image<Bgr, byte>(first.Size);

            for (int channel = 0; channel < first.NumberOfChannels; channel++)
            {
                for (int x = 0; x < first.Width; x++)
                {
                    for (int y = 0; y < first.Height; y++)
                    {
                        byte colorFirst = first.Data[y, x, channel];
                        byte colorSecond = secondImg.Data[y, x, channel];

                        img.Data[y, x, channel] = Convert.ToByte(MultiplyColors(MultiplyColors(colorFirst, a), MultiplyColors(colorSecond, b)));
                    }
                }
            }

            return img;
        }

        private void intersectionButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null && imageBox2.Image != null)
            {
                _choice = 3;
                numericUpDownOper1.Visible = true;
                numericUpDownOper2.Visible = true;
                imageBox3.Image = IntersectionImages(_mainImg, _secondImg,numericUpDownOper1.Value, numericUpDownOper2.Value).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void numericUpDownOper1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownOper1.Value = 1 - numericUpDownOper2.Value;

            switch (_choice)
            {
                case 1: imageBox3.Image = AdditionImages(_mainImg, _secondImg, numericUpDownOper1.Value, numericUpDownOper2.Value).Resize(400, 360, Inter.Linear);
                    break;
                case 2: imageBox3.Image = SubtractionImages(_mainImg, _secondImg, numericUpDownOper1.Value, numericUpDownOper2.Value).Resize(400, 360, Inter.Linear);
                    break;
                case 3: imageBox3.Image = IntersectionImages(_mainImg, _secondImg, numericUpDownOper1.Value, numericUpDownOper2.Value).Resize(400, 360, Inter.Linear);
                    break;
                case 6: imageBox3.Image = WatercolorFilter(_mainImg, _secondImg, numericUpDownOper1.Value, numericUpDownOper2.Value, brightnessTrackBar.Value, contrastTrackBar.Value).Resize(400, 360, Inter.Linear);
                    break;
            }
        }

        private void numericUpDownOper2_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownOper2.Value = 1 - numericUpDownOper1.Value;

            switch (_choice)
            {
                case 1: imageBox3.Image = AdditionImages(_mainImg, _secondImg, numericUpDownOper1.Value, numericUpDownOper2.Value).Resize(400, 360, Inter.Linear);
                    break;
                case 2: imageBox3.Image = SubtractionImages(_mainImg, _secondImg, numericUpDownOper1.Value, numericUpDownOper2.Value).Resize(400, 360, Inter.Linear);
                    break;
                case 3: imageBox3.Image = IntersectionImages(_mainImg, _secondImg, numericUpDownOper1.Value, numericUpDownOper2.Value).Resize(400, 360, Inter.Linear);
                    break;
                case 6: imageBox3.Image = WatercolorFilter(_mainImg, _secondImg, numericUpDownOper1.Value, numericUpDownOper2.Value, brightnessTrackBar.Value, contrastTrackBar.Value).Resize(400, 360, Inter.Linear);
                    break;
            }
        }

        //Преобразование в HSV
        private Image<Bgr, byte> hsvFilter(Image<Bgr, byte> img, double h, double s, double v)
        {
            var hsvImg = img.Convert<Hsv, byte>();

            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    hsvImg.Data[y, x, 0] = Convert.ToByte(h);
                    hsvImg.Data[y, x, 1] = Convert.ToByte(AddColors(hsvImg.Data[y, x, 1], s));
                    hsvImg.Data[y, x, 2] = Convert.ToByte(AddColors(hsvImg.Data[y, x, 2], v));
                }
            }

            return hsvImg.Convert<Bgr, byte>();
        }

        private void hsvButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                hsvDisplay();
                _choice = 4;
                label3.Text = "hue: " + hueTrackBar.Value.ToString();
                label4.Text = "saturation: " + saturationTrackBar.Value.ToString();
                label5.Text = "value: " + valueTrackBar.Value.ToString();

                imageBox2.Image = hsvFilter(_mainImg, hueTrackBar.Value, saturationTrackBar.Value, valueTrackBar.Value).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void hueTrackBar_Scroll(object sender, EventArgs e)
        {
            label3.Text = "hue: " + hueTrackBar.Value.ToString();
            imageBox2.Image = hsvFilter(_mainImg, hueTrackBar.Value, saturationTrackBar.Value, valueTrackBar.Value).Resize(400, 360, Inter.Linear);
        }

        private void saturationTrackBar_Scroll(object sender, EventArgs e)
        {
            label4.Text = "saturation: " + saturationTrackBar.Value.ToString();
            imageBox2.Image = hsvFilter(_mainImg, hueTrackBar.Value, saturationTrackBar.Value, valueTrackBar.Value).Resize(400, 360, Inter.Linear);
        }

        private void valueTrackBar_Scroll(object sender, EventArgs e)
        {
            label5.Text = "value: " + valueTrackBar.Value.ToString();
            imageBox2.Image = hsvFilter(_mainImg, hueTrackBar.Value, saturationTrackBar.Value, valueTrackBar.Value).Resize(400, 360, Inter.Linear);
        }

        //Медианное размытие
        private Image<Bgr, byte> medianBlur(Image<Bgr, byte> img)
        {
            var resultImg = new Image<Bgr, byte>(img.Size);

            for(int channel = 0; channel < img.NumberOfChannels; channel++)
            {
                for(int x = 1; x < img.Width - 1; x++)
                {
                    for(int y = 1; y < img.Height - 1; y++)
                    {
                        List<int> window = new List<int>();

                        window.Add(img.Data[y - 1, x - 1, channel]);
                        window.Add(img.Data[y, x - 1, channel]);
                        window.Add(img.Data[y + 1, x - 1, channel]);
                        window.Add(img.Data[y + 1, x, channel]);
                        window.Add(img.Data[y, x, channel]);
                        window.Add(img.Data[y - 1, x, channel]);
                        window.Add(img.Data[y - 1, x + 1, channel]);
                        window.Add(img.Data[y, x + 1, channel]);
                        window.Add(img.Data[y + 1, x + 1, channel]);

                        window.Sort();
                        double color = window.Average(); //Среднее значение

                        resultImg.Data[y - 1, x - 1, channel] = Convert.ToByte(color);
                        resultImg.Data[y, x - 1, channel] = Convert.ToByte(color);
                        resultImg.Data[y + 1, x - 1, channel] = Convert.ToByte(color);
                        resultImg.Data[y + 1, x, channel] = Convert.ToByte(color);
                        resultImg.Data[y, x, channel] = Convert.ToByte(color);
                        resultImg.Data[y - 1, x, channel] = Convert.ToByte(color);
                        resultImg.Data[y - 1, x + 1, channel] = Convert.ToByte(color);
                        resultImg.Data[y, x + 1, channel] = Convert.ToByte(color);
                        resultImg.Data[y + 1, x + 1, channel] = Convert.ToByte(color);
                    }
                }
            }

            return resultImg;
        }

        private Image<Gray, byte> medianBlurGray(Image<Gray, byte> img)
        {
            var resultImg = new Image<Gray, byte>(img.Size);
            
            for (int x = 1; x < img.Width - 1; x++)
            {
                for (int y = 1; y < img.Height - 1; y++)
                {
                    List<int> window = new List<int>();

                    window.Add(img.Data[y - 1, x - 1, 0]);
                    window.Add(img.Data[y, x - 1, 0]);
                    window.Add(img.Data[y + 1, x - 1, 0]);
                    window.Add(img.Data[y + 1, x, 0]);
                    window.Add(img.Data[y, x, 0]);
                    window.Add(img.Data[y - 1, x, 0]);
                    window.Add(img.Data[y - 1, x + 1, 0]);
                    window.Add(img.Data[y, x + 1, 0]);
                    window.Add(img.Data[y + 1, x + 1, 0]);

                    window.Sort();
                    double color = window.Average(); //Среднее значение

                    resultImg.Data[y - 1, x - 1, 0] = Convert.ToByte(color);
                    resultImg.Data[y, x - 1, 0] = Convert.ToByte(color);
                    resultImg.Data[y + 1, x - 1, 0] = Convert.ToByte(color);
                    resultImg.Data[y + 1, x, 0] = Convert.ToByte(color);
                    resultImg.Data[y, x, 0] = Convert.ToByte(color);
                    resultImg.Data[y - 1, x, 0] = Convert.ToByte(color);
                    resultImg.Data[y - 1, x + 1, 0] = Convert.ToByte(color);
                    resultImg.Data[y, x + 1, 0] = Convert.ToByte(color);
                    resultImg.Data[y + 1, x + 1, 0] = Convert.ToByte(color);
                    }
                }

            return resultImg;
        }

        private void medianBlurButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                resetButton1.Visible = true;
                imageBox2.Image = medianBlur(_mainImg).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Оконный фильтр для повышения резкости
        private Image<Bgr, byte> WindowFilter(Image<Bgr, byte> img)
        {
            var resultImg = new Image<Bgr, byte>(img.Size);

            int[,] m = new int[3, 3] {
                {-1, -1, -1},
                {-1, 9, -1},
                {-1, -1, -1} 
            };

/*          int[,] m = new int[3, 3] {
                {-4, -2, 0},
                {-2, 1, 2},
                {0, -2, 4} 
            };*/

            for (int channel = 0; channel < img.NumberOfChannels; channel++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    for (int y = 0; y < img.Height; y++)
                    {
                        if (x == 0 || y == 0 || x == img.Size.Width - 1 || y == img.Size.Height - 1)
                        {
                            resultImg.Data[y, x, channel] = img.Data[y, x, channel];
                            continue;
                        }

                        int sumPix = 0;
                        int sumMat = 0;
                        double ratio;

                        for(int i = 0; i < 3; i++)
                        {
                            for(int j = 0; j < 3; j++)
                            {
                                sumPix += m[i, j] * img.Data[y + j - 1, x + i - 1, channel];
                                sumMat += m[i, j];
                            }
                        }

                        ratio = sumPix / sumMat;

                        if (ratio > 255)
                        {
                            ratio = 255;
                        }
                        else if (ratio < 0)
                        {
                            ratio = 0;
                        }

                        resultImg.Data[y, x, channel] = Convert.ToByte(ratio);
                    }
                }
            }

            return resultImg;
        }

        private void sharpenButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                resetButton1.Visible = true;
                imageBox2.Image = WindowFilter(_mainImg).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Акварельный фильтр
        private Image<Bgr,byte> WatercolorFilter(Image<Bgr,byte> img, Image<Bgr, byte> mask, decimal a, decimal b, int brightness, int contrast)
        {
            var resultImg = new Image<Bgr, byte>(img.Size);

            resultImg = ChangeBrightnessСontrast(img, brightness, contrast).Resize(400, 360, Inter.Linear);
            resultImg = medianBlur(resultImg).Resize(400, 360, Inter.Linear);
            resultImg = AdditionImages(resultImg, mask, a, b).Resize(400, 360, Inter.Linear);

            return resultImg;
        }

        private void watercolorButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null && imageBox2.Image != null)
            {
                _choice = 6;
                watercolorDisplay();
                imageBox3.Image = WatercolorFilter(_mainImg, _secondImg, numericUpDownOper1.Value, numericUpDownOper2.Value, brightnessTrackBar.Value, contrastTrackBar.Value).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите маску!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Cartoon фильтр
        private Image<Bgr, byte> CartoonFilter(Image<Bgr, byte> img, int a = 50, double b = 0.03)
        {
            var resultImg = BlackWhite(img);
            resultImg = medianBlurGray(resultImg);
            resultImg = Binarization(resultImg, a, b);

            return AdditionImages(img, resultImg.Convert<Bgr, byte>());
        }

        private Image<Gray, byte> Binarization(Image<Gray, byte> img, int a = 50, double b = 0.03)
        {
            var resultImg = img;
            resultImg = resultImg.ThresholdAdaptive(new Gray(a), AdaptiveThresholdType.MeanC, ThresholdType.Binary, 5, new Gray(b));

            return resultImg;
        }

        private void cartoonButton_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                ButtonVisibleFalse();
                cartoonNumericUpDown1.Visible = true;
                cartoonNumericUpDown2.Visible = true;
                resetButton1.Visible = true;
                backButton.Visible = true;
                imageBox2.Image = CartoonFilter(_mainImg).Resize(400, 360, Inter.Linear);
            }
            else
            {
                MessageBox.Show("Выберите изображение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cartoonNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            imageBox2.Image = CartoonFilter(_mainImg, Convert.ToInt32(cartoonNumericUpDown1.Value), Convert.ToDouble(cartoonNumericUpDown2.Value)).Resize(400, 360, Inter.Linear);
        }

        private void cartoonNumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            imageBox2.Image = CartoonFilter(_mainImg, Convert.ToInt32(cartoonNumericUpDown1.Value), Convert.ToDouble(cartoonNumericUpDown2.Value)).Resize(400, 360, Inter.Linear);
        }

        //Интерфейс
        private void OperationsDisplay()
        {
            resetButton2.Visible = true;
            backButton.Visible = true;
            additionButton.Visible = true;
            subtractionButton.Visible = true;
            intersectionButton.Visible = true;
            resetButton1.Visible = false;
        }


        private void BrightnessContrastDisplay()
        {
            resetButton2.Visible = true;
            backButton.Visible = true;
            brightnessTrackBar.Visible = true;
            contrastTrackBar.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
        }

        private void ButtonVisibleFalse()
        {
            blackWhiteButton.Visible = false;
            sepiaButton.Visible = false;
            hsvButton.Visible = false;
            operationsButton.Visible = false;
            brightnessContrastButton.Visible = false;
            getChannelButton.Visible = false;
            resetButton1.Visible = false;
            resetButton2.Visible = false;
            medianBlurButton.Visible = false;
            sharpenButton.Visible = false;
            watercolorButton.Visible = false;
            cartoonButton.Visible = false;
        }

        private void DefaultValues()
        {
            brightnessTrackBar.Value = 0;
            contrastTrackBar.Value = 1;

            hueTrackBar.Value = 150;
            saturationTrackBar.Value = 0;
            valueTrackBar.Value = 0;

            numericUpDownOper2.Value = 0.5m;
            numericUpDownOper1.Value = 0.5m;

            cartoonNumericUpDown1.Value = 50m;
            cartoonNumericUpDown2.Value = 0.03m;

            label1.Text = "Яркость: " + brightnessTrackBar.Value.ToString();
            label2.Text = "Контраст: " + contrastTrackBar.Value.ToString();

            label3.Text = "hue: " + hueTrackBar.Value.ToString();
            label4.Text = "saturation: " + saturationTrackBar.Value.ToString();
            label5.Text = "value: " + valueTrackBar.Value.ToString();
        }

        private void StartButtons()
        {
            blackWhiteButton.Visible = true;
            sepiaButton.Visible = true;
            getChannelButton.Visible = true;
            hsvButton.Visible = true;
            operationsButton.Visible = true;
            brightnessContrastButton.Visible = true;
            medianBlurButton.Visible = true;
            sharpenButton.Visible = true;
            watercolorButton.Visible = true;
            cartoonButton.Visible = true;
        }

        private void StartDisplay()
        {
            DefaultValues();
            //imageBox1.Image = null;
            imageBox2.Image = null;
            imageBox3.Image = null;

            blackWhiteButton.Visible = false;
            sepiaButton.Visible = false;
            hsvButton.Visible = false;

            getChannelButton.Visible = false;
            blueChannelButton.Visible = false;
            greenChannelButton.Visible = false;
            redChannelButton.Visible = false;

            operationsButton.Visible = false;
            additionButton.Visible = false;
            subtractionButton.Visible = false;
            intersectionButton.Visible = false;
            numericUpDownOper1.Visible = false;
            numericUpDownOper2.Visible = false;

            cartoonNumericUpDown1.Visible = false;
            cartoonNumericUpDown2.Visible = false;

            brightnessContrastButton.Visible = false;
            brightnessTrackBar.Visible = false;
            contrastTrackBar.Visible = false;
            label1.Visible = false;
            label2.Visible = false;

            hueTrackBar.Visible = false;
            saturationTrackBar.Visible = false;
            valueTrackBar.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;

            backButton.Visible = false;
            resetButton1.Visible = false;
            resetButton2.Visible = false;
        }

        private void hsvDisplay()
        {
            ButtonVisibleFalse();
            resetButton1.Visible = false;
            backButton.Visible = true;
            resetButton2.Visible = true;
            hueTrackBar.Visible = true;
            saturationTrackBar.Visible = true;
            valueTrackBar.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label3.Text = "hue: " + hueTrackBar.Value.ToString();
            label4.Text = "saturation: " + saturationTrackBar.Value.ToString();
            label5.Text = "value: " + valueTrackBar.Value.ToString();
        }

        private void watercolorDisplay()
        {
            numericUpDownOper1.Visible = true;
            numericUpDownOper2.Visible = true;
            brightnessTrackBar.Visible = true;
            contrastTrackBar.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            operationsButton.Visible = false;
            watercolorButton.Visible = false;
            resetButton2.Visible = true;
            resetButton1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
