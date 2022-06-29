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

namespace IMGApp.AppForms
{
    public partial class Form4 : Form
    {
        Bitmap image_original = null;
        Bitmap image_modified = null;

        public Form4()
        {
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            custom_mask_Grid.ColumnCount = (int)numeric_custom_width.Value;
            custom_mask_Grid.RowCount = (int)numeric_custom_height.Value;



            custom_mask_Grid.Refresh();

        }




        /// <summary>
        /// Применение маски Гаусса к загруженному изображению c заданными параметрами
        /// </summary>
        void MaskGauss(int sigma, int radius)
        {
            double[,] gauss_matrix = GaussCoefs(sigma,radius);

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
                    image_modified.SetPixel(i, j, image_matrix[i, j]);
                    progressBar1.Value++;
                }
            }

            progressBar1.Value = 0;

            pictureBox1.Image = image_modified;
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
            //как радиус начиная от 0;0
            r = (int)Math.Ceiling(r / 2.0);

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


        /// <summary>
        /// Обработка клика по изображению формы (загрузка нового изображения)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                if (image_modified != null)
                    image_modified.Dispose();

                image_modified = new Bitmap(image_original.Width,image_original.Height);
                
                pictureBox1.Image = image_original;
            }
        }


        /// <summary>
        /// Кнопка применения маски Гаусса к загруженному изображению
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_gauss_Click(object sender, EventArgs e)
        {

            if(image_original == null)
                return;

            int gauss_sigma = (int)numeric_gauss_sigma.Value;
            int gauss_size = (int)numeric_gauss_size.Value;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            MaskGauss(gauss_sigma,gauss_size);

            stopwatch.Stop();

            label_time.Text = "Elapsed time: " + stopwatch.Elapsed.TotalSeconds + "s";
            label_time.Refresh();
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


        /// <summary>
        /// кнопка для применения кастомной маски из формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_custom_Click(object sender, EventArgs e)
        {

            if (image_original == null)
                return;



            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            double[,] custom_mask = new double[(int)numeric_custom_width.Value, (int)numeric_custom_height.Value];

            for (int i = 0; i < custom_mask.GetLength(0); i++)
            {
                for (int j = 0; j < custom_mask.GetLength(1); j++)
                {
                    //System.FormatException: "Input string was not in a correct format."
                    //TODO


                    custom_mask[i, j] = Convert.ToDouble(custom_mask_Grid.Rows[j].Cells[i].Value);
                }
            }


            MaskCustom(custom_mask);

            stopwatch.Stop();

            label_time.Text = "Elapsed time: " + stopwatch.Elapsed.TotalSeconds + "s";
            label_time.Refresh();
            

            return;
        }


        /// <summary>
        /// Применение кастомной маски к загруженному изображению
        /// </summary>
        /// <param name="custom_mask"></param>
        void MaskCustom(double[,] custom_mask)
        {
            
            Color[,] image_matrix = new Color[image_original.Width, image_original.Height];
            Color[,] image_matrix_temp = new Color[image_original.Width, image_original.Height];

            progressBar1.Maximum = image_original.Width * image_original.Height * 3;

            //-----------------------------------------------------
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

            //------------------------------------------------------
            label_progress.Text = "Applying mask";
            label_progress.Refresh();


            for (int i = 0; i < image_original.Width; i++)
            {
                for (int j = 0; j < image_original.Height; j++)
                {
                    image_matrix[i, j] = ApplyMaskCustom(image_matrix_temp, custom_mask, i, j);
                    progressBar1.Value++;
                }
            }

            //---------------------------------------------------------
            label_progress.Text = "Setting pixels";
            label_progress.Refresh();

            for (int i = 0; i < image_original.Width; i++)
            {
                for (int j = 0; j < image_original.Height; j++)
                {
                    image_modified.SetPixel(i, j, image_matrix[i, j]);
                    progressBar1.Value++;
                }
            }

            progressBar1.Value = 0;

            pictureBox1.Image = image_modified;
            label_progress.Text = "";

        }

        /// <summary>
        /// Применение кастомной маски к пикселю изображения
        /// </summary>
        /// <param name="image"></param>
        /// <param name="mask"></param>
        /// <param name="index_x"></param>
        /// <param name="index_y"></param>
        /// <returns>Обработанный пиксель изображения</returns>
        Color ApplyMaskCustom(Color[,] image,double[,] mask,int index_x,int index_y)
        {
            /// <!--Делать временное изображение для расчета здесь??-->
            /// Тогда нужно каждый раз создавать заново, если вызываеттся для пикселя

           int mask_Width = mask.GetLength(0);
           int mask_Height = mask.GetLength(1);

            int mask_Width_div_by2 = (int)Math.Floor(mask_Width / 2.0);
            int mask_Height_div_by2 = (int)Math.Floor(mask_Height / 2.0);

            int sum_R=0, sum_G=0, sum_B =0;

            int fixed_index_x;
                int fixed_index_y;

            for (int n = 0; n < mask_Width; n++)
            {
                for (int m = 0; m < mask_Height; m++)
                {

                    //  if (index_x - mask_Width_div_by2 + n < 0 || index_y - mask_Height_div_by2 + m < 0)
                    //      continue;
                    //  if (index_x - mask_Width_div_by2 + n >= image.GetLength(0) || index_y - mask_Height_div_by2 + m >= image.GetLength(1))
                    //      continue;

                    fixed_index_x = (index_x - mask_Width_div_by2 + n < 0) || (index_x - mask_Width_div_by2 + n >= image.GetLength(0)) 
                                                ? index_x + mask_Width_div_by2 - n : index_x - mask_Width_div_by2 + n;

                    fixed_index_y = (index_y - mask_Height_div_by2 + m < 0) || (index_y - mask_Height_div_by2 + m >= image.GetLength(1))
                                                ? index_y + mask_Height_div_by2 - m : index_y - mask_Height_div_by2 + m;
                  
                    sum_R += (int)(image[fixed_index_x, fixed_index_y].R * mask[n, m]);

                    sum_G += (int)(image[fixed_index_x, fixed_index_y].G * mask[n, m]);

                    sum_B += (int)(image[fixed_index_x, fixed_index_y].B * mask[n, m]);


                }
            }

            return (Color.FromArgb((int)Clamp(sum_R, 0, 255), (int)Clamp(sum_G, 0, 255), (int)Clamp(sum_B, 0, 255)));


        }



       

        /// <summary>
        /// Изменение ширины кастомной матрицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numeric_custom_width_ValueChanged(object sender, EventArgs e)
        {
            custom_mask_Grid.ColumnCount = (int)numeric_custom_width.Value;

        }
        /// <summary>
        /// Изменение Высоты кастомной матрицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numeric_custom_height_ValueChanged(object sender, EventArgs e)
        {
            custom_mask_Grid.RowCount = (int)numeric_custom_height.Value;

        }

        /// <summary>
        /// Кнопка для применения медианной фильтрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_median_Click(object sender, EventArgs e)
        {
            if (image_original == null)
                return;


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            MedianFilter();


            stopwatch.Stop();

            label_time.Text = "Elapsed time: " + stopwatch.Elapsed.TotalSeconds + "s";
            label_time.Refresh();
        }

        void MedianFilter()
        {
            

            Color[,] image_matrix = new Color[image_original.Width, image_original.Height];
            Color[,] image_matrix_temp = new Color[image_original.Width, image_original.Height];

            progressBar1.Maximum = image_original.Width * image_original.Height * 3;

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
                    image_matrix[i, j] = MedianFilterMask(image_matrix_temp, i, j,(int) numeric_custom_width.Value, (int)numeric_custom_height.Value);

                    progressBar1.Value++;

                }
            }


            label_progress.Text = "Setting pixels";
            label_progress.Refresh();
            for (int i = 0; i < image_original.Width; i++)
            {
                for (int j = 0; j < image_original.Height; j++)
                {
                    image_modified.SetPixel(i, j, image_matrix[i, j]);
                    progressBar1.Value++;
                }
            }

            progressBar1.Value = 0;

            pictureBox1.Image = image_modified;
            label_progress.Text = "";


        }

        Color MedianFilterMask(Color[,] image_matrix, int index_x, int index_y, int mask_width, int mask_height)
        {

            List<byte> colors_R = new List<byte>();
            List<byte> colors_G = new List<byte>();
            List<byte> colors_B = new List<byte>();


            int width_by_two = (int)Math.Floor(mask_width / 2.0);
            int height_by_two = (int)Math.Floor(mask_height / 2.0);

            int sum_elements = 0;

            for (int i = 0; i < mask_width; i++)
            {
                for (int j = 0; j < mask_height; j++)
                {
                    if (index_x - width_by_two + i < 0 || index_x - width_by_two + i >= image_matrix.GetLength(0))
                        continue;
                    if (index_y - height_by_two + j < 0 || index_y - height_by_two + j >= image_matrix.GetLength(1))
                        continue;


                    colors_R.Add(image_matrix[index_x - width_by_two + i, index_y - height_by_two + j].R);
                    colors_G.Add(image_matrix[index_x - width_by_two + i, index_y - height_by_two + j].G);
                    colors_B.Add(image_matrix[index_x - width_by_two + i, index_y - height_by_two + j].B);

                    sum_elements++;
                }
            }

            sum_elements /= 2;

            colors_R.Sort();
            colors_G.Sort();
            colors_B.Sort();

            return (Color.FromArgb( colors_R[sum_elements],colors_G[sum_elements],colors_B[sum_elements] ));

        }
    }
}
