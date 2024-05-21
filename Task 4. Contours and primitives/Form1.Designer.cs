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
            this.loadButton1 = new System.Windows.Forms.Button();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.processingButton = new System.Windows.Forms.Button();
            this.contourButton = new System.Windows.Forms.Button();
            this.thresholdTrackBar = new System.Windows.Forms.TrackBar();
            this.thresholdLabel = new System.Windows.Forms.Label();
            this.primitivesButton = new System.Windows.Forms.Button();
            this.primitivesButtonTriagnel = new System.Windows.Forms.Button();
            this.minSquareLabel = new System.Windows.Forms.Label();
            this.minSquareTrackBar = new System.Windows.Forms.TrackBar();
            this.primitivesButtonRectangle = new System.Windows.Forms.Button();
            this.primitivesButtonCircle = new System.Windows.Forms.Button();
            this.minDistanceLabel = new System.Windows.Forms.Label();
            this.minDistanceTrackBar = new System.Windows.Forms.TrackBar();
            this.thresholdLabelCircle = new System.Windows.Forms.Label();
            this.thresholdTrackBarCircle = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minSquareTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minDistanceTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackBarCircle)).BeginInit();
            this.SuspendLayout();
            // 
            // loadButton1
            // 
            this.loadButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadButton1.Location = new System.Drawing.Point(578, 24);
            this.loadButton1.Name = "loadButton1";
            this.loadButton1.Size = new System.Drawing.Size(139, 50);
            this.loadButton1.TabIndex = 0;
            this.loadButton1.Text = "Загрузить изображение";
            this.loadButton1.UseVisualStyleBackColor = true;
            this.loadButton1.Click += new System.EventHandler(this.loadButton1_Click_1);
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(131, 104);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(400, 360);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            this.imageBox1.Click += new System.EventHandler(this.imageBox1_Click);
            // 
            // imageBox2
            // 
            this.imageBox2.Location = new System.Drawing.Point(758, 104);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(400, 360);
            this.imageBox2.TabIndex = 3;
            this.imageBox2.TabStop = false;
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetButton.Location = new System.Drawing.Point(902, 48);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(139, 50);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "Назад";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // processingButton
            // 
            this.processingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.processingButton.Location = new System.Drawing.Point(537, 104);
            this.processingButton.Name = "processingButton";
            this.processingButton.Size = new System.Drawing.Size(215, 48);
            this.processingButton.TabIndex = 10;
            this.processingButton.Text = "Предварительная обработка";
            this.processingButton.UseVisualStyleBackColor = true;
            this.processingButton.Click += new System.EventHandler(this.processingButton_Click);
            // 
            // contourButton
            // 
            this.contourButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.contourButton.Location = new System.Drawing.Point(537, 163);
            this.contourButton.Name = "contourButton";
            this.contourButton.Size = new System.Drawing.Size(215, 48);
            this.contourButton.TabIndex = 12;
            this.contourButton.Text = "Поиск контуров";
            this.contourButton.UseVisualStyleBackColor = true;
            this.contourButton.Click += new System.EventHandler(this.contourButton_Click);
            // 
            // thresholdTrackBar
            // 
            this.thresholdTrackBar.LargeChange = 1;
            this.thresholdTrackBar.Location = new System.Drawing.Point(787, 496);
            this.thresholdTrackBar.Maximum = 255;
            this.thresholdTrackBar.Name = "thresholdTrackBar";
            this.thresholdTrackBar.Size = new System.Drawing.Size(317, 45);
            this.thresholdTrackBar.TabIndex = 13;
            this.thresholdTrackBar.TickFrequency = 10;
            this.thresholdTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.thresholdTrackBar.Value = 50;
            this.thresholdTrackBar.Scroll += new System.EventHandler(this.thresholdTrackBar_Scroll);
            // 
            // thresholdLabel
            // 
            this.thresholdLabel.AutoSize = true;
            this.thresholdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.thresholdLabel.Location = new System.Drawing.Point(868, 475);
            this.thresholdLabel.Name = "thresholdLabel";
            this.thresholdLabel.Size = new System.Drawing.Size(161, 18);
            this.thresholdLabel.TabIndex = 14;
            this.thresholdLabel.Text = "Пороговое значение: ";
            // 
            // primitivesButton
            // 
            this.primitivesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.primitivesButton.Location = new System.Drawing.Point(537, 226);
            this.primitivesButton.Name = "primitivesButton";
            this.primitivesButton.Size = new System.Drawing.Size(215, 48);
            this.primitivesButton.TabIndex = 15;
            this.primitivesButton.Text = "Поиск аппроксимированных контуров";
            this.primitivesButton.UseVisualStyleBackColor = true;
            this.primitivesButton.Click += new System.EventHandler(this.primitivesButton_Click);
            // 
            // primitivesButtonTriagnel
            // 
            this.primitivesButtonTriagnel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.primitivesButtonTriagnel.Location = new System.Drawing.Point(537, 289);
            this.primitivesButtonTriagnel.Name = "primitivesButtonTriagnel";
            this.primitivesButtonTriagnel.Size = new System.Drawing.Size(215, 48);
            this.primitivesButtonTriagnel.TabIndex = 16;
            this.primitivesButtonTriagnel.Text = "Контуры треугольников";
            this.primitivesButtonTriagnel.UseVisualStyleBackColor = true;
            this.primitivesButtonTriagnel.Click += new System.EventHandler(this.primitivesButtonTriagnel_Click);
            // 
            // minSquareLabel
            // 
            this.minSquareLabel.AutoSize = true;
            this.minSquareLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minSquareLabel.Location = new System.Drawing.Point(824, 544);
            this.minSquareLabel.Name = "minSquareLabel";
            this.minSquareLabel.Size = new System.Drawing.Size(247, 18);
            this.minSquareLabel.TabIndex = 18;
            this.minSquareLabel.Text = "Минимальная площадь контуров: ";
            this.minSquareLabel.Click += new System.EventHandler(this.minSquareLabel_Click);
            // 
            // minSquareTrackBar
            // 
            this.minSquareTrackBar.LargeChange = 1;
            this.minSquareTrackBar.Location = new System.Drawing.Point(787, 565);
            this.minSquareTrackBar.Maximum = 1000;
            this.minSquareTrackBar.Name = "minSquareTrackBar";
            this.minSquareTrackBar.Size = new System.Drawing.Size(317, 45);
            this.minSquareTrackBar.TabIndex = 17;
            this.minSquareTrackBar.TickFrequency = 10;
            this.minSquareTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.minSquareTrackBar.Value = 200;
            this.minSquareTrackBar.Scroll += new System.EventHandler(this.minSquareTrackBar_Scroll);
            // 
            // primitivesButtonRectangle
            // 
            this.primitivesButtonRectangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.primitivesButtonRectangle.Location = new System.Drawing.Point(537, 352);
            this.primitivesButtonRectangle.Name = "primitivesButtonRectangle";
            this.primitivesButtonRectangle.Size = new System.Drawing.Size(215, 48);
            this.primitivesButtonRectangle.TabIndex = 19;
            this.primitivesButtonRectangle.Text = "Контуры четырехугольников";
            this.primitivesButtonRectangle.UseVisualStyleBackColor = true;
            this.primitivesButtonRectangle.Click += new System.EventHandler(this.primitivesButtonRectangle_Click);
            // 
            // primitivesButtonCircle
            // 
            this.primitivesButtonCircle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.primitivesButtonCircle.Location = new System.Drawing.Point(537, 416);
            this.primitivesButtonCircle.Name = "primitivesButtonCircle";
            this.primitivesButtonCircle.Size = new System.Drawing.Size(215, 48);
            this.primitivesButtonCircle.TabIndex = 20;
            this.primitivesButtonCircle.Text = "Контуры окружностей";
            this.primitivesButtonCircle.UseVisualStyleBackColor = true;
            this.primitivesButtonCircle.Click += new System.EventHandler(this.primitivesButtonCircle_Click);
            // 
            // minDistanceLabel
            // 
            this.minDistanceLabel.AutoSize = true;
            this.minDistanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minDistanceLabel.Location = new System.Drawing.Point(868, 481);
            this.minDistanceLabel.Name = "minDistanceLabel";
            this.minDistanceLabel.Size = new System.Drawing.Size(189, 18);
            this.minDistanceLabel.TabIndex = 22;
            this.minDistanceLabel.Text = "Минимальная дистанция: ";
            // 
            // minDistanceTrackBar
            // 
            this.minDistanceTrackBar.LargeChange = 1;
            this.minDistanceTrackBar.Location = new System.Drawing.Point(787, 502);
            this.minDistanceTrackBar.Maximum = 500;
            this.minDistanceTrackBar.Minimum = 1;
            this.minDistanceTrackBar.Name = "minDistanceTrackBar";
            this.minDistanceTrackBar.Size = new System.Drawing.Size(317, 45);
            this.minDistanceTrackBar.TabIndex = 21;
            this.minDistanceTrackBar.TickFrequency = 10;
            this.minDistanceTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.minDistanceTrackBar.Value = 250;
            this.minDistanceTrackBar.Scroll += new System.EventHandler(this.minDistanceTrackBar_Scroll);
            // 
            // thresholdLabelCircle
            // 
            this.thresholdLabelCircle.AutoSize = true;
            this.thresholdLabelCircle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.thresholdLabelCircle.Location = new System.Drawing.Point(868, 544);
            this.thresholdLabelCircle.Name = "thresholdLabelCircle";
            this.thresholdLabelCircle.Size = new System.Drawing.Size(153, 18);
            this.thresholdLabelCircle.TabIndex = 24;
            this.thresholdLabelCircle.Text = "Пороговое значение";
            // 
            // thresholdTrackBarCircle
            // 
            this.thresholdTrackBarCircle.LargeChange = 1;
            this.thresholdTrackBarCircle.Location = new System.Drawing.Point(787, 565);
            this.thresholdTrackBarCircle.Maximum = 300;
            this.thresholdTrackBarCircle.Name = "thresholdTrackBarCircle";
            this.thresholdTrackBarCircle.Size = new System.Drawing.Size(317, 45);
            this.thresholdTrackBarCircle.TabIndex = 23;
            this.thresholdTrackBarCircle.TickFrequency = 10;
            this.thresholdTrackBarCircle.TickStyle = System.Windows.Forms.TickStyle.None;
            this.thresholdTrackBarCircle.Value = 50;
            this.thresholdTrackBarCircle.Scroll += new System.EventHandler(this.thresholdTrackBarCircle_Scroll);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1382, 646);
            this.Controls.Add(this.thresholdLabelCircle);
            this.Controls.Add(this.thresholdTrackBarCircle);
            this.Controls.Add(this.minDistanceLabel);
            this.Controls.Add(this.minDistanceTrackBar);
            this.Controls.Add(this.primitivesButtonCircle);
            this.Controls.Add(this.primitivesButtonRectangle);
            this.Controls.Add(this.minSquareLabel);
            this.Controls.Add(this.minSquareTrackBar);
            this.Controls.Add(this.primitivesButtonTriagnel);
            this.Controls.Add(this.primitivesButton);
            this.Controls.Add(this.thresholdLabel);
            this.Controls.Add(this.thresholdTrackBar);
            this.Controls.Add(this.contourButton);
            this.Controls.Add(this.processingButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.loadButton1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minSquareTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minDistanceTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackBarCircle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadButton1;
        private Emgu.CV.UI.ImageBox imageBox1;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button processingButton;
        private System.Windows.Forms.Button contourButton;
        private System.Windows.Forms.TrackBar thresholdTrackBar;
        private System.Windows.Forms.Label thresholdLabel;
        private System.Windows.Forms.Button primitivesButton;
        private System.Windows.Forms.Button primitivesButtonTriagnel;
        private System.Windows.Forms.Label minSquareLabel;
        private System.Windows.Forms.TrackBar minSquareTrackBar;
        private System.Windows.Forms.Button primitivesButtonRectangle;
        private System.Windows.Forms.Button primitivesButtonCircle;
        private System.Windows.Forms.Label minDistanceLabel;
        private System.Windows.Forms.TrackBar minDistanceTrackBar;
        private System.Windows.Forms.Label thresholdLabelCircle;
        private System.Windows.Forms.TrackBar thresholdTrackBarCircle;
    }
}

