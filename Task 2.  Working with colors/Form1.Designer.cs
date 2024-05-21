namespace MegaLABS
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.imageBox3 = new Emgu.CV.UI.ImageBox();
            this.loadButton1 = new System.Windows.Forms.Button();
            this.loadButton2 = new System.Windows.Forms.Button();
            this.blackWhiteButton = new System.Windows.Forms.Button();
            this.additionButton = new System.Windows.Forms.Button();
            this.sepiaButton = new System.Windows.Forms.Button();
            this.brightnessTrackBar = new System.Windows.Forms.TrackBar();
            this.blueChannelButton = new System.Windows.Forms.Button();
            this.getChannelButton = new System.Windows.Forms.Button();
            this.brightnessContrastButton = new System.Windows.Forms.Button();
            this.contrastTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.resetButton1 = new System.Windows.Forms.Button();
            this.greenChannelButton = new System.Windows.Forms.Button();
            this.redChannelButton = new System.Windows.Forms.Button();
            this.subtractionButton = new System.Windows.Forms.Button();
            this.intersectionButton = new System.Windows.Forms.Button();
            this.numericUpDownOper2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOper1 = new System.Windows.Forms.NumericUpDown();
            this.hsvButton = new System.Windows.Forms.Button();
            this.hueTrackBar = new System.Windows.Forms.TrackBar();
            this.saturationTrackBar = new System.Windows.Forms.TrackBar();
            this.valueTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.operationsButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.resetButton2 = new System.Windows.Forms.Button();
            this.medianBlurButton = new System.Windows.Forms.Button();
            this.sharpenButton = new System.Windows.Forms.Button();
            this.watercolorButton = new System.Windows.Forms.Button();
            this.cartoonButton = new System.Windows.Forms.Button();
            this.cartoonNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.cartoonNumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOper2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOper1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturationTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartoonNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartoonNumericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(12, 98);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(400, 360);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // imageBox2
            // 
            this.imageBox2.Location = new System.Drawing.Point(523, 98);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(400, 360);
            this.imageBox2.TabIndex = 2;
            this.imageBox2.TabStop = false;
            // 
            // imageBox3
            // 
            this.imageBox3.Location = new System.Drawing.Point(1058, 98);
            this.imageBox3.Name = "imageBox3";
            this.imageBox3.Size = new System.Drawing.Size(400, 360);
            this.imageBox3.TabIndex = 2;
            this.imageBox3.TabStop = false;
            // 
            // loadButton1
            // 
            this.loadButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadButton1.Location = new System.Drawing.Point(104, 24);
            this.loadButton1.Name = "loadButton1";
            this.loadButton1.Size = new System.Drawing.Size(194, 53);
            this.loadButton1.TabIndex = 3;
            this.loadButton1.Text = "Загрузить изображение";
            this.loadButton1.UseVisualStyleBackColor = true;
            this.loadButton1.Click += new System.EventHandler(this.loadButton1_Click);
            // 
            // loadButton2
            // 
            this.loadButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadButton2.Location = new System.Drawing.Point(639, 24);
            this.loadButton2.Name = "loadButton2";
            this.loadButton2.Size = new System.Drawing.Size(194, 53);
            this.loadButton2.TabIndex = 4;
            this.loadButton2.Text = "Загрузить доп. изображение";
            this.loadButton2.UseVisualStyleBackColor = true;
            this.loadButton2.Click += new System.EventHandler(this.loadButton2_Click);
            // 
            // blackWhiteButton
            // 
            this.blackWhiteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blackWhiteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.blackWhiteButton.Location = new System.Drawing.Point(645, 478);
            this.blackWhiteButton.Name = "blackWhiteButton";
            this.blackWhiteButton.Size = new System.Drawing.Size(169, 47);
            this.blackWhiteButton.TabIndex = 6;
            this.blackWhiteButton.Text = "Черно-белое изображение";
            this.blackWhiteButton.UseVisualStyleBackColor = true;
            this.blackWhiteButton.Click += new System.EventHandler(this.blackWhiteButton_Click);
            // 
            // additionButton
            // 
            this.additionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.additionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.additionButton.Location = new System.Drawing.Point(452, 478);
            this.additionButton.Name = "additionButton";
            this.additionButton.Size = new System.Drawing.Size(169, 47);
            this.additionButton.TabIndex = 7;
            this.additionButton.Text = "Дополнение";
            this.additionButton.UseVisualStyleBackColor = true;
            this.additionButton.Click += new System.EventHandler(this.additionButton_Click);
            // 
            // sepiaButton
            // 
            this.sepiaButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sepiaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sepiaButton.Location = new System.Drawing.Point(645, 537);
            this.sepiaButton.Name = "sepiaButton";
            this.sepiaButton.Size = new System.Drawing.Size(169, 47);
            this.sepiaButton.TabIndex = 8;
            this.sepiaButton.Text = "Сепия";
            this.sepiaButton.UseVisualStyleBackColor = true;
            this.sepiaButton.Click += new System.EventHandler(this.sepiaButton_Click);
            // 
            // brightnessTrackBar
            // 
            this.brightnessTrackBar.Location = new System.Drawing.Point(578, 497);
            this.brightnessTrackBar.Maximum = 50;
            this.brightnessTrackBar.Minimum = -50;
            this.brightnessTrackBar.Name = "brightnessTrackBar";
            this.brightnessTrackBar.Size = new System.Drawing.Size(255, 45);
            this.brightnessTrackBar.TabIndex = 9;
            this.brightnessTrackBar.TickFrequency = 5;
            this.brightnessTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.brightnessTrackBar.Scroll += new System.EventHandler(this.brightnessTrackBar_Scroll);
            // 
            // blueChannelButton
            // 
            this.blueChannelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blueChannelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.blueChannelButton.Location = new System.Drawing.Point(452, 478);
            this.blueChannelButton.Name = "blueChannelButton";
            this.blueChannelButton.Size = new System.Drawing.Size(169, 47);
            this.blueChannelButton.TabIndex = 10;
            this.blueChannelButton.Text = "Синий";
            this.blueChannelButton.UseVisualStyleBackColor = true;
            this.blueChannelButton.Click += new System.EventHandler(this.blueChannelButton_Click);
            // 
            // getChannelButton
            // 
            this.getChannelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.getChannelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.getChannelButton.Location = new System.Drawing.Point(645, 591);
            this.getChannelButton.Name = "getChannelButton";
            this.getChannelButton.Size = new System.Drawing.Size(169, 47);
            this.getChannelButton.TabIndex = 13;
            this.getChannelButton.Text = "Вывод цветового канала";
            this.getChannelButton.UseVisualStyleBackColor = true;
            this.getChannelButton.Click += new System.EventHandler(this.getChannelButton_Click);
            // 
            // brightnessContrastButton
            // 
            this.brightnessContrastButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brightnessContrastButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.brightnessContrastButton.Location = new System.Drawing.Point(839, 536);
            this.brightnessContrastButton.Name = "brightnessContrastButton";
            this.brightnessContrastButton.Size = new System.Drawing.Size(169, 49);
            this.brightnessContrastButton.TabIndex = 14;
            this.brightnessContrastButton.Text = "Изменить яркость / контраст";
            this.brightnessContrastButton.UseVisualStyleBackColor = true;
            this.brightnessContrastButton.Click += new System.EventHandler(this.brightnessContrastButton_Click);
            // 
            // contrastTrackBar
            // 
            this.contrastTrackBar.Location = new System.Drawing.Point(578, 578);
            this.contrastTrackBar.Name = "contrastTrackBar";
            this.contrastTrackBar.Size = new System.Drawing.Size(255, 45);
            this.contrastTrackBar.TabIndex = 15;
            this.contrastTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.contrastTrackBar.Value = 1;
            this.contrastTrackBar.Scroll += new System.EventHandler(this.contrastTrackBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(669, 476);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Яркость: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(663, 557);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Контраст: ";
            // 
            // resetButton1
            // 
            this.resetButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetButton1.Location = new System.Drawing.Point(929, 98);
            this.resetButton1.Name = "resetButton1";
            this.resetButton1.Size = new System.Drawing.Size(93, 37);
            this.resetButton1.TabIndex = 18;
            this.resetButton1.Text = "Сброс";
            this.resetButton1.UseVisualStyleBackColor = true;
            this.resetButton1.Click += new System.EventHandler(this.resetButton1_Click);
            // 
            // greenChannelButton
            // 
            this.greenChannelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.greenChannelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.greenChannelButton.Location = new System.Drawing.Point(645, 478);
            this.greenChannelButton.Name = "greenChannelButton";
            this.greenChannelButton.Size = new System.Drawing.Size(169, 47);
            this.greenChannelButton.TabIndex = 19;
            this.greenChannelButton.Text = "Зеленый";
            this.greenChannelButton.UseVisualStyleBackColor = true;
            this.greenChannelButton.Click += new System.EventHandler(this.greenChannelButton_Click_1);
            // 
            // redChannelButton
            // 
            this.redChannelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.redChannelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.redChannelButton.Location = new System.Drawing.Point(839, 478);
            this.redChannelButton.Name = "redChannelButton";
            this.redChannelButton.Size = new System.Drawing.Size(169, 47);
            this.redChannelButton.TabIndex = 20;
            this.redChannelButton.Text = "Красный";
            this.redChannelButton.UseVisualStyleBackColor = true;
            this.redChannelButton.Click += new System.EventHandler(this.redChannelButton_Click_1);
            // 
            // subtractionButton
            // 
            this.subtractionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.subtractionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.subtractionButton.Location = new System.Drawing.Point(839, 478);
            this.subtractionButton.Name = "subtractionButton";
            this.subtractionButton.Size = new System.Drawing.Size(169, 47);
            this.subtractionButton.TabIndex = 21;
            this.subtractionButton.Text = "Исключение";
            this.subtractionButton.UseVisualStyleBackColor = true;
            this.subtractionButton.Click += new System.EventHandler(this.subtractionButton_Click);
            // 
            // intersectionButton
            // 
            this.intersectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.intersectionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.intersectionButton.Location = new System.Drawing.Point(645, 478);
            this.intersectionButton.Name = "intersectionButton";
            this.intersectionButton.Size = new System.Drawing.Size(169, 47);
            this.intersectionButton.TabIndex = 22;
            this.intersectionButton.Text = "Пересечение";
            this.intersectionButton.UseVisualStyleBackColor = true;
            this.intersectionButton.Click += new System.EventHandler(this.intersectionButton_Click);
            // 
            // numericUpDownOper2
            // 
            this.numericUpDownOper2.DecimalPlaces = 1;
            this.numericUpDownOper2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownOper2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownOper2.Location = new System.Drawing.Point(1278, 478);
            this.numericUpDownOper2.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownOper2.Name = "numericUpDownOper2";
            this.numericUpDownOper2.Size = new System.Drawing.Size(64, 29);
            this.numericUpDownOper2.TabIndex = 23;
            this.numericUpDownOper2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownOper2.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownOper2.ValueChanged += new System.EventHandler(this.numericUpDownOper1_ValueChanged);
            // 
            // numericUpDownOper1
            // 
            this.numericUpDownOper1.DecimalPlaces = 1;
            this.numericUpDownOper1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownOper1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownOper1.Location = new System.Drawing.Point(1150, 478);
            this.numericUpDownOper1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownOper1.Name = "numericUpDownOper1";
            this.numericUpDownOper1.Size = new System.Drawing.Size(64, 29);
            this.numericUpDownOper1.TabIndex = 24;
            this.numericUpDownOper1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownOper1.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownOper1.ValueChanged += new System.EventHandler(this.numericUpDownOper2_ValueChanged);
            // 
            // hsvButton
            // 
            this.hsvButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hsvButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hsvButton.Location = new System.Drawing.Point(452, 591);
            this.hsvButton.Name = "hsvButton";
            this.hsvButton.Size = new System.Drawing.Size(169, 47);
            this.hsvButton.TabIndex = 25;
            this.hsvButton.Text = "Преобразовать в HSV";
            this.hsvButton.UseVisualStyleBackColor = true;
            this.hsvButton.Click += new System.EventHandler(this.hsvButton_Click);
            // 
            // hueTrackBar
            // 
            this.hueTrackBar.LargeChange = 10;
            this.hueTrackBar.Location = new System.Drawing.Point(578, 497);
            this.hueTrackBar.Maximum = 255;
            this.hueTrackBar.Name = "hueTrackBar";
            this.hueTrackBar.Size = new System.Drawing.Size(255, 45);
            this.hueTrackBar.TabIndex = 26;
            this.hueTrackBar.TickFrequency = 5;
            this.hueTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.hueTrackBar.Value = 150;
            this.hueTrackBar.Scroll += new System.EventHandler(this.hueTrackBar_Scroll);
            // 
            // saturationTrackBar
            // 
            this.saturationTrackBar.Location = new System.Drawing.Point(578, 566);
            this.saturationTrackBar.Maximum = 100;
            this.saturationTrackBar.Name = "saturationTrackBar";
            this.saturationTrackBar.Size = new System.Drawing.Size(255, 45);
            this.saturationTrackBar.TabIndex = 27;
            this.saturationTrackBar.TickFrequency = 5;
            this.saturationTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.saturationTrackBar.Scroll += new System.EventHandler(this.saturationTrackBar_Scroll);
            // 
            // valueTrackBar
            // 
            this.valueTrackBar.Location = new System.Drawing.Point(578, 635);
            this.valueTrackBar.Maximum = 100;
            this.valueTrackBar.Name = "valueTrackBar";
            this.valueTrackBar.Size = new System.Drawing.Size(255, 45);
            this.valueTrackBar.TabIndex = 28;
            this.valueTrackBar.TickFrequency = 5;
            this.valueTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.valueTrackBar.Scroll += new System.EventHandler(this.valueTrackBar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(690, 476);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 18);
            this.label3.TabIndex = 29;
            this.label3.Text = "hue: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(675, 545);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 18);
            this.label4.TabIndex = 30;
            this.label4.Text = "saturation: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(675, 614);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 18);
            this.label5.TabIndex = 31;
            this.label5.Text = "value: ";
            // 
            // operationsButton
            // 
            this.operationsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.operationsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operationsButton.Location = new System.Drawing.Point(452, 478);
            this.operationsButton.Name = "operationsButton";
            this.operationsButton.Size = new System.Drawing.Size(169, 47);
            this.operationsButton.TabIndex = 32;
            this.operationsButton.Text = "Логические операции";
            this.operationsButton.UseVisualStyleBackColor = true;
            this.operationsButton.Click += new System.EventHandler(this.operationsButton_Click);
            // 
            // backButton
            // 
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.Location = new System.Drawing.Point(839, 536);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(169, 48);
            this.backButton.TabIndex = 33;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // resetButton2
            // 
            this.resetButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetButton2.Location = new System.Drawing.Point(929, 98);
            this.resetButton2.Name = "resetButton2";
            this.resetButton2.Size = new System.Drawing.Size(93, 37);
            this.resetButton2.TabIndex = 34;
            this.resetButton2.Text = "Сброс";
            this.resetButton2.UseVisualStyleBackColor = true;
            this.resetButton2.Click += new System.EventHandler(this.resetButton2_Click);
            // 
            // medianBlurButton
            // 
            this.medianBlurButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.medianBlurButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.medianBlurButton.Location = new System.Drawing.Point(839, 591);
            this.medianBlurButton.Name = "medianBlurButton";
            this.medianBlurButton.Size = new System.Drawing.Size(169, 47);
            this.medianBlurButton.TabIndex = 35;
            this.medianBlurButton.Text = "Медианное размытие";
            this.medianBlurButton.UseVisualStyleBackColor = true;
            this.medianBlurButton.Click += new System.EventHandler(this.medianBlurButton_Click);
            // 
            // sharpenButton
            // 
            this.sharpenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sharpenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sharpenButton.Location = new System.Drawing.Point(452, 537);
            this.sharpenButton.Name = "sharpenButton";
            this.sharpenButton.Size = new System.Drawing.Size(169, 47);
            this.sharpenButton.TabIndex = 36;
            this.sharpenButton.Text = "Повышение резкости";
            this.sharpenButton.UseVisualStyleBackColor = true;
            this.sharpenButton.Click += new System.EventHandler(this.sharpenButton_Click);
            // 
            // watercolorButton
            // 
            this.watercolorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.watercolorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.watercolorButton.Location = new System.Drawing.Point(839, 478);
            this.watercolorButton.Name = "watercolorButton";
            this.watercolorButton.Size = new System.Drawing.Size(169, 47);
            this.watercolorButton.TabIndex = 37;
            this.watercolorButton.Text = "Акварельный фильтр";
            this.watercolorButton.UseVisualStyleBackColor = true;
            this.watercolorButton.Click += new System.EventHandler(this.watercolorButton_Click);
            // 
            // cartoonButton
            // 
            this.cartoonButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cartoonButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cartoonButton.Location = new System.Drawing.Point(645, 653);
            this.cartoonButton.Name = "cartoonButton";
            this.cartoonButton.Size = new System.Drawing.Size(169, 47);
            this.cartoonButton.TabIndex = 38;
            this.cartoonButton.Text = "Cartoon фильтр";
            this.cartoonButton.UseVisualStyleBackColor = true;
            this.cartoonButton.Click += new System.EventHandler(this.cartoonButton_Click);
            // 
            // cartoonNumericUpDown1
            // 
            this.cartoonNumericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cartoonNumericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.cartoonNumericUpDown1.Location = new System.Drawing.Point(599, 474);
            this.cartoonNumericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.cartoonNumericUpDown1.Name = "cartoonNumericUpDown1";
            this.cartoonNumericUpDown1.Size = new System.Drawing.Size(64, 29);
            this.cartoonNumericUpDown1.TabIndex = 39;
            this.cartoonNumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cartoonNumericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.cartoonNumericUpDown1.ValueChanged += new System.EventHandler(this.cartoonNumericUpDown1_ValueChanged);
            // 
            // cartoonNumericUpDown2
            // 
            this.cartoonNumericUpDown2.DecimalPlaces = 2;
            this.cartoonNumericUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cartoonNumericUpDown2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.cartoonNumericUpDown2.Location = new System.Drawing.Point(769, 474);
            this.cartoonNumericUpDown2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.cartoonNumericUpDown2.Name = "cartoonNumericUpDown2";
            this.cartoonNumericUpDown2.Size = new System.Drawing.Size(64, 29);
            this.cartoonNumericUpDown2.TabIndex = 40;
            this.cartoonNumericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cartoonNumericUpDown2.Value = new decimal(new int[] {
            3,
            0,
            0,
            131072});
            this.cartoonNumericUpDown2.ValueChanged += new System.EventHandler(this.cartoonNumericUpDown2_ValueChanged);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1470, 712);
            this.Controls.Add(this.cartoonNumericUpDown2);
            this.Controls.Add(this.cartoonNumericUpDown1);
            this.Controls.Add(this.cartoonButton);
            this.Controls.Add(this.watercolorButton);
            this.Controls.Add(this.sharpenButton);
            this.Controls.Add(this.medianBlurButton);
            this.Controls.Add(this.resetButton2);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.operationsButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.valueTrackBar);
            this.Controls.Add(this.saturationTrackBar);
            this.Controls.Add(this.hueTrackBar);
            this.Controls.Add(this.hsvButton);
            this.Controls.Add(this.numericUpDownOper1);
            this.Controls.Add(this.numericUpDownOper2);
            this.Controls.Add(this.intersectionButton);
            this.Controls.Add(this.subtractionButton);
            this.Controls.Add(this.redChannelButton);
            this.Controls.Add(this.greenChannelButton);
            this.Controls.Add(this.resetButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contrastTrackBar);
            this.Controls.Add(this.brightnessContrastButton);
            this.Controls.Add(this.getChannelButton);
            this.Controls.Add(this.blueChannelButton);
            this.Controls.Add(this.brightnessTrackBar);
            this.Controls.Add(this.sepiaButton);
            this.Controls.Add(this.additionButton);
            this.Controls.Add(this.blackWhiteButton);
            this.Controls.Add(this.loadButton2);
            this.Controls.Add(this.loadButton1);
            this.Controls.Add(this.imageBox3);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.imageBox1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOper2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOper1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturationTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartoonNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartoonNumericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private Emgu.CV.UI.ImageBox imageBox2;
        private Emgu.CV.UI.ImageBox imageBox3;
        private System.Windows.Forms.Button loadButton1;
        private System.Windows.Forms.Button loadButton2;
        private System.Windows.Forms.Button blackWhiteButton;
        private System.Windows.Forms.Button additionButton;
        private System.Windows.Forms.Button sepiaButton;
        private System.Windows.Forms.TrackBar brightnessTrackBar;
        private System.Windows.Forms.Button blueChannelButton;
        private System.Windows.Forms.Button getChannelButton;
        private System.Windows.Forms.Button brightnessContrastButton;
        private System.Windows.Forms.TrackBar contrastTrackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button resetButton1;
        private System.Windows.Forms.Button greenChannelButton;
        private System.Windows.Forms.Button redChannelButton;
        private System.Windows.Forms.Button subtractionButton;
        private System.Windows.Forms.Button intersectionButton;
        private System.Windows.Forms.NumericUpDown numericUpDownOper2;
        private System.Windows.Forms.NumericUpDown numericUpDownOper1;
        private System.Windows.Forms.Button hsvButton;
        private System.Windows.Forms.TrackBar hueTrackBar;
        private System.Windows.Forms.TrackBar saturationTrackBar;
        private System.Windows.Forms.TrackBar valueTrackBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button operationsButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button resetButton2;
        private System.Windows.Forms.Button medianBlurButton;
        private System.Windows.Forms.Button sharpenButton;
        private System.Windows.Forms.Button watercolorButton;
        private System.Windows.Forms.Button cartoonButton;
        private System.Windows.Forms.NumericUpDown cartoonNumericUpDown1;
        private System.Windows.Forms.NumericUpDown cartoonNumericUpDown2;
    }
}

