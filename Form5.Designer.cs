namespace IMGApp
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox_fourier = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.numeric_fourier_brightness = new System.Windows.Forms.NumericUpDown();
            this.label_fourier_brightness = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fourier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_fourier_brightness)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(638, 606);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(917, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox_fourier
            // 
            this.pictureBox_fourier.Location = new System.Drawing.Point(671, 452);
            this.pictureBox_fourier.Name = "pictureBox_fourier";
            this.pictureBox_fourier.Size = new System.Drawing.Size(575, 569);
            this.pictureBox_fourier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_fourier.TabIndex = 2;
            this.pictureBox_fourier.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(1271, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(619, 614);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // numeric_fourier_brightness
            // 
            this.numeric_fourier_brightness.Location = new System.Drawing.Point(861, 405);
            this.numeric_fourier_brightness.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numeric_fourier_brightness.Name = "numeric_fourier_brightness";
            this.numeric_fourier_brightness.Size = new System.Drawing.Size(89, 27);
            this.numeric_fourier_brightness.TabIndex = 4;
            this.numeric_fourier_brightness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_fourier_brightness.ValueChanged += new System.EventHandler(this.numeric_fourier_brightness_ValueChanged);
            // 
            // label_fourier_brightness
            // 
            this.label_fourier_brightness.AutoSize = true;
            this.label_fourier_brightness.Location = new System.Drawing.Point(671, 392);
            this.label_fourier_brightness.Name = "label_fourier_brightness";
            this.label_fourier_brightness.Size = new System.Drawing.Size(168, 40);
            this.label_fourier_brightness.TabIndex = 5;
            this.label_fourier_brightness.Text = "Яркость изображения \r\nобраза фурье";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.label_fourier_brightness);
            this.Controls.Add(this.numeric_fourier_brightness);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox_fourier);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form5";
            this.Text = "Form5";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fourier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_fourier_brightness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox_fourier;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.NumericUpDown numeric_fourier_brightness;
        private System.Windows.Forms.Label label_fourier_brightness;
    }
}