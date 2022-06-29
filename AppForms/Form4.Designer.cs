namespace IMGApp.AppForms
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_gauss = new System.Windows.Forms.Button();
            this.label_time = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label_progress = new System.Windows.Forms.Label();
            this.numeric_gauss_size = new System.Windows.Forms.NumericUpDown();
            this.numeric_gauss_sigma = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_custom = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numeric_custom_width = new System.Windows.Forms.NumericUpDown();
            this.numeric_custom_height = new System.Windows.Forms.NumericUpDown();
            this.custom_mask_Grid = new System.Windows.Forms.DataGridView();
            this.button_median = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gauss_size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gauss_sigma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_custom_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_custom_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custom_mask_Grid)).BeginInit();
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
            // button_gauss
            // 
            this.button_gauss.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button_gauss.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button_gauss.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_gauss.Location = new System.Drawing.Point(815, 20);
            this.button_gauss.Name = "button_gauss";
            this.button_gauss.Size = new System.Drawing.Size(113, 96);
            this.button_gauss.TabIndex = 1;
            this.button_gauss.Text = "Gauss";
            this.button_gauss.UseVisualStyleBackColor = true;
            this.button_gauss.Click += new System.EventHandler(this.button_gauss_Click);
            // 
            // label_time
            // 
            this.label_time.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_time.Location = new System.Drawing.Point(793, 647);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(434, 32);
            this.label_time.TabIndex = 2;
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
            3,
            0,
            0,
            0});
            this.numeric_gauss_size.Name = "numeric_gauss_size";
            this.numeric_gauss_size.Size = new System.Drawing.Size(73, 27);
            this.numeric_gauss_size.TabIndex = 6;
            this.numeric_gauss_size.Value = new decimal(new int[] {
            3,
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
            // button_custom
            // 
            this.button_custom.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_custom.Location = new System.Drawing.Point(815, 149);
            this.button_custom.Name = "button_custom";
            this.button_custom.Size = new System.Drawing.Size(113, 65);
            this.button_custom.TabIndex = 10;
            this.button_custom.Text = "Custom mask";
            this.button_custom.UseVisualStyleBackColor = true;
            this.button_custom.Click += new System.EventHandler(this.button_custom_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(934, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ширина:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(939, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Высота:";
            // 
            // numeric_custom_width
            // 
            this.numeric_custom_width.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numeric_custom_width.Location = new System.Drawing.Point(1015, 149);
            this.numeric_custom_width.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numeric_custom_width.Name = "numeric_custom_width";
            this.numeric_custom_width.Size = new System.Drawing.Size(64, 27);
            this.numeric_custom_width.TabIndex = 13;
            this.numeric_custom_width.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numeric_custom_width.ValueChanged += new System.EventHandler(this.numeric_custom_width_ValueChanged);
            // 
            // numeric_custom_height
            // 
            this.numeric_custom_height.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numeric_custom_height.Location = new System.Drawing.Point(1015, 182);
            this.numeric_custom_height.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numeric_custom_height.Name = "numeric_custom_height";
            this.numeric_custom_height.Size = new System.Drawing.Size(64, 27);
            this.numeric_custom_height.TabIndex = 14;
            this.numeric_custom_height.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numeric_custom_height.ValueChanged += new System.EventHandler(this.numeric_custom_height_ValueChanged);
            // 
            // custom_mask_Grid
            // 
            this.custom_mask_Grid.AllowUserToAddRows = false;
            this.custom_mask_Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.custom_mask_Grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.custom_mask_Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.custom_mask_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.custom_mask_Grid.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = "0";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.custom_mask_Grid.DefaultCellStyle = dataGridViewCellStyle1;
            this.custom_mask_Grid.GridColor = System.Drawing.SystemColors.ControlLight;
            this.custom_mask_Grid.Location = new System.Drawing.Point(815, 229);
            this.custom_mask_Grid.Name = "custom_mask_Grid";
            this.custom_mask_Grid.RowHeadersVisible = false;
            this.custom_mask_Grid.RowHeadersWidth = 25;
            this.custom_mask_Grid.RowTemplate.Height = 25;
            this.custom_mask_Grid.Size = new System.Drawing.Size(410, 201);
            this.custom_mask_Grid.TabIndex = 15;
            // 
            // button_median
            // 
            this.button_median.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_median.Location = new System.Drawing.Point(1104, 148);
            this.button_median.Name = "button_median";
            this.button_median.Size = new System.Drawing.Size(113, 65);
            this.button_median.TabIndex = 16;
            this.button_median.Text = "Median";
            this.button_median.UseVisualStyleBackColor = true;
            this.button_median.Click += new System.EventHandler(this.button_median_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 803);
            this.Controls.Add(this.button_median);
            this.Controls.Add(this.custom_mask_Grid);
            this.Controls.Add(this.numeric_custom_height);
            this.Controls.Add(this.numeric_custom_width);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_custom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numeric_gauss_sigma);
            this.Controls.Add(this.numeric_gauss_size);
            this.Controls.Add(this.label_progress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.button_gauss);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gauss_size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gauss_sigma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_custom_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_custom_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custom_mask_Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_gauss;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label_progress;
        private System.Windows.Forms.NumericUpDown numeric_gauss_size;
        private System.Windows.Forms.NumericUpDown numeric_gauss_sigma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_custom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numeric_custom_width;
        private System.Windows.Forms.NumericUpDown numeric_custom_height;
        private System.Windows.Forms.DataGridView custom_mask_Grid;
        private System.Windows.Forms.Button button_median;
    }
}