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
            this.resetButton = new System.Windows.Forms.Button();
            this.loadButton2 = new System.Windows.Forms.Button();
            this.webcamButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            this.SuspendLayout();
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
            // loadButton2
            // 
            this.loadButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadButton2.Location = new System.Drawing.Point(578, 31);
            this.loadButton2.Name = "loadButton2";
            this.loadButton2.Size = new System.Drawing.Size(139, 50);
            this.loadButton2.TabIndex = 12;
            this.loadButton2.Text = "Загрузить видео";
            this.loadButton2.UseVisualStyleBackColor = true;
            this.loadButton2.Click += new System.EventHandler(this.loadButton2_Click);
            // 
            // webcamButton
            // 
            this.webcamButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.webcamButton.Location = new System.Drawing.Point(578, 104);
            this.webcamButton.Name = "webcamButton";
            this.webcamButton.Size = new System.Drawing.Size(139, 50);
            this.webcamButton.TabIndex = 13;
            this.webcamButton.Text = "Веб-камера";
            this.webcamButton.UseVisualStyleBackColor = true;
            this.webcamButton.Click += new System.EventHandler(this.webcamButton_Click);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startButton.Location = new System.Drawing.Point(483, 487);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(139, 50);
            this.startButton.TabIndex = 14;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click_1);
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stopButton.Location = new System.Drawing.Point(666, 487);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(139, 50);
            this.stopButton.TabIndex = 15;
            this.stopButton.Text = "Стоп";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click_1);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1382, 646);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.webcamButton);
            this.Controls.Add(this.loadButton2);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.imageBox1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Emgu.CV.UI.ImageBox imageBox1;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button loadButton2;
        private System.Windows.Forms.Button webcamButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
    }
}

