using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMGApp
{
    public partial class Form2 : Form
    {

        Bitmap image = null;

        int[] gist_values = new int[256];

        Bitmap Gistogram = new Bitmap(256, 1000);

        public Form2()
        {
            InitializeComponent();
            this.pictureBox1.Image = image;
            
            this.pictureGist.Image = Gistogram;
        }

        
        
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetParent("..\\..\\..\\").FullName;
            openFileDialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (image != null)
                    image.Dispose();

                
                image = new Bitmap(openFileDialog.FileName);


                int x = 0;

                for(int i = 0; i < gist_values.Length; i++)
                {
                    gist_values[i] = 0;
                }

                for ( int i = 0; i <  image.Width;i++)
                    for (int j = 0; j < image.Height; j++)
                    {
                        var pix = image.GetPixel(i, j);


                        x = Clamp((pix.R + pix.G + pix.B) / 3, 0, 255);

                        gist_values[x]++;

                        


                        //применение квадратной функции
                        int R = (byte)Clamp((pix.R*pix.R)/255   , 0,255);
                        int G = (byte)Clamp((pix.G*pix.G)/255   , 0,255);
                        int B = (byte)Clamp((pix.B*pix.B)/255   , 0,255);
                       
                        image.SetPixel(i,j, Color.FromArgb(R, G, B));
                    }


                if (Gistogram.Height != pictureGist.Height) 
                Gistogram = MyImage.ResizeImg(Gistogram, Gistogram.Width, this.pictureGist.Height);

                using (var graphic = Graphics.FromImage(Gistogram))
                {


                    graphic.Clear(Color.White);

                    double koef = (double)pictureGist.Height/gist_values.Max();

                    for (int i = 0; i < gist_values.Length; i++)
                        graphic.FillRectangle(Brushes.DarkSlateGray, i, 0, 1, Clamp(Convert.ToInt32(gist_values[i] * koef),0,999));

                   
                }
                Gistogram.RotateFlip(RotateFlipType.RotateNoneFlipY);

                

                pictureGist.Image = Gistogram;
                pictureBox1.Image = image;

            }

           
        }

        void refresh()
        {
            pictureBox1.Update();
        }




        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

    }
}
