
namespace IMGApp
{
    partial class Form3
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
            this.buttonGavr = new System.Windows.Forms.Button();
            this.buttonOtsu = new System.Windows.Forms.Button();
            this.buttonNiblack = new System.Windows.Forms.Button();
            this.buttonSauvola = new System.Windows.Forms.Button();
            this.buttonWolf = new System.Windows.Forms.Button();
            this.buttonBradley = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(10, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(602, 518);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // buttonGavr
            // 
            this.buttonGavr.Location = new System.Drawing.Point(634, 23);
            this.buttonGavr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGavr.Name = "buttonGavr";
            this.buttonGavr.Size = new System.Drawing.Size(82, 22);
            this.buttonGavr.TabIndex = 1;
            this.buttonGavr.Text = "Gavrilov";
            this.buttonGavr.UseVisualStyleBackColor = true;
            this.buttonGavr.Click += new System.EventHandler(this.buttonGavr_Click);
            // 
            // buttonOtsu
            // 
            this.buttonOtsu.Location = new System.Drawing.Point(634, 62);
            this.buttonOtsu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOtsu.Name = "buttonOtsu";
            this.buttonOtsu.Size = new System.Drawing.Size(82, 22);
            this.buttonOtsu.TabIndex = 2;
            this.buttonOtsu.Text = "Otsu";
            this.buttonOtsu.UseVisualStyleBackColor = true;
            this.buttonOtsu.Click += new System.EventHandler(this.buttonOtsu_Click);
            // 
            // buttonNiblack
            // 
            this.buttonNiblack.Location = new System.Drawing.Point(634, 106);
            this.buttonNiblack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonNiblack.Name = "buttonNiblack";
            this.buttonNiblack.Size = new System.Drawing.Size(82, 22);
            this.buttonNiblack.TabIndex = 3;
            this.buttonNiblack.Text = "Niblack";
            this.buttonNiblack.UseVisualStyleBackColor = true;
            this.buttonNiblack.Click += new System.EventHandler(this.buttonNiblack_Click);
            // 
            // buttonSauvola
            // 
            this.buttonSauvola.Location = new System.Drawing.Point(634, 142);
            this.buttonSauvola.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSauvola.Name = "buttonSauvola";
            this.buttonSauvola.Size = new System.Drawing.Size(82, 22);
            this.buttonSauvola.TabIndex = 4;
            this.buttonSauvola.Text = "Sauvola";
            this.buttonSauvola.UseVisualStyleBackColor = true;
            this.buttonSauvola.Click += new System.EventHandler(this.buttonSauvola_Click);
            // 
            // buttonWolf
            // 
            this.buttonWolf.Location = new System.Drawing.Point(634, 184);
            this.buttonWolf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonWolf.Name = "buttonWolf";
            this.buttonWolf.Size = new System.Drawing.Size(82, 22);
            this.buttonWolf.TabIndex = 5;
            this.buttonWolf.Text = "Wolf";
            this.buttonWolf.UseVisualStyleBackColor = true;
            this.buttonWolf.Click += new System.EventHandler(this.buttonWolf_Click);
            // 
            // buttonBradley
            // 
            this.buttonBradley.Location = new System.Drawing.Point(634, 228);
            this.buttonBradley.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBradley.Name = "buttonBradley";
            this.buttonBradley.Size = new System.Drawing.Size(82, 22);
            this.buttonBradley.TabIndex = 6;
            this.buttonBradley.Text = "Bradley";
            this.buttonBradley.UseVisualStyleBackColor = true;
            this.buttonBradley.Click += new System.EventHandler(this.buttonBradley_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(736, 9);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(607, 518);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 532);
            this.progressBar1.Maximum = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1331, 52);
            this.progressBar1.TabIndex = 8;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 665);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.buttonBradley);
            this.Controls.Add(this.buttonWolf);
            this.Controls.Add(this.buttonSauvola);
            this.Controls.Add(this.buttonNiblack);
            this.Controls.Add(this.buttonOtsu);
            this.Controls.Add(this.buttonGavr);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonGavr;
        private System.Windows.Forms.Button buttonOtsu;
        private System.Windows.Forms.Button buttonNiblack;
        private System.Windows.Forms.Button buttonSauvola;
        private System.Windows.Forms.Button buttonWolf;
        private System.Windows.Forms.Button buttonBradley;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}