using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMGApp
{
    public partial class Form4 : Form
    {
        Bitmap image_original = null;


        public Form4()
        {
            InitializeComponent();
        }





        /// <summary>
        /// Применение маски Гаусса к загруженному изображению
        /// </summary>
        void MaskGauss()
        {
            double[,] gauss_matrix = GaussCoefs();

            Color[,] image_matrix = new Color[image_original.Width, image_original.Height];
            Color[,] image_matrix_temp = new Color[image_original.Width, image_original.Height];

            progressBar1.Maximum = image_original.Width*image_original.Height * 3;

            label_progress.Text = "Getting pixels";
            label_progress.Refresh();

            for (int i = 0; i < image_original.Width; i++)
            {
                for (int j = 0; j < image_original.Height; j++)
                {

                    var pixel = image_original.GetPixel(i, j);
                    image_matrix_temp[i, j] = pixel;

                    progressBar1.Value++;
                }
            }

            label_progress.Text = "Applying mask";
            label_progress.Refresh();
            for (int i = 0; i < image_original.Width; i++)
            {
                for (int j = 0; j < image_original.Height; j++)
                {
                   image_matrix[i,j] = ApplyMask(image_matrix_temp,gauss_matrix, i,j);
                    progressBar1.Value++;
                }
            }

            label_progress.Text = "Setting pixels";
            label_progress.Refresh();
            for (int i = 0; i < image_original.Width; i++)
            {
                for (int j = 0; j < image_original.Height; j++)
                {
                    image_original.SetPixel(i, j, image_matrix[i, j]);
                    progressBar1.Value++;
                }
            }

            
            pictureBox1.Image = image_original;
            label_progress.Text = "";

        }


        /// <summary>
        /// Применение маски Гаусса к пикселю матрицы изображения
        /// </summary>
        /// <param name="image">Матрица пикселей изображения</param>
        /// <param name="gauss">Матрица гаусса</param>
        /// <param name="index_x">X пикселя для обработки</param>
        /// <param name="index_y">Y пикселя для обработки</param>
        /// <returns>Значение пикселя после обработки маской Гаусса</returns>
        Color ApplyMask(Color[,] image, double[,] gauss, int index_x, int index_y)
        {
            double sum_R = 0, sum_G = 0, sum_B = 0;

            int fixed_index_X_minus_i;
            int fixed_index_X_plus_i;

            int fixed_index_Y_minus_j;
            int fixed_index_Y_plus_j;

            for (int i = 0; i < gauss.GetLength(0); i++)
            {
                for (int j = 0; j < gauss.GetLength(1); j++)
                {

                    fixed_index_X_minus_i = (index_x - i >= 0) ? index_x - i : index_x + i;
                    fixed_index_X_plus_i = (index_x + i < image_original.Width) ? index_x + i : index_x - i;

                    fixed_index_Y_minus_j = (index_y - j >= 0) ? index_y - j : index_y + j;
                    fixed_index_Y_plus_j = (index_y + j < image_original.Height) ? index_y + j : index_y - j;


                    if (i == 0 || j == 0){
                        
                        sum_R += (image[fixed_index_X_plus_i, fixed_index_Y_plus_j].R 
                                    + image[fixed_index_X_minus_i, fixed_index_Y_minus_j].R) * gauss[i, j];
                            
                        sum_G += (image[fixed_index_X_plus_i, fixed_index_Y_plus_j].G 
                                    + image[fixed_index_X_minus_i, fixed_index_Y_minus_j].G) * gauss[i, j];
                        
                        sum_B += (image[fixed_index_X_plus_i, fixed_index_Y_plus_j].B 
                                    + image[fixed_index_X_minus_i, fixed_index_Y_minus_j].B) * gauss[i, j];
                    
                    }
                    else{

                       

                        sum_R += (image[fixed_index_X_plus_i, fixed_index_Y_plus_j].R
                                    + image[fixed_index_X_minus_i, fixed_index_Y_minus_j].R
                                        + image[fixed_index_X_plus_i, fixed_index_Y_minus_j].R 
                                            + image[fixed_index_X_minus_i, fixed_index_Y_plus_j].R) * gauss[i, j];

                        sum_G += (image[fixed_index_X_plus_i, fixed_index_Y_plus_j].G
                                    + image[fixed_index_X_minus_i, fixed_index_Y_minus_j].G
                                        + image[fixed_index_X_plus_i, fixed_index_Y_minus_j].G
                                            + image[fixed_index_X_minus_i, fixed_index_Y_plus_j].G) * gauss[i, j];

                        sum_B += (image[fixed_index_X_plus_i, fixed_index_Y_plus_j].B
                                    + image[fixed_index_X_minus_i, fixed_index_Y_minus_j].B
                                        + image[fixed_index_X_plus_i, fixed_index_Y_minus_j].B 
                                            + image[fixed_index_X_minus_i, fixed_index_Y_plus_j].B) * gauss[i, j];
                    
                    }

                }
            }

            return (Color.FromArgb((int)Clamp(sum_R,0,255),(int)Clamp(sum_G,0,255),(int)Clamp(sum_B,0,255))) ;
        }


        /// <summary>
        /// Создание четверти матрицы Гаусса для заданных параметров sig и r
        /// </summary>
        /// <param name="sig">Сигма уравнения Гаусса</param>
        /// <param name="r">Половина от размерности матрицы Гаусса</param>
        /// <returns>Четвертая часть матрицы Гаусса</returns>
        double[,] GaussCoefs(int sig = 3,int r = 9 )
        {
            int sig_squared = sig * sig;

            double[,] gauss_coefs = new double[r,r];

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    gauss_coefs[i,j] = Math.Exp((i*i + j*j)/(2.0*sig_squared) * -1.0) / (2.0 * Math.PI * sig_squared);
;

                }
            }

            return gauss_coefs;
        }


        //Загрузка изображения
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

                
                pictureBox1.Image = image_original;
            }
        }


        //Применение маски Гаусса к загруженному изображению
        private void button1_Click(object sender, EventArgs e)
        {

            if(image_original == null)
                return;


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            MaskGauss();

            stopwatch.Stop();

            label_time.Text = "Elapsed time: " + stopwatch.Elapsed.TotalSeconds + "s";
            label_time.Refresh();
        }


        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
