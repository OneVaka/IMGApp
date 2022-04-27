namespace IMGApp
{
    partial class Form4
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
            this.label_time = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label_progress = new System.Windows.Forms.Label();
            this.numeric_gauss_size = new System.Windows.Forms.NumericUpDown();
            this.numeric_gauss_sigma = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gauss_size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gauss_sigma)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(775, 760);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(815, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 96);
            this.button1.TabIndex = 1;
            this.button1.Text = "Gauss";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_time
            // 
            this.label_time.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_time.Location = new System.Drawing.Point(793, 647);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(434, 32);
            this.label_time.TabIndex = 2;
            this.label_time.Click += new System.EventHandler(this.label1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(793, 743);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(434, 29);
            this.progressBar1.TabIndex = 4;
            // 
            // label_progress
            // 
            this.label_progress.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_progress.Location = new System.Drawing.Point(793, 712);
            this.label_progress.Name = "label_progress";
            this.label_progress.Size = new System.Drawing.Size(434, 28);
            this.label_progress.TabIndex = 5;
            this.label_progress.Text = "Waiting for command...";
            // 
            // numeric_gauss_size
            // 
            this.numeric_gauss_size.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numeric_gauss_size.Location = new System.Drawing.Point(1089, 37);
            this.numeric_gauss_size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_gauss_size.Name = "numeric_gauss_size";
            this.numeric_gauss_size.Size = new System.Drawing.Size(73, 27);
            this.numeric_gauss_size.TabIndex = 6;
            this.numeric_gauss_size.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numeric_gauss_sigma
            // 
            this.numeric_gauss_sigma.Location = new System.Drawing.Point(1089, 89);
            this.numeric_gauss_sigma.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_gauss_sigma.Name = "numeric_gauss_sigma";
            this.numeric_gauss_sigma.Size = new System.Drawing.Size(73, 27);
            this.numeric_gauss_sigma.TabIndex = 7;
            this.numeric_gauss_sigma.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(934, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 46);
            this.label1.TabIndex = 8;
            this.label1.Text = "Размерность \r\nматрицы Гаусса";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(934, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 46);
            this.label2.TabIndex = 9;
            this.label2.Text = "Сигма\r\nуравнения Гаусса";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 803);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numeric_gauss_sigma);
            this.Controls.Add(this.numeric_gauss_size);
            this.Controls.Add(this.label_progress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form4";
            this.Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gauss_size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gauss_sigma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label_progress;
        private System.Windows.Forms.NumericUpDown numeric_gauss_size;
        private System.Windows.Forms.NumericUpDown numeric_gauss_sigma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}