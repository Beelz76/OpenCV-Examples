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
            this.scalingTrackBarX = new System.Windows.Forms.TrackBar();
            this.scalingTrackBarY = new System.Windows.Forms.TrackBar();
            this.scalingLabelX = new System.Windows.Forms.Label();
            this.scalingLabelY = new System.Windows.Forms.Label();
            this.scalingButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.shearingButton = new System.Windows.Forms.Button();
            this.shiftTrackBar = new System.Windows.Forms.TrackBar();
            this.shiftLabel = new System.Windows.Forms.Label();
            this.shearingButtonHorizontal = new System.Windows.Forms.Button();
            this.shearingButtonVertical = new System.Windows.Forms.Button();
            this.rotateButton = new System.Windows.Forms.Button();
            this.rotateLeftTopButton = new System.Windows.Forms.Button();
            this.rotateRightTopButton = new System.Windows.Forms.Button();
            this.rotateLeftBottomButton = new System.Windows.Forms.Button();
            this.rotateRightBottomButton = new System.Windows.Forms.Button();
            this.rotateLabel = new System.Windows.Forms.Label();
            this.rotateTrackBar = new System.Windows.Forms.TrackBar();
            this.reflectionButton = new System.Windows.Forms.Button();
            this.reflectionButtonVertical = new System.Windows.Forms.Button();
            this.reflectionButtonHorizontal = new System.Windows.Forms.Button();
            this.projectionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scalingTrackBarX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scalingTrackBarY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // loadButton1
            // 
            this.loadButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadButton1.Location = new System.Drawing.Point(567, 24);
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
            this.imageBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imageBox1_MouseClick);
            // 
            // imageBox2
            // 
            this.imageBox2.Location = new System.Drawing.Point(728, 104);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(400, 360);
            this.imageBox2.TabIndex = 3;
            this.imageBox2.TabStop = false;
            // 
            // scalingTrackBarX
            // 
            this.scalingTrackBarX.LargeChange = 1;
            this.scalingTrackBarX.Location = new System.Drawing.Point(728, 504);
            this.scalingTrackBarX.Maximum = 20;
            this.scalingTrackBarX.Minimum = 1;
            this.scalingTrackBarX.Name = "scalingTrackBarX";
            this.scalingTrackBarX.Size = new System.Drawing.Size(159, 45);
            this.scalingTrackBarX.TabIndex = 1;
            this.scalingTrackBarX.TickFrequency = 2;
            this.scalingTrackBarX.TickStyle = System.Windows.Forms.TickStyle.None;
            this.scalingTrackBarX.Value = 10;
            this.scalingTrackBarX.Scroll += new System.EventHandler(this.scalingTrackBarX_Scroll);
            // 
            // scalingTrackBarY
            // 
            this.scalingTrackBarY.LargeChange = 1;
            this.scalingTrackBarY.Location = new System.Drawing.Point(971, 501);
            this.scalingTrackBarY.Maximum = 20;
            this.scalingTrackBarY.Minimum = 1;
            this.scalingTrackBarY.Name = "scalingTrackBarY";
            this.scalingTrackBarY.Size = new System.Drawing.Size(157, 45);
            this.scalingTrackBarY.TabIndex = 1;
            this.scalingTrackBarY.TickFrequency = 2;
            this.scalingTrackBarY.TickStyle = System.Windows.Forms.TickStyle.None;
            this.scalingTrackBarY.Value = 10;
            this.scalingTrackBarY.Scroll += new System.EventHandler(this.scalingTrackBarY_Scroll);
            // 
            // scalingLabelX
            // 
            this.scalingLabelX.AutoSize = true;
            this.scalingLabelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scalingLabelX.Location = new System.Drawing.Point(794, 483);
            this.scalingLabelX.Name = "scalingLabelX";
            this.scalingLabelX.Size = new System.Drawing.Size(22, 18);
            this.scalingLabelX.TabIndex = 6;
            this.scalingLabelX.Text = "X:";
            // 
            // scalingLabelY
            // 
            this.scalingLabelY.AutoSize = true;
            this.scalingLabelY.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scalingLabelY.Location = new System.Drawing.Point(1032, 480);
            this.scalingLabelY.Name = "scalingLabelY";
            this.scalingLabelY.Size = new System.Drawing.Size(25, 18);
            this.scalingLabelY.TabIndex = 7;
            this.scalingLabelY.Text = "Y: ";
            // 
            // scalingButton
            // 
            this.scalingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scalingButton.Location = new System.Drawing.Point(567, 104);
            this.scalingButton.Name = "scalingButton";
            this.scalingButton.Size = new System.Drawing.Size(139, 50);
            this.scalingButton.TabIndex = 8;
            this.scalingButton.Text = "Изменить масштаб";
            this.scalingButton.UseVisualStyleBackColor = true;
            this.scalingButton.Click += new System.EventHandler(this.scalingButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetButton.Location = new System.Drawing.Point(862, 48);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(139, 50);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "Назад";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // shearingButton
            // 
            this.shearingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shearingButton.Location = new System.Drawing.Point(567, 186);
            this.shearingButton.Name = "shearingButton";
            this.shearingButton.Size = new System.Drawing.Size(139, 50);
            this.shearingButton.TabIndex = 10;
            this.shearingButton.Text = "Сдвиг изображения";
            this.shearingButton.UseVisualStyleBackColor = true;
            this.shearingButton.Click += new System.EventHandler(this.shearingButton_Click);
            // 
            // shiftTrackBar
            // 
            this.shiftTrackBar.LargeChange = 1;
            this.shiftTrackBar.Location = new System.Drawing.Point(862, 504);
            this.shiftTrackBar.Maximum = 20;
            this.shiftTrackBar.Minimum = -20;
            this.shiftTrackBar.Name = "shiftTrackBar";
            this.shiftTrackBar.Size = new System.Drawing.Size(159, 45);
            this.shiftTrackBar.TabIndex = 1;
            this.shiftTrackBar.TickFrequency = 2;
            this.shiftTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.shiftTrackBar.Scroll += new System.EventHandler(this.shiftTrackBar_Scroll);
            // 
            // shiftLabel
            // 
            this.shiftLabel.AutoSize = true;
            this.shiftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shiftLabel.Location = new System.Drawing.Point(916, 483);
            this.shiftLabel.Name = "shiftLabel";
            this.shiftLabel.Size = new System.Drawing.Size(45, 18);
            this.shiftLabel.TabIndex = 12;
            this.shiftLabel.Text = "Shift: ";
            // 
            // shearingButtonHorizontal
            // 
            this.shearingButtonHorizontal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shearingButtonHorizontal.Location = new System.Drawing.Point(567, 195);
            this.shearingButtonHorizontal.Name = "shearingButtonHorizontal";
            this.shearingButtonHorizontal.Size = new System.Drawing.Size(139, 50);
            this.shearingButtonHorizontal.TabIndex = 14;
            this.shearingButtonHorizontal.Text = "Горизонтальный сдвиг";
            this.shearingButtonHorizontal.UseVisualStyleBackColor = true;
            this.shearingButtonHorizontal.Click += new System.EventHandler(this.shearingButtonHorizontal_Click);
            // 
            // shearingButtonVertical
            // 
            this.shearingButtonVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shearingButtonVertical.Location = new System.Drawing.Point(567, 261);
            this.shearingButtonVertical.Name = "shearingButtonVertical";
            this.shearingButtonVertical.Size = new System.Drawing.Size(139, 50);
            this.shearingButtonVertical.TabIndex = 17;
            this.shearingButtonVertical.Text = "Вертикальный сдвиг";
            this.shearingButtonVertical.UseVisualStyleBackColor = true;
            this.shearingButtonVertical.Click += new System.EventHandler(this.shearingButtonVertical_Click);
            // 
            // rotateButton
            // 
            this.rotateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotateButton.Location = new System.Drawing.Point(567, 272);
            this.rotateButton.Name = "rotateButton";
            this.rotateButton.Size = new System.Drawing.Size(139, 50);
            this.rotateButton.TabIndex = 18;
            this.rotateButton.Text = "Поворот изображения";
            this.rotateButton.UseVisualStyleBackColor = true;
            this.rotateButton.Click += new System.EventHandler(this.rotateButton_Click);
            // 
            // rotateLeftTopButton
            // 
            this.rotateLeftTopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotateLeftTopButton.Location = new System.Drawing.Point(567, 132);
            this.rotateLeftTopButton.Name = "rotateLeftTopButton";
            this.rotateLeftTopButton.Size = new System.Drawing.Size(139, 50);
            this.rotateLeftTopButton.TabIndex = 19;
            this.rotateLeftTopButton.Text = "Относительно левого верха";
            this.rotateLeftTopButton.UseVisualStyleBackColor = true;
            this.rotateLeftTopButton.Click += new System.EventHandler(this.rotateLeftTopButton_Click);
            // 
            // rotateRightTopButton
            // 
            this.rotateRightTopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotateRightTopButton.Location = new System.Drawing.Point(567, 205);
            this.rotateRightTopButton.Name = "rotateRightTopButton";
            this.rotateRightTopButton.Size = new System.Drawing.Size(139, 50);
            this.rotateRightTopButton.TabIndex = 20;
            this.rotateRightTopButton.Text = "Относительно правого верха";
            this.rotateRightTopButton.UseVisualStyleBackColor = true;
            this.rotateRightTopButton.Click += new System.EventHandler(this.rotateRightTopButton_Click);
            // 
            // rotateLeftBottomButton
            // 
            this.rotateLeftBottomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotateLeftBottomButton.Location = new System.Drawing.Point(567, 278);
            this.rotateLeftBottomButton.Name = "rotateLeftBottomButton";
            this.rotateLeftBottomButton.Size = new System.Drawing.Size(139, 50);
            this.rotateLeftBottomButton.TabIndex = 21;
            this.rotateLeftBottomButton.Text = "Относительно левого низа";
            this.rotateLeftBottomButton.UseVisualStyleBackColor = true;
            this.rotateLeftBottomButton.Click += new System.EventHandler(this.rotateLeftBottomButton_Click);
            // 
            // rotateRightBottomButton
            // 
            this.rotateRightBottomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotateRightBottomButton.Location = new System.Drawing.Point(567, 346);
            this.rotateRightBottomButton.Name = "rotateRightBottomButton";
            this.rotateRightBottomButton.Size = new System.Drawing.Size(139, 50);
            this.rotateRightBottomButton.TabIndex = 22;
            this.rotateRightBottomButton.Text = "Относительно правого низа";
            this.rotateRightBottomButton.UseVisualStyleBackColor = true;
            this.rotateRightBottomButton.Click += new System.EventHandler(this.rotateRightBottomButton_Click);
            // 
            // rotateLabel
            // 
            this.rotateLabel.AutoSize = true;
            this.rotateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotateLabel.Location = new System.Drawing.Point(900, 480);
            this.rotateLabel.Name = "rotateLabel";
            this.rotateLabel.Size = new System.Drawing.Size(52, 18);
            this.rotateLabel.TabIndex = 24;
            this.rotateLabel.Text = "Angle: ";
            // 
            // rotateTrackBar
            // 
            this.rotateTrackBar.Location = new System.Drawing.Point(822, 501);
            this.rotateTrackBar.Maximum = 360;
            this.rotateTrackBar.Minimum = -360;
            this.rotateTrackBar.Name = "rotateTrackBar";
            this.rotateTrackBar.Size = new System.Drawing.Size(208, 45);
            this.rotateTrackBar.SmallChange = 5;
            this.rotateTrackBar.TabIndex = 23;
            this.rotateTrackBar.TickFrequency = 10;
            this.rotateTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.rotateTrackBar.Scroll += new System.EventHandler(this.rotateTrackBar_Scroll);
            // 
            // reflectionButton
            // 
            this.reflectionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reflectionButton.Location = new System.Drawing.Point(567, 351);
            this.reflectionButton.Name = "reflectionButton";
            this.reflectionButton.Size = new System.Drawing.Size(139, 50);
            this.reflectionButton.TabIndex = 25;
            this.reflectionButton.Text = "Отражение изображения";
            this.reflectionButton.UseVisualStyleBackColor = true;
            this.reflectionButton.Click += new System.EventHandler(this.reflectionButton_Click);
            // 
            // reflectionButtonVertical
            // 
            this.reflectionButtonVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reflectionButtonVertical.Location = new System.Drawing.Point(567, 205);
            this.reflectionButtonVertical.Name = "reflectionButtonVertical";
            this.reflectionButtonVertical.Size = new System.Drawing.Size(139, 50);
            this.reflectionButtonVertical.TabIndex = 26;
            this.reflectionButtonVertical.Text = "Вертикальное отражение";
            this.reflectionButtonVertical.UseVisualStyleBackColor = true;
            this.reflectionButtonVertical.Click += new System.EventHandler(this.reflectionButtonVertical_Click);
            // 
            // reflectionButtonHorizontal
            // 
            this.reflectionButtonHorizontal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reflectionButtonHorizontal.Location = new System.Drawing.Point(567, 278);
            this.reflectionButtonHorizontal.Name = "reflectionButtonHorizontal";
            this.reflectionButtonHorizontal.Size = new System.Drawing.Size(139, 50);
            this.reflectionButtonHorizontal.TabIndex = 27;
            this.reflectionButtonHorizontal.Text = "Горизонтальное отражение";
            this.reflectionButtonHorizontal.UseVisualStyleBackColor = true;
            this.reflectionButtonHorizontal.Click += new System.EventHandler(this.reflectionButtonHorizontal_Click);
            // 
            // projectionButton
            // 
            this.projectionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.projectionButton.Location = new System.Drawing.Point(567, 424);
            this.projectionButton.Name = "projectionButton";
            this.projectionButton.Size = new System.Drawing.Size(139, 50);
            this.projectionButton.TabIndex = 30;
            this.projectionButton.Text = "Проекция изображения";
            this.projectionButton.UseVisualStyleBackColor = true;
            this.projectionButton.Click += new System.EventHandler(this.projectionButton_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1382, 646);
            this.Controls.Add(this.projectionButton);
            this.Controls.Add(this.reflectionButtonHorizontal);
            this.Controls.Add(this.reflectionButtonVertical);
            this.Controls.Add(this.reflectionButton);
            this.Controls.Add(this.rotateLabel);
            this.Controls.Add(this.rotateTrackBar);
            this.Controls.Add(this.rotateRightBottomButton);
            this.Controls.Add(this.rotateLeftBottomButton);
            this.Controls.Add(this.rotateRightTopButton);
            this.Controls.Add(this.rotateLeftTopButton);
            this.Controls.Add(this.rotateButton);
            this.Controls.Add(this.shearingButtonVertical);
            this.Controls.Add(this.shearingButtonHorizontal);
            this.Controls.Add(this.shiftLabel);
            this.Controls.Add(this.shiftTrackBar);
            this.Controls.Add(this.shearingButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.scalingButton);
            this.Controls.Add(this.scalingLabelY);
            this.Controls.Add(this.scalingLabelX);
            this.Controls.Add(this.scalingTrackBarY);
            this.Controls.Add(this.scalingTrackBarX);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.loadButton1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scalingTrackBarX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scalingTrackBarY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadButton1;
        private Emgu.CV.UI.ImageBox imageBox1;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.TrackBar scalingTrackBarX;
        private System.Windows.Forms.TrackBar scalingTrackBarY;
        private System.Windows.Forms.Label scalingLabelX;
        private System.Windows.Forms.Label scalingLabelY;
        private System.Windows.Forms.Button scalingButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button shearingButton;
        private System.Windows.Forms.TrackBar shiftTrackBar;
        private System.Windows.Forms.Label shiftLabel;
        private System.Windows.Forms.Button shearingButtonHorizontal;
        private System.Windows.Forms.Button shearingButtonVertical;
        private System.Windows.Forms.Button rotateButton;
        private System.Windows.Forms.Button rotateLeftTopButton;
        private System.Windows.Forms.Button rotateRightTopButton;
        private System.Windows.Forms.Button rotateLeftBottomButton;
        private System.Windows.Forms.Button rotateRightBottomButton;
        private System.Windows.Forms.Label rotateLabel;
        private System.Windows.Forms.TrackBar rotateTrackBar;
        private System.Windows.Forms.Button reflectionButton;
        private System.Windows.Forms.Button reflectionButtonVertical;
        private System.Windows.Forms.Button reflectionButtonHorizontal;
        private System.Windows.Forms.Button projectionButton;
    }
}

