
namespace IMGApp.AppForms
{
    partial class Form2
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
            this.pictureGist = new System.Windows.Forms.PictureBox();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.clearCanvasButton = new System.Windows.Forms.Button();
            this.interedButton = new System.Windows.Forms.Button();
            this.reverseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGist)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(14, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(737, 623);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureGist
            // 
            this.pictureGist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureGist.Location = new System.Drawing.Point(781, 16);
            this.pictureGist.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureGist.MaximumSize = new System.Drawing.Size(300, 256);
            this.pictureGist.MinimumSize = new System.Drawing.Size(300, 256);
            this.pictureGist.Name = "pictureGist";
            this.pictureGist.Size = new System.Drawing.Size(300, 256);
            this.pictureGist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureGist.TabIndex = 1;
            this.pictureGist.TabStop = false;
            // 
            // graphPanel
            // 
            this.graphPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphPanel.Location = new System.Drawing.Point(781, 317);
            this.graphPanel.MaximumSize = new System.Drawing.Size(255, 255);
            this.graphPanel.MinimumSize = new System.Drawing.Size(255, 255);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(255, 255);
            this.graphPanel.TabIndex = 2;
            // 
            // clearCanvasButton
            // 
            this.clearCanvasButton.Location = new System.Drawing.Point(1154, 317);
            this.clearCanvasButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clearCanvasButton.Name = "clearCanvasButton";
            this.clearCanvasButton.Size = new System.Drawing.Size(114, 52);
            this.clearCanvasButton.TabIndex = 3;
            this.clearCanvasButton.Text = "Очистить точки";
            this.clearCanvasButton.UseVisualStyleBackColor = true;
            this.clearCanvasButton.Click += new System.EventHandler(this.clearCanvasButton_Click);
            // 
            // interedButton
            // 
            this.interedButton.Location = new System.Drawing.Point(1181, 57);
            this.interedButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.interedButton.Name = "interedButton";
            this.interedButton.Size = new System.Drawing.Size(86, 31);
            this.interedButton.TabIndex = 4;
            this.interedButton.Text = "intered";
            this.interedButton.UseVisualStyleBackColor = true;
            this.interedButton.Click += new System.EventHandler(this.interedButton_Click);
            // 
            // reverseButton
            // 
            this.reverseButton.Location = new System.Drawing.Point(1183, 120);
            this.reverseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reverseButton.Name = "reverseButton";
            this.reverseButton.Size = new System.Drawing.Size(86, 31);
            this.reverseButton.TabIndex = 5;
            this.reverseButton.Text = "reverse";
            this.reverseButton.UseVisualStyleBackColor = true;
            this.reverseButton.Click += new System.EventHandler(this.reverseButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 684);
            this.Controls.Add(this.reverseButton);
            this.Controls.Add(this.interedButton);
            this.Controls.Add(this.clearCanvasButton);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.pictureGist);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureGist;
        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.Button clearCanvasButton;
        private System.Windows.Forms.Button interedButton;
        private System.Windows.Forms.Button reverseButton;
    }
}