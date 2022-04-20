using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMGApp
{
    public partial class Form3 : Form
    {

        Bitmap imageOriginal = null;
        Bitmap imageBinar = null;
        Bitmap imageMono = null;


        public Form3()
        {
            InitializeComponent();

            pictureBox1.Image = imageOriginal;
            pictureBox2.Image = imageBinar;  

            


        }

   


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetParent("..\\..\\..\\").FullName;
            openFileDialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;



            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (imageOriginal != null)
                    imageOriginal.Dispose();


                imageOriginal = new Bitmap(openFileDialog.FileName);

                imageMono = makeMono(imageOriginal);

                pictureBox1.Image = imageOriginal;
                pictureBox2.Image = imageMono;
            }

        }


        Bitmap makeMono(Bitmap img)
        {
            Bitmap result = new Bitmap(img);

            int monoPx=0;

            for (int i = 0; i < result.Width; i++)
            {
                for (int j = 0; j < result.Height; j++)
                {
                    var pix = result.GetPixel(i,j);

                    monoPx = (int)Clamp( (pix.R * 0.2125 + pix.G * 0.7154 + pix.B * 0.0721), 0, 255);

                    result.SetPixel(i, j, Color.FromArgb(monoPx,monoPx,monoPx));



                }
            }

            return result;
        }

        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }



        //Getting threshold value by arithmetic mean from all pixels
        //Рассчет порогового значения с помощью среднеарифметического яркости всех пикселей
        private void buttonGavr_Click(object sender, EventArgs e)
        {
            imageBinar = new Bitmap(imageMono.Width, imageMono.Height); 


            double porog = 0;
            for (int i = 0; i < imageMono.Width; i++)
            {
                for (int j = 0; j < imageMono.Height; j++)
                {
                    porog += imageMono.GetPixel(i, j).R;
                }
            }

            porog /= (imageMono.Width*imageMono.Height);


            for (int i = 0; i < imageMono.Width; i++)
            {
                for (int j = 0; j < imageMono.Height; j++)
                {
                    var biPix = imageMono.GetPixel(i, j);

                    imageBinar.SetPixel(i, j,
                        biPix.R <= (byte)porog ? Color.Black : Color.White);
                }
            }

            buttonGavr.BackColor = SystemColors.ActiveCaption;
            pictureBox2.Image = imageBinar;
        }

        private void buttonOtsu_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonNiblack_Click(object sender, EventArgs e)
        {

        }

        private void buttonSauvola_Click(object sender, EventArgs e)
        {

        }

        private void buttonWolf_Click(object sender, EventArgs e)
        {

        }

        private void buttonBradley_Click(object sender, EventArgs e)
        {

        }
    }
}
