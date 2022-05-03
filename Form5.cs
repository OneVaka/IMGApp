using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMGApp
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        Bitmap image_original = null;
        Color[,] image_matrix = null;

        Complex[,] fourier_Red = null;
        Complex[,] fourier_Green = null;
        Complex[,] fourier_Blue = null;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetParent("..\\..\\..\\").FullName;
            openFileDialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;



            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (image_original != null)
                    image_original.Dispose();

                image_original = new Bitmap(openFileDialog.FileName);

                image_matrix = GetImageMatrix(image_original);

                pictureBox1.Image = image_original;
            }
        }

        Color[,] GetImageMatrix(Bitmap image)
        {
            Color[,] image_matrix = new Color[image_original.Width, image_original.Height];

            for (int i = 0; i < image_original.Width; i++)
            {
                for (int j = 0; j < image_original.Height; j++)
                {

                    image_matrix[i,j] = image_original.GetPixel(i, j);

                }
            }
            return image_matrix;
        }

        void ImageToFourier(Color[,] image) {

            int width = image.GetLength(0);
            int height = image.GetLength(1);

            //получить комплексный массив каждого канала
            fourier_Red = new Complex[width, height];
            fourier_Green = new Complex[width,height];
            fourier_Blue = new Complex[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {                                                  //  //центрирование
                    fourier_Red[i, j] = new Complex(image[i, j].R   * Math.Pow(-1, i + j), 0);
                    fourier_Green[i, j] = new Complex(image[i, j].G * Math.Pow(-1, i + j), 0);
                    fourier_Blue[i, j] = new Complex(image[i, j].B  * Math.Pow(-1, i + j), 0);
                }
            }

            //первый проход фурье
            for (int i = 0; i < width; i++)
            {
                Complex[] temp_Red = new Complex[height];
                Complex[] temp_Green = new Complex[height];
                Complex[] temp_Blue = new Complex[height];

                for (int j = 0; j < height; j++)
                {                                           
                    temp_Red[j] = fourier_Red[i, j]        ;
                    temp_Green[j] = fourier_Green[i, j]    ;
                    temp_Blue[j] = fourier_Blue[i, j]      ;
                }

                temp_Red = DFT(temp_Red);
                temp_Green = DFT(temp_Green);
                temp_Blue = DFT(temp_Blue);

                for (int j = 0; j < height; j++)
                {
                    fourier_Red[i,j] = temp_Red[j];
                    fourier_Green[i,j] = temp_Green[j];
                    fourier_Blue[i,j] = temp_Blue[j];   
                }
            }

            //второй проход фурье
            for (int j = 0; j < height; j++)
            {
                Complex[] temp_Red = new Complex[width];
                Complex[] temp_Green = new Complex[width];
                Complex[] temp_Blue = new Complex[width];

                for (int i = 0; i < width; i++)
                {
                    temp_Red[i] = fourier_Red[i, j];
                    temp_Green[i] = fourier_Green[i, j];
                    temp_Blue[i] = fourier_Blue[i, j];
                }
                temp_Red = DFT(temp_Red);
                temp_Green = DFT(temp_Green);
                temp_Blue = DFT(temp_Blue);

                for (int i = 0; i < width; i++)
                {
                    fourier_Red[i, j] = temp_Red[i];
                    fourier_Green[i, j] = temp_Green[i];
                    fourier_Blue[i, j] = temp_Blue[i];
                }

            }
            return;
        
        }

        void FourierToImage(Complex[,] fourier_Red, Complex[,] fourier_Green, Complex[,] fourier_Blue) {

            int width = fourier_Red.GetLength(0);
            int height = fourier_Red.GetLength(1);

            //получить комплексный массив каждого канала
            Complex[,] image_Red = new Complex[width, height];
            Complex[,] image_Green = new Complex[width, height];
            Complex[,] image_Blue = new Complex[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    image_Red[i, j] =   new Complex(fourier_Red[i,j].Real, -fourier_Red[i,j].Imaginary);
                    image_Green[i, j] = new Complex(fourier_Green[i, j].Real, -fourier_Green[i, j].Imaginary);
                    image_Blue[i, j] =  new Complex(fourier_Blue[i, j].Real, -fourier_Blue[i, j].Imaginary);
                }
            }

            //первый проход фурье
            for (int i = 0; i < width; i++)
            {
                Complex[] temp_Red = new Complex[height];
                Complex[] temp_Green = new Complex[height];
                Complex[] temp_Blue = new Complex[height];

                for (int j = 0; j < height; j++)
                {                                               
                    temp_Red[j] =   image_Red[i, j]     ;
                    temp_Green[j] = image_Green[i, j] ;
                    temp_Blue[j] =  image_Blue[i, j]   ;
                }

                temp_Red = DFT(temp_Red,    true);
                temp_Green = DFT(temp_Green,true);
                temp_Blue = DFT(temp_Blue,  true);

                for (int j = 0; j < height; j++)
                {
                    image_Red[i, j] = temp_Red[j];
                    image_Green[i, j] = temp_Green[j];
                    image_Blue[i, j] = temp_Blue[j];
                }
            }

            //второй проход фурье
            for (int j = 0; j < height; j++)
            {
                Complex[] temp_Red = new Complex[width];
                Complex[] temp_Green = new Complex[width];
                Complex[] temp_Blue = new Complex[width];

                for (int i = 0; i < width; i++)
                {
                    temp_Red[i] =   image_Red[i, j];
                    temp_Green[i] = image_Green[i, j];
                    temp_Blue[i] = image_Blue[i, j];
                }
                temp_Red = DFT(temp_Red);
                temp_Green = DFT(temp_Green);
                temp_Blue = DFT(temp_Blue);

                for (int i = 0; i < width; i++)
                {                                      //центрирование         
                    image_Red[i, j] = temp_Red[i]      * Math.Pow(-1, i+j) ;
                    image_Green[i, j] = temp_Green[i]  * Math.Pow(-1, i+j) ;
                    image_Blue[i, j] = temp_Blue[i] * Math.Pow(-1, i + j);
                }

            }

            Bitmap new_img = new Bitmap(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    new_img.SetPixel(i,j,
                        Color.FromArgb(Clamp((int)image_Red[i, j].Real, 0, 255), Clamp((int)image_Green[i, j].Real, 0, 255), Clamp((int)image_Blue[i, j].Real , 0,255)));
                }
            }

            pictureBox2.Image = new_img;
            pictureBox2.Refresh();

            return;

        }

        Complex[] DFT(Complex[] input_array, bool reverse = false )
        {
            int count = input_array.Length;


            Complex[] output_array = new Complex[count];
            for (int u = 0; u < count; u++)
            {

                double arg = -2.0 * Math.PI * u / count;

                for (int k = 0; k < count; k++)
                {
                    output_array[u] += ( (new Complex(Math.Cos(arg * k), Math.Sin(arg * k))) * input_array[k] );
                }

                if(!reverse)
                    output_array[u] /= count;   

            }


            return output_array;     

        }


        void GetFourierImage(Complex[,] Red, Complex[,] Green, Complex[,] Blue)
        {

            int width = Red.GetLength(0);
            int height = Red.GetLength(1);

            Bitmap fourier_image = new Bitmap(width, height);

            double max_red =0, max_green=0, max_blue=0;

            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    //if (max_red < Math.Log(Red[i, j].Magnitude + 1))
                    //    max_red = Math.Log(Red[i, j].Magnitude + 1);
                    //
                    //if (max_green < Math.Log(Green[i, j].Magnitude + 1))
                    //    max_green = Math.Log(Green[i, j].Magnitude + 1);
                    //
                    //if (max_blue < Math.Log(Blue[i, j].Magnitude + 1))
                    //    max_blue = Math.Log(Blue[i, j].Magnitude + 1);

                    if(max_red < Math.Log(Red[i,j].Imaginary + 1))
                        max_red = Math.Log(Red[i,j].Imaginary + 1);
                    
                    if(max_green < Math.Log(Green[i,j].Imaginary + 1))
                        max_green = Math.Log(Green[i,j].Imaginary + 1);
                    
                    if(max_blue < Math.Log(Blue[i,j].Imaginary + 1))
                        max_blue = Math.Log(Blue[i,j].Imaginary + 1);
                }
            }

            double f_multiplier = 1.0;

            for (int i = 0; i < width; i++)
            {


                for (int j = 0; j < height; j++)
                {
                    fourier_image.SetPixel(i,j,
                        Color.FromArgb(
                                Clamp((byte)(f_multiplier* (Math.Log( Red[i, j].Magnitude + 1 ))   * 255 / max_red)   , 0, 255),
                                Clamp((byte)(f_multiplier* (Math.Log( Green[i, j].Magnitude + 1 )) * 255 / max_green) , 0, 255),
                                Clamp((byte)(f_multiplier* (Math.Log( Blue[i, j].Magnitude + 1 ))  * 255 / max_blue)  , 0, 255)
                            ));             
                }
            }

            pictureBox_fourier.Image = fourier_image;
            pictureBox_fourier.Refresh();

        }


        /// <summary>
        /// Клэм Гавра
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (image_original == null)
                return;

            ImageToFourier(image_matrix);

            GetFourierImage(fourier_Red,fourier_Green,fourier_Blue);

           // FourierToImage(fourier_Red, fourier_Green, fourier_Blue);

            return;
        }
    }


}
