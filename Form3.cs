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

                imageBinar = new Bitmap(imageMono.Width, imageMono.Height);

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
           // imageBinar = new Bitmap(imageMono.Width, imageMono.Height); 


            double threshold = 0.0;
            for (int i = 0; i < imageMono.Width; i++)
            {
                for (int j = 0; j < imageMono.Height; j++)
                {
                    threshold += imageMono.GetPixel(i, j).R;
                }
            }

            threshold /= (imageMono.Width*imageMono.Height);


            for (int i = 0; i < imageMono.Width; i++)
            {
                for (int j = 0; j < imageMono.Height; j++)
                {
                    var biPix = imageMono.GetPixel(i, j);

                    imageBinar.SetPixel(i, j,
                        biPix.R <= (byte)threshold ? Color.Black : Color.White);
                }
            }

            buttonGavr.BackColor = SystemColors.ActiveCaption;
            pictureBox2.Image = imageBinar;
        }

        //Рассчет порогового значения с помощью алгоритма Отсу
        //https://ru.wikipedia.org/wiki/%D0%9C%D0%B5%D1%82%D0%BE%D0%B4_%D0%9E%D1%86%D1%83
        private void buttonOtsu_Click(object sender, EventArgs e)
        {
            ///imageMono; // нужно расчитать threshgold

            var all_intensity_sum = 0.0;
            //gistogramma
            int[] gist_values = new int[256];
            for (int i = 0; i < imageMono.Width; i++)
                for (int j = 0; j < imageMono.Height; j++)
                {
                    var pix = imageMono.GetPixel(i, j);

                    all_intensity_sum += pix.R;

                    gist_values[pix.R]++;
                }

            int best_thresh = 0;
            double best_sigma = 0.0;

            int first_class_pixel_count = 0;
            int first_class_intensity_sum = 0;

           

            for (int thresh = 0; thresh < 255 ; ++thresh)
            {
                first_class_pixel_count += gist_values[thresh];
                first_class_intensity_sum += thresh * gist_values[thresh];

                double first_class_prob = first_class_pixel_count / (double)(imageMono.Width * imageMono.Height);
                double second_class_prob = 1.0 - first_class_prob;

                double first_class_mean = first_class_intensity_sum / (double)first_class_pixel_count;
                double second_class_mean = (all_intensity_sum - first_class_intensity_sum)
                    / (double)(imageMono.Width * imageMono.Height - first_class_pixel_count);

                double mean_delta = first_class_mean - second_class_mean;

                double sigma = first_class_prob * second_class_prob * mean_delta * mean_delta;

                if (sigma > best_sigma)
                {
                    best_sigma = sigma;
                    best_thresh = thresh;
                }
            }


            for (int i = 0; i < imageMono.Width; i++)
            {
                for (int j = 0; j < imageMono.Height; j++)
                {
                    var biPix = imageMono.GetPixel(i, j);

                    imageBinar.SetPixel(i, j,
                        biPix.R <= (byte)best_thresh ? Color.Black : Color.White);
                }
            }


            buttonGavr.BackColor = SystemColors.ActiveCaption;
            pictureBox2.Image = imageBinar;

        }

        private void buttonNiblack_Click(object sender, EventArgs e)
        {
            double sensitivity = -0.2;
            int n = 15;
            int[,] pix_matrix = new int[n,n];

            int n_forMatrix = (int)Math.Floor((double)n / 2);


            progressBar1.Maximum = (imageMono.Height * imageMono.Width);
            progressBar1.Step = 1;

            for (int i = 0; i < imageMono.Height; i++)

                for (int j = 0; j < imageMono.Width; j++)
                {
                    
                    var pix = imageMono.GetPixel(j,i);
                    pix_matrix[n_forMatrix, n_forMatrix] = pix.R;   //центр матрицы

                    double math_expec = 0.0;
                    double math_expec_powered = 0.0;
                    double math_dispersion = 0.0;

                    for (int i_matrix = 0; i_matrix < n; i_matrix++)
                    {
                        for(int j_matrix = 0; j_matrix < n; j_matrix++)
                        {
                            if ((i - n_forMatrix + i_matrix) == n_forMatrix && (j - n_forMatrix + j_matrix) == n_forMatrix)
                                continue;

                            if((j - n_forMatrix + j_matrix) >= 0 && (j - n_forMatrix + j_matrix) < imageMono.Width)

                                if((i - n_forMatrix + i_matrix) >=0 && (i - n_forMatrix + i_matrix) < imageMono.Height)

                                    pix_matrix[i_matrix, j_matrix] = imageMono.GetPixel(j - n_forMatrix + j_matrix, i - n_forMatrix + i_matrix).R;
                            //-----------------------------------------------------
                                else { pix_matrix[i_matrix, j_matrix] = 0; }
                            else { pix_matrix[i_matrix, j_matrix] = 0; }


                            math_expec += pix_matrix[i_matrix, j_matrix];
                            math_expec_powered  += Math.Pow(pix_matrix[i_matrix, j_matrix],2);
                        }

                    }

                    math_expec /= (n * n);
                    math_expec_powered /= (n * n);
                    math_dispersion = math_expec_powered - Math.Pow(math_expec,2);

                    double avg_deviation = Math.Sqrt(math_dispersion);

                    int local_threshold = Clamp((int)(math_expec + sensitivity * avg_deviation), 0,255);

                    imageBinar.SetPixel(j,i,
                       pix.R <= local_threshold ? Color.Black : Color.White);


                    progressBar1.PerformStep();
                    
                }

            pictureBox2.Image = imageBinar;
            progressBar1.Value = 0;
            progressBar1.Refresh();
        }

        private void buttonSauvola_Click(object sender, EventArgs e)
        {
            double sensitivity = 0.25;
            int n = 15;
            int[,] pix_matrix = new int[n, n];

            int n_forMatrix = (int)Math.Floor((double)n / 2);


            progressBar1.Maximum = (imageMono.Height * imageMono.Width);
            progressBar1.Step = 1;

            for (int i = 0; i < imageMono.Height; i++)

                for (int j = 0; j < imageMono.Width; j++)
                {

                    var pix = imageMono.GetPixel(j, i);
                    pix_matrix[n_forMatrix, n_forMatrix] = pix.R;   //центр матрицы

                    double math_expec = 0.0;
                    double math_expec_powered = 0.0;
                    double math_dispersion = 0.0;

                    for (int i_matrix = 0; i_matrix < n; i_matrix++)
                    {
                        for (int j_matrix = 0; j_matrix < n; j_matrix++)
                        {
                            if ((i - n_forMatrix + i_matrix) == n_forMatrix && (j - n_forMatrix + j_matrix) == n_forMatrix)
                                continue;

                            if ((j - n_forMatrix + j_matrix) >= 0 && (j - n_forMatrix + j_matrix) < imageMono.Width)

                                if ((i - n_forMatrix + i_matrix) >= 0 && (i - n_forMatrix + i_matrix) < imageMono.Height)

                                    pix_matrix[i_matrix, j_matrix] = imageMono.GetPixel(j - n_forMatrix + j_matrix, i - n_forMatrix + i_matrix).R;
                                //-----------------------------------------------------
                                else { pix_matrix[i_matrix, j_matrix] = 0; }
                            else { pix_matrix[i_matrix, j_matrix] = 0; }


                            math_expec += pix_matrix[i_matrix, j_matrix];
                            math_expec_powered += Math.Pow(pix_matrix[i_matrix, j_matrix], 2);
                        }

                    }

                    math_expec /= (n * n);
                    math_expec_powered /= (n * n);
                    math_dispersion = math_expec_powered - Math.Pow(math_expec, 2);

                    double avg_deviation = Math.Sqrt(math_dispersion);

                    int local_threshold = Clamp((int)(math_expec * (1 + sensitivity * ( avg_deviation / 128 - 1) ) ),
                                                     0, 255);

                    imageBinar.SetPixel(j, i,
                       pix.R <= local_threshold ? Color.Black : Color.White);


                    progressBar1.PerformStep();

                }
            pictureBox2.Image = imageBinar;
            progressBar1.Value = 0;
            progressBar1.Refresh();
        }

        private void buttonWolf_Click(object sender, EventArgs e)
        {

        }

        private void buttonBradley_Click(object sender, EventArgs e)
        {

        }
    }
}
