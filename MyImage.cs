using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IMGApp
{

    enum ImageOperation {
        Normal,
        Add,
        Proizv,
        SredneArth,
        Min,
        Max,
        Mask
    }


    class MyImage
    {
        private int height, width;

        public Bitmap image;

        private ImageOperation operand = ImageOperation.Normal;

        public bool Red = true, Green = false, Blue = false;

        public ImageOperation Operand {
            set { operand = value; }
            get { return operand; }
            }

        public MyImage(Bitmap input)
        {
            this.height = input.Height;
            this.width = input.Width;

            RectangleF cloneRect = new RectangleF(0, 0, width, height);
            System.Drawing.Imaging.PixelFormat format =
                input.PixelFormat;

            this.image = input.Clone(cloneRect, format);

        }

        public MyImage()
        {
            this.height = 0;
            this.width = 0;
            this.image = null;

        }

        public static Bitmap ChangeIMG(Bitmap img1, MyImage img2, ImageOperation check, int num)
        {


            if (img1 == null)
            {
                return new Bitmap(img2.image).Clone(new Rectangle(0, 0, img2.width, img2.height), img2.image.PixelFormat);
            }

            //Form1.mes(num);

            Bitmap firstImage = new Bitmap(img1);
            Bitmap secondImage = new Bitmap(img2.image);

            int w, h;

            if (img1.Height < img2.height || img1.Width < img2.width)
            {
                w = img2.width;
                h = img2.height;
                firstImage = MyImage.ResizeImg(firstImage, img2.width, img2.height);
            }
            else
            {
                w = img1.Width;
                h = img1.Height;
                secondImage = MyImage.ResizeImg(firstImage, img1.Width, img1.Height);
            }

            Bitmap finalImage = new Bitmap(w, h);

            int r_new = 0;
            int g_new = 0;
            int b_new = 0;


            //if(img2.Operand == Oper.Normal)
            //{
            //    return img2.image;
            //}


            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    var pix_one = firstImage.GetPixel(j, i);
                    var pix_two = secondImage.GetPixel(j, i);


                    switch (img2.Operand)
                    {
                        case ImageOperation.Normal:
                            r_new = pix_two.R;
                            g_new = pix_two.G;
                            b_new = pix_two.B;
                            break;

                        case ImageOperation.Add:
                            r_new = (int)Clamp(pix_one.R + pix_two.R, 0, 255);
                            g_new = (int)Clamp(pix_one.G + pix_two.G, 0, 255);
                            b_new = (int)Clamp(pix_one.B + pix_two.B, 0, 255);
                            break;
                        case ImageOperation.SredneArth:
                            r_new = (int)Clamp((pix_one.R + pix_two.R) / 2, 0, 255);
                            g_new = (int)Clamp((pix_one.G + pix_two.G) / 2, 0, 255);
                            b_new = (int)Clamp((pix_one.B + pix_two.B) / 2, 0, 255);
                            break;
                        case ImageOperation.Max:
                            r_new = (int)Clamp(Math.Max(pix_one.R, pix_two.R), 0, 255);
                            g_new = (int)Clamp(Math.Max(pix_one.G, pix_two.G), 0, 255);
                            b_new = (int)Clamp(Math.Max(pix_one.B, pix_two.B), 0, 255);
                            break;
                        case ImageOperation.Min:
                            r_new = (int)Clamp(Math.Min(pix_one.R, pix_two.R), 0, 255);
                            g_new = (int)Clamp(Math.Min(pix_one.G, pix_two.G), 0, 255);
                            b_new = (int)Clamp(Math.Min(pix_one.B, pix_two.B), 0, 255);
                            break;
                        case ImageOperation.Proizv:
                            r_new = (int)Clamp((pix_one.R * pix_two.R) / 255, 0, 255);
                            g_new = (int)Clamp((pix_one.R * pix_two.R) / 255, 0, 255);
                            b_new = (int)Clamp((pix_one.R * pix_two.R) / 255, 0, 255);
                            break;


                    }

                    
                        

                        var pix_out = Color.FromArgb(
                     img2.Red ? r_new : pix_one.R,
                     img2.Green ? g_new : pix_one.G,
                     img2.Blue ? b_new : pix_one.B);

                        finalImage.SetPixel(j, i, pix_out);
                    
                }
            }


            if (img2.operand == ImageOperation.Mask)
            {
                var img_mask = new Bitmap(w, h);

                using (var f = Graphics.FromImage(img_mask))
                {
                    f.FillRectangle(Brushes.Black, 0, 0, w, h);
                    int x = (w + h) / 4;
                    var rect = new RectangleF((w - x) / 2, (h - x) / 2, x, x);
                    f.FillEllipse(Brushes.White, rect);
                }

                using (var f = Graphics.FromImage(firstImage))
                {
                    int x = (firstImage.Width+firstImage.Height) / 4;
                    var rect = new RectangleF((firstImage.Width - x) / 2, (firstImage.Height - x) / 2, x, x);
                    f.FillEllipse(Brushes.Black, rect);
                }

                for (int k = 0; k < h - 1; k++)
                {
                    for (int m = 0; m < w - 1; m++)
                    {
                        var pixFirst = firstImage.GetPixel(m,k);


                        //считывыем пиксель картинки и получаем его цвет
                        var pix = secondImage.GetPixel(m, k);
                        var pix2 = img_mask.GetPixel(m, k);
                        //получаем цветовые компоненты цвета
                        int r = pix.R;
                        int g = pix.G;
                        int b = pix.B;
                        int r2 = 0;
                        int g2 = 0;
                        int b2 = 0;


                        if (img2.Red)
                        {
                            r2 = pix2.R;
                        }
                        if (img2.Green)
                        {
                            g2 = pix2.G;
                        }
                        if (img2.Blue)
                        {
                            b2 = pix2.B;
                        }

                        //При вычислении пикселей используем функию Clamp (см. ниже Main) чтобы цвет не вылезал за границы [0 255]
                        var r3 = (int)Clamp((r * r2) / 255, 0, 255);
                        var g3 = (int)Clamp((g * g2) / 255, 0, 255);
                        var b3 = (int)Clamp((b * b2) / 255, 0, 255);


                        //записываем пиксель в изображение

                        r_new = r3;
                        g_new = g3;
                        b_new = b3;

                        var pix_out = Color.FromArgb(
                     r_new!=0 ? r_new: pixFirst.R,
                     g_new!=0 ? g_new: pixFirst.G,
                     b_new!=0 ? b_new: pixFirst.B);

                        finalImage.SetPixel(m, k, pix_out);

                    }
                }
            }


                firstImage.Dispose();
                secondImage.Dispose();

                return finalImage;
            
        }

        public static Bitmap ResizeImg(Bitmap b, int nWidth, int nHeight)
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

    }
}
