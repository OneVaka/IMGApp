namespace IMGApp.AppForms
{
    partial class FormStart
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
            this.button_Form_Overlap = new System.Windows.Forms.Button();
            this.button_Form_Graph = new System.Windows.Forms.Button();
            this.button_Form_Binarization = new System.Windows.Forms.Button();
            this.button_Form_Masking = new System.Windows.Forms.Button();
            this.button_Form_Fourier = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Form_Overlap
            // 
            this.button_Form_Overlap.AutoSize = true;
            this.button_Form_Overlap.Location = new System.Drawing.Point(16, 44);
            this.button_Form_Overlap.Name = "button_Form_Overlap";
            this.button_Form_Overlap.Size = new System.Drawing.Size(94, 30);
            this.button_Form_Overlap.TabIndex = 0;
            this.button_Form_Overlap.Text = "Overlap";
            this.button_Form_Overlap.UseVisualStyleBackColor = true;
            this.button_Form_Overlap.Click += new System.EventHandler(this.button_Form_Overlap_Click);
            // 
            // button_Form_Graph
            // 
            this.button_Form_Graph.AutoSize = true;
            this.button_Form_Graph.Location = new System.Drawing.Point(16, 94);
            this.button_Form_Graph.Name = "button_Form_Graph";
            this.button_Form_Graph.Size = new System.Drawing.Size(134, 30);
            this.button_Form_Graph.TabIndex = 1;
            this.button_Form_Graph.Text = "Graph processing";
            this.button_Form_Graph.UseVisualStyleBackColor = true;
            this.button_Form_Graph.Click += new System.EventHandler(this.button_Form_Graph_Click);
            // 
            // button_Form_Binarization
            // 
            this.button_Form_Binarization.AutoSize = true;
            this.button_Form_Binarization.Location = new System.Drawing.Point(16, 150);
            this.button_Form_Binarization.Name = "button_Form_Binarization";
            this.button_Form_Binarization.Size = new System.Drawing.Size(98, 30);
            this.button_Form_Binarization.TabIndex = 2;
            this.button_Form_Binarization.Text = "Binarization";
            this.button_Form_Binarization.UseVisualStyleBackColor = true;
            this.button_Form_Binarization.Click += new System.EventHandler(this.button_Form_Binarization_Click);
            // 
            // button_Form_Masking
            // 
            this.button_Form_Masking.AutoSize = true;
            this.button_Form_Masking.Location = new System.Drawing.Point(16, 217);
            this.button_Form_Masking.Name = "button_Form_Masking";
            this.button_Form_Masking.Size = new System.Drawing.Size(128, 30);
            this.button_Form_Masking.TabIndex = 3;
            this.button_Form_Masking.Text = "Mask processing";
            this.button_Form_Masking.UseVisualStyleBackColor = true;
            this.button_Form_Masking.Click += new System.EventHandler(this.button_Form_Masking_Click);
            // 
            // button_Form_Fourier
            // 
            this.button_Form_Fourier.AutoSize = true;
            this.button_Form_Fourier.Location = new System.Drawing.Point(16, 277);
            this.button_Form_Fourier.Name = "button_Form_Fourier";
            this.button_Form_Fourier.Size = new System.Drawing.Size(133, 30);
            this.button_Form_Fourier.TabIndex = 4;
            this.button_Form_Fourier.Text = "Fourier transform";
            this.button_Form_Fourier.UseVisualStyleBackColor = true;
            this.button_Form_Fourier.Click += new System.EventHandler(this.button_Form_Fourier_Click);
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 817);
            this.Controls.Add(this.button_Form_Fourier);
            this.Controls.Add(this.button_Form_Masking);
            this.Controls.Add(this.button_Form_Binarization);
            this.Controls.Add(this.button_Form_Graph);
            this.Controls.Add(this.button_Form_Overlap);
            this.Name = "FormStart";
            this.Text = "FormStart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Form_Overlap;
        private System.Windows.Forms.Button button_Form_Graph;
        private System.Windows.Forms.Button button_Form_Binarization;
        private System.Windows.Forms.Button button_Form_Masking;
        private System.Windows.Forms.Button button_Form_Fourier;
    }
}