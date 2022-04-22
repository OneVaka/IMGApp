using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;

namespace IMGApp
{
    public partial class Form1 : Form
    {

        private Bitmap image1 = null;
        private Bitmap image2 = null;

        private Bitmap final_image = null;

        private List<MyImage> images = new List<MyImage>();

        

        public Form1()
        {
            InitializeComponent();
            try
            {
                Form2 form2 = new Form2();
                form2.Show();
                Form3 form3 = new Form3();
                form3.Show();
            }
            catch
            {
                //ErrorManager.ErrorOK("Произошла непредвиденная ошибка!");
                MessageBox.Show("error!");
                Application.Exit();
            }
        }

        void finalize_picture()
        {
            if (images.Count == 0)
            {
                //MessageBox.Show("No pictures");
                //return;
            }
                

            if (final_image != null)
                final_image.Dispose();

            // будущее
            for (int i = 0; i < images.Count ; i++)
            {
                //images[i].DoTHEThing(final_image);
            }

            if (image1 != null && image2 != null)
            {
                int w = Math.Max(image1.Width, image2.Width);
                int h = Math.Max(image1.Height, image2.Height);

                if (image1.Width < image2.Width || image1.Height < image2.Height)
                {
                    image1 = this.ResizeImg(image1, w, h);
                }
                else
                {
                    image2 = this.ResizeImg(image2, w, h);
                }





                final_image = new Bitmap(w,h);
                //final_image = new Bitmap(Math.Min(image1.Width, image2.Width), Math.Min(image1.Height, image2.Height));

                int R_new, G_new, B_new;

                progressBar1.Value = 0;

                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < w; j++)
                    {


                        var pix_image1 = image1.GetPixel(j, i);
                        var pix_image2 = image2.GetPixel(j, i);


                        //proizv
                        R_new = (int)Clamp((pix_image1.R * pix_image2.R) / 255, 0, 255);
                        G_new = (int)Clamp((pix_image1.G * pix_image2.G) / 255, 0, 255);
                        B_new = (int)Clamp((pix_image1.B * pix_image2.B) / 255, 0, 255);
                        //записываем пиксель в изображение
                        var new_pix = Color.FromArgb(R_new, G_new, B_new);
                        final_image.SetPixel(j, i, new_pix);
                    }

                    progressBar1.Value = 100 * i / h + 1;//Math.Min(image1.Height, image2.Height) + 1;
                }
            }
            else
                final_image = new Bitmap(image1);

          //  picture_final.SizeMode = PictureBoxSizeMode.Zoom;
            picture_final.Image = final_image;
        }


        static public void mes(int num)
        {
            MessageBox.Show(num.ToString());
        }

        void SwapIMG(int upper, int bottom)
        {
            if (images.Count < (bottom + 1))
                return;

            MyImage buff = images[upper];
            images[upper] = images[bottom];
            images[bottom] = buff;

            try
            {
                Img1_picture.Image = images[0].image;
                Img2_picture.Image = images[1].image;
                Img3_picture.Image = images[2].image;
                Img4_picture.Image = images[3].image;
            }
            catch (Exception)
            { 
               
            }

            new_picture();
        }

        void ChangeRegime()
        {

        }


        void new_picture()
        {
            if (final_image != null)
            {
                final_image.Dispose();
                final_image = null;
            }

            if (images.Count == 1)
            {
                picture_final.Image = images[0].image;
                return;
            }

            progressBar1.Value = progressBar1.Maximum/2;
            BackColor = SystemColors.ControlDarkDark;

            for (int i = 0; i < images.Count; i++)
            {
               // Bitmap tmp = final_image.Clone(new Rectangle(0, 0, final_image.Width, final_image.Height), final_image.PixelFormat);    
                final_image = MyImage.ChangeIMG(final_image, images[i], Oper.Proizv,i);
               // tmp.Dispose();
            }

            progressBar1.Value = progressBar1.Maximum ;
            BackColor = SystemColors.Control;
            picture_final.Image = final_image;
        }

        void loadIMG(int num)
        {

            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetParent("..\\..\\..\\").FullName;
            openFileDialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                if (num == 1)
                {
                    
                    if (images.Count < num)
                    {
                        images.Add(new MyImage(new Bitmap(openFileDialog.FileName)));
                       
                    }
                    else
                    {
                        
                        images[num-1] = new MyImage(new Bitmap(openFileDialog.FileName));
                    }

                    images[num - 1].Operand = (Oper)Img1_regime.SelectedIndex;

                    Img1_picture.Image = images[num - 1].image;
                    Img1Box.Text = images[num - 1].image.Width + "x" + images[num - 1].image.Height;

                    images[num - 1].Red = Img1_R.Checked;
                    images[num - 1].Blue = Img1_B.Checked;
                    images[num - 1].Green = Img1_G.Checked;
                }
                if (num == 2)
                {
                    
                    
                    if (images.Count < num)
                    {
                        images.Add(new MyImage(new Bitmap(openFileDialog.FileName)));
                    }
                    else
                    {
                        images[num-1] = new MyImage(new Bitmap(openFileDialog.FileName));
                    }
                    images[num - 1].Operand = (Oper)Img2_regime.SelectedIndex;

                    Img2_picture.Image = images[num - 1].image;
                    Img2Box.Text = images[num - 1].image.Width + "x" + images[num - 1].image.Height;
                    images[num - 1].Red = Img2_R.Checked;
                    images[num - 1].Blue = Img2_B.Checked;
                    images[num - 1].Green = Img2_G.Checked;
                }
                if (num == 3)
                {
                    if (images.Count < num)
                    {
                        images.Add(new MyImage(new Bitmap(openFileDialog.FileName)));
                    }
                    else
                    {
                        images[num - 1] = new MyImage(new Bitmap(openFileDialog.FileName));
                    }
                    images[num - 1].Operand = (Oper)Img3_regime.SelectedIndex;

                    Img3_picture.Image = images[num - 1].image;
                    Img3Box.Text = images[num - 1].image.Width + "x" + images[num - 1].image.Height;

                    images[num - 1].Red = Img3_R.Checked;
                    images[num - 1].Blue = Img3_B.Checked;
                    images[num - 1].Green = Img3_G.Checked;

                }
                if (num == 4)
                {
                    if (images.Count < num)
                    {
                        images.Add(new MyImage(new Bitmap(openFileDialog.FileName)));
                    }
                    else
                    {
                        images[num - 1] = new MyImage(new Bitmap(openFileDialog.FileName));
                    }
                    images[num - 1].Operand = (Oper)Img4_regime.SelectedIndex;

                    Img4_picture.Image = images[num-1].image;
                    Img4Box.Text = images[num - 1].image.Width + "x" + images[num - 1].image.Height;

                    images[num - 1].Red = Img4_R.Checked;
                    images[num - 1].Blue = Img4_B.Checked;
                    images[num - 1].Green = Img4_G.Checked;
                }
            }

            // finalize_picture();
            new_picture();
        }

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

        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

         private void Save_Key(object sender, EventArgs e)
         {
            if (this.picture_final.Image == null)
            {
                MessageBox.Show("No picture to save.");
                return;
            }
            using SaveFileDialog saveFileFialog = new SaveFileDialog();
             saveFileFialog.InitialDirectory = Directory.GetParent("..\\..\\..\\").FullName;
             saveFileFialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
             saveFileFialog.RestoreDirectory = true;
        
             if (saveFileFialog.ShowDialog() == DialogResult.OK)
             {
                 if (this.picture_final.Image != null)
                 {
                     picture_final.Image.Save(saveFileFialog.FileName);
                 }
                
             }
         }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                Save_Key(sender, e);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

     

        private void Img1_picture_Click(object sender, EventArgs e)
        {
            loadIMG(1);
            
        }

        private void Img2_picture_Click(object sender, EventArgs e)
        {
            if(images.Count >= 1)
                loadIMG(2);
        }



        private void Img3_picture_Click(object sender, EventArgs e)
        {
            if (images.Count >= 2)
                loadIMG(3);
        }

        private void Img4_picture_Click(object sender, EventArgs e)
        {
            if (images.Count >= 3)
                loadIMG(4);
        }

        private void Img1_buttonDown_Click(object sender, EventArgs e)
        {
            SwapIMG(0, 1);
        }

        private void Img2_buttonUp_Click(object sender, EventArgs e)
        {
            SwapIMG(0, 1);
        }

        private void Img2_buttonDown_Click(object sender, EventArgs e)
        {
            SwapIMG(1, 2);
        }

        private void Img3_buttonUp_Click(object sender, EventArgs e)
        {
            SwapIMG(1, 2);

        }

        private void Img3_buttonDown_Click(object sender, EventArgs e)
        {
            SwapIMG(2, 3);

        }

        private void Img4_buttonUp_Click(object sender, EventArgs e)
        {
            SwapIMG(2, 3);

        }

        private void Img1_regime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (images.Count < 1)
                return;
            else
            {
                images[0].Operand = (Oper)Img1_regime.SelectedIndex;
                new_picture();

            }


        }

        private void Img2_regime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (images.Count < 2)
                return;
            else
            {
                images[1].Operand = (Oper)Img2_regime.SelectedIndex;
                new_picture();
            }

        }

        private void Img3_regime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (images.Count < 3)
                return;
            else
            {
                images[2].Operand = (Oper)Img3_regime.SelectedIndex;
                new_picture();

            }

        }

        private void Img4_regime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (images.Count < 4)
                return;
            else
            {
                images[3].Operand = (Oper)Img4_regime.SelectedIndex;
                new_picture();

            }

        }

        private void DeleteIMG(int num)
        {
            
            images.RemoveAt(num - 1);



            try
            {
                Img1_picture.Image = null;
                Img2_picture.Image = null;
                Img3_picture.Image = null;
                Img4_picture.Image = null;

                Img1_picture.Image = images[0].image;
                Img2_picture.Image = images[1].image;
                Img3_picture.Image = images[2].image;
                Img4_picture.Image = images[3].image;
            }
            catch (Exception)
            {

            }

            new_picture();
        }

        private void Img1_delete_Click(object sender, EventArgs e)
        {
            if (images.Count < 1)
                return;

            DeleteIMG(1);
        }

        private void Img2_delete_Click(object sender, EventArgs e)
        {
            if (images.Count < 2)
                return;

            DeleteIMG(2);

        }

        private void Img3_delete_Click(object sender, EventArgs e)
        {
            if (images.Count < 3)
                return;

            DeleteIMG(3);

        }

        private void Img4_delete_Click(object sender, EventArgs e)
        {
            if (images.Count < 4)
                return;

            DeleteIMG(4);

        }
    }
}
