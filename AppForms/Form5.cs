using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



using System.Drawing.Drawing2D;


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

        Bitmap fourier_image = null;

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

        /// <summary>
        /// Создает матрицу со значениями Color полученного Bitmap 
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Получение Фурье образа для каждого канала изображения изображения 
        /// </summary>
        /// <param name="image"></param>
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

        /// <summary>
        /// Получение исходного изображения из его Фурье образа и вывод его в форму
        /// </summary>
        /// <param name="fourier_Red">Фурье образ красного канала</param>
        /// <param name="fourier_Green">Фурье образ зеленого канала</param>
        /// <param name="fourier_Blue">Фурье образ синего канала</param>
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
                    image_Red[i, j] =   new Complex(fourier_Red[i,j].Real,    -fourier_Red[i,j].Imaginary);
                    image_Green[i, j] = new Complex(fourier_Green[i, j].Real, -fourier_Green[i, j].Imaginary);
                    image_Blue[i, j] =  new Complex(fourier_Blue[i, j].Real,  -fourier_Blue[i, j].Imaginary);
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
                    temp_Green[j] = image_Green[i, j]   ;
                    temp_Blue[j] =  image_Blue[i, j]    ;
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
                temp_Red = DFT(temp_Red, true);
                temp_Green = DFT(temp_Green, true);
                temp_Blue = DFT(temp_Blue, true);

                for (int i = 0; i < width; i++)
                {                                      //центрирование         
                    image_Red[i, j] = temp_Red[i]       * Math.Pow(-1, i+j) ;
                    image_Green[i, j] = temp_Green[i]   * Math.Pow(-1, i+j) ;
                    image_Blue[i, j] = temp_Blue[i]     * Math.Pow(-1, i+j);
                }

            }

            Bitmap new_img = new Bitmap(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    new_img.SetPixel(i,j,
                        Color.FromArgb(
                            Clamp((int)image_Red[i, j].Real, 0, 255), 
                            Clamp((int)image_Green[i, j].Real, 0, 255), 
                            Clamp((int)image_Blue[i, j].Real , 0, 255)));
                }
            }


            if (new_img.Width != image_original.Width || new_img.Height != image_original.Height)
                new_img = ResizeImg(new_img, image_original.Width, image_original.Height);

            pictureBox2.Image = new_img;
            pictureBox2.Refresh();

            return;

        }


        /// <summary>
        /// Одномерное Фурье преобразование
        /// </summary>
        /// <param name="input_array">Входной массив</param>
        /// <param name="reverse">Параметр обратного преобразования</param>
        /// <returns>Фурье образ массива или исходный массив</returns>
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

        /// <summary>
        /// Создание изображения самого Фурье образа и вывод на форму
        /// </summary>
        /// <param name="Red">Фурье красный канал</param>
        /// <param name="Green">Фурье зеленый канал</param>
        /// <param name="Blue">Фурье синий канал</param>
        void GetFourierImage(Complex[,] Red, Complex[,] Green, Complex[,] Blue)
        {

            int width = Red.GetLength(0);
            int height = Red.GetLength(1);

            fourier_image = new Bitmap(width, height, PixelFormat.Format24bppRgb);

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
        /// Измененение яркости изображения
        /// </summary>
        /// <param name="img_org">Изображение</param>
        /// <param name="f_multiplier">Коэффициент яркости</param>
        /// <returns>Изображение с измененнной яркостью</returns>
        Bitmap ChangeBrightness(Bitmap img_org, int f_multiplier)
        {

            byte[] img_bytes;
            img_bytes = getImgBytes(img_org);

            img_bytes = img_bytes.Select(value => (byte)Clamp(value * f_multiplier,0,255)).ToArray();


            Bitmap img = new Bitmap(img_org.Width,img_org.Height, img_org.PixelFormat);

            writeImageBytes(img, img_bytes);


            return img;
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
        /// Получение байтов изображения Гавра
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        static byte[] getImgBytes(Bitmap img)
        {
            byte[] bytes = new byte[img.Width * img.Height * 3];  //выделяем память под массив байтов
            var data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),  //блокируем участок памати, занимаемый изображением
                ImageLockMode.ReadOnly,
                img.PixelFormat);
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);  //копируем байты изображения в массив
            img.UnlockBits(data);   //разблокируем изображение
            return bytes; //возвращаем байты
        }
        /// <summary>
        /// Запись байтов изображения Гавра
        /// </summary>
        /// <param name="img"></param>
        /// <param name="bytes"></param>
        static void writeImageBytes(Bitmap img, byte[] bytes)
        {
            var data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),  //блокируем участок памати, занимаемый изображением
                ImageLockMode.WriteOnly,
                img.PixelFormat);
            Marshal.Copy(bytes, 0, data.Scan0, bytes.Length); //копируем байты массива в изображение

            img.UnlockBits(data);  //разблокируем изображение
        }
        /// <summary>
        /// Кнопка создания образа Фурье из изображения, создание изображения образа, восстановление изображения 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (image_original == null)
                return;

            numeric_fourier_brightness.Value = 1;
            numeric_fourier_brightness.Refresh();

            ImageToFourier(image_matrix);

            GetFourierImage(fourier_Red,fourier_Green,fourier_Blue);

            numeric_R1.Maximum = Math.Min(fourier_image.Width,fourier_image.Height);
            numeric_R2.Maximum = Math.Min(fourier_image.Width,fourier_image.Height);

            FourierToImage(fourier_Red, fourier_Green, fourier_Blue);

            return;
        }
        /// <summary>
        /// Изменение значения яркости изображения фурье
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numeric_fourier_brightness_ValueChanged(object sender, EventArgs e)
        {
            if (image_original == null || pictureBox_fourier.Image == null)
                return;

            pictureBox_fourier.Image = ChangeBrightness(fourier_image, (int)numeric_fourier_brightness.Value);
            pictureBox_fourier.Refresh();
        }
        /// <summary>
        /// Кнопка применения радиального фультра к Фурье образу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_fourier_filter_Click(object sender, EventArgs e)
        {
            int filter_R1 = (int)numeric_R1.Value;
            int filter_R2 = (int)numeric_R2.Value;


            Pen pen = new Pen(Color.FromArgb(200, 255, 80, 0), 1);

            Bitmap fourier_filter = new Bitmap(fourier_image);
            Graphics graphics = Graphics.FromImage(fourier_filter);

            int center_X = fourier_filter.Width / 2;
            int center_Y = fourier_filter.Height / 2;

            graphics.DrawEllipse(pen, center_X - filter_R1, center_Y- filter_R1, filter_R1*2,filter_R1*2);
            graphics.DrawEllipse(pen, center_X - filter_R2, center_Y - filter_R2, filter_R2*2,filter_R2*2);

            
            FourierToImage(getMatrixRadius(fourier_Red, filter_R1), getMatrixRadius(fourier_Green, filter_R1), getMatrixRadius(fourier_Blue, filter_R1));


            pictureBox_fourier.Image = fourier_filter;
        }

        /// <summary>
        /// Получить из середины матрицы квадрат с радиусом radius
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="radius"></param>
        /// <returns>Часть исходной матрицы</returns>
        Complex[,] getMatrixRadius(Complex[,] matrix, int radius)
        {

            Complex[,] new_matrix = new Complex[radius*2,radius*2];

            int x = 0;
            int y = 0;

            for (int i = -radius; i < radius; i++)
            {
                for (int j = -radius; j < radius; j++)
                {


                    new_matrix[x,y] = matrix[matrix.GetLength(0)/2 + i, matrix.GetLength(1) / 2 + j];

                    y++;
                }
                x++;
                y = 0;
            }

            return new_matrix;
        }
        /// <summary>
        /// Получить из матрицы часть, не входящую в центральный квадрат радиусом radius
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="radius"></param>
        /// <returns>Часть исходной матрицы</returns>
        Complex[,] getMatrixNotRadius(Complex[,] matrix, int radius)
        {

            Complex[,] new_matrix = new Complex[matrix.GetLength(0) - radius*2, matrix.GetLength(1)- radius * 2];

            int x = 0;
            int y = 0;

            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                if (i > matrix.GetLength(0) / 2 - radius && i < matrix.GetLength(0) / 2 + radius)
                {

                    continue;
                }

                    for (int j = 0; j < matrix.GetLength(1)-1; j++)
                    {
                        if (j > matrix.GetLength(1) / 2 - radius && j < matrix.GetLength(1) / 2 + radius)
                        {

                        continue;
                        }


                        new_matrix[x, y] = matrix[i, j];

                        y++;
                    }
                x++;
                y = 0;
            }

            return new_matrix;
        }
        /// <summary>
        /// Применение обратного радиального фильтра к Фурье образу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int filter_R1 = (int)numeric_R1.Value;
            int filter_R2 = (int)numeric_R2.Value;


            Pen pen = new Pen(Color.FromArgb(200, 255, 80, 0), 1);

            Bitmap fourier_filter = new Bitmap(fourier_image);
            Graphics graphics = Graphics.FromImage(fourier_filter);

            int center_X = fourier_filter.Width / 2;
            int center_Y = fourier_filter.Height / 2;

            graphics.DrawEllipse(pen, center_X - filter_R1, center_Y - filter_R1, filter_R1 * 2, filter_R1 * 2);
            graphics.DrawEllipse(pen, center_X - filter_R2, center_Y - filter_R2, filter_R2 * 2, filter_R2 * 2);

            
            FourierToImage(getMatrixNotRadius(fourier_Red, filter_R1), getMatrixNotRadius(fourier_Green, filter_R1), getMatrixNotRadius(fourier_Blue, filter_R1));


            pictureBox_fourier.Image = fourier_filter;
        }
            
        private void numeric_R2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numeric_R1_ValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Изменение размера изображения
        /// </summary>
        /// <param name="b"></param>
        /// <param name="nWidth"></param>
        /// <param name="nHeight"></param>
        /// <returns></returns>
        public Bitmap ResizeImg(Bitmap b, int nWidth, int nHeight)
        {
            Bitmap result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage((Image)result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(b, 0, 0, nWidth, nHeight);
                g.Dispose();
            }
            return result;
        }


    }


}




