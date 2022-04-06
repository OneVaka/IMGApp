using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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

        static List<Point> graphPointsList = new List<Point>();

        public Form2()
        {
            InitializeComponent();
            this.pictureBox1.Image = image;
            
            this.pictureGist.Image = Gistogram;


            //Сохдаем нашу канву.
            var canvas1 = new MyCanvas();

            //Клапдем ее в панель на окне (чтобы было удобно управлять ее размерами)
            this.graphPanel.Controls.Add(canvas1);

            //Даем есть установку - всегда заполнять всю возможную область
            canvas1.Dock = DockStyle.Fill;


            graphPointsList.Add(new Point(0, graphPanel.Height - 1));
            graphPointsList.Add(new Point(graphPanel.Width-1, 0));
        }


        public class MyCanvas : Control
        {
            //Таймер для ее обновления
            private Timer timer;

            //битмапы на которых будем рисовать в 2 слоя.
            //На первом будет само содержаение
            //На втором курсор.
            private Bitmap layer1;
            private Bitmap layer2;

            //Графиксы для этих битмапов
            private Graphics g_layer1;
            private Graphics g_layer2;

            private bool painting_mode = false;

            Pen pen = new Pen(Color.FromArgb(255, 0, 80, 0), 1);

            public MyCanvas()
            {
                //Включаем режим двойной буферизации, чтобы рисовка не мерцала.
                this.SetStyle(
                    System.Windows.Forms.ControlStyles.UserPaint |
                    System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                    System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                    true);

                //Опеределяем в нашей канве события
                this.Paint += MyCanvas_Paint;
                this.MouseDown += MyCanvas_MouseDown;
                this.MouseUp += MyCanvas_MouseUp;
                this.MouseMove += MyCanvas_MouseMove;

                this.SizeChanged += MyCanvas_SizeChanged;

                //Запускаем таймер на перерисовку
                timer = new Timer();
                timer.Interval = 25;
                timer.Tick += (s, a) => this.Refresh();
                timer.Start();
            }


            ~MyCanvas()
            {

                if (g_layer1 != null)
                    layer1.Dispose();
                if (g_layer2 != null)
                    layer2.Dispose();

                if (layer1 != null)
                    layer1.Dispose();
                if (layer2 != null)
                    layer2.Dispose();

                timer.Dispose();
                pen.Dispose();
            }

            private void MyCanvas_SizeChanged(object sender, EventArgs e)
            {
                var _sender = sender as MyCanvas;

                //При изменении размера у нас должны пересоздатся битмапы (так как нельзя изменить
                // размер битмапа во время работы)
                //По этому мы сначала создаем новые, если старые есть (при создании конвы их нет,
                //вот тут они и создадутся при первом отображении) - рисуем их содержимое на новых, удаляем старые.

                Bitmap new_layer1 = new Bitmap(_sender.Size.Width, _sender.Size.Height, PixelFormat.Format32bppArgb);
                Bitmap new_layer2 = new Bitmap(_sender.Size.Width, _sender.Size.Height, PixelFormat.Format32bppArgb);
                Graphics new_g_layer1 = Graphics.FromImage(new_layer1);
                Graphics new_g_layer2 = Graphics.FromImage(new_layer2);

                new_g_layer1.InterpolationMode = InterpolationMode.HighQualityBicubic;
                new_g_layer2.InterpolationMode = InterpolationMode.HighQualityBicubic;
                new_g_layer1.SmoothingMode = SmoothingMode.HighQuality;
                new_g_layer2.SmoothingMode = SmoothingMode.HighQuality;

                
                //график квадрата
                for (int i = 0; i < new_layer1.Width; i++)
                {
                    new_g_layer1.DrawLine(Pens.Black, i, new_layer1.Height - 1 - ((i*i)/new_layer1.Height), i+1, 
                                                           new_layer1.Height - 1 - Clamp((i+1)*(i+1)/new_layer1.Height,0,new_layer1.Height-1) );

                }


               // new_g_layer1.DrawLine(Pens.Black, 0, new_layer1.Height - 1, new_layer1.Width - 1, 0);
                new_g_layer2.DrawLine(Pens.Black, 0, new_layer2.Height - 1, new_layer2.Width - 1, 0);



                if (g_layer1 != null)
                {
                    new_g_layer1.DrawImageUnscaled(layer1, 0, 0);
                    layer1.Dispose();
                }
                if (layer1 != null)
                    layer1.Dispose();


                if (g_layer2 != null)
                    layer2.Dispose();
                if (layer2 != null)
                    layer2.Dispose();

                layer1 = new_layer1;
                g_layer1 = new_g_layer1;
                layer2 = new_layer2;
                g_layer2 = new_g_layer2;


            }

            private void MyCanvas_Paint(object sender, PaintEventArgs e)
            {

                //Всегда рисуем зеленый кружок под мышкой, чтобы видеть как будет рисоватся линия.

                var mouse_pos = PointToClient(MousePosition);
                int r = 5;
                g_layer2.Clear(Color.FromArgb(0, 0, 0, 0));
               // g_layer2.DrawEllipse(pen, mouse_pos.X - r / 2, mouse_pos.Y - r / 2, r, r);

               // g_layer2.DrawRectangle(pen, mouse_pos.X, mouse_pos.Y, 10, 10);

                e.Graphics.DrawImageUnscaled(layer1, 0, 0);
                //e.Graphics.DrawImageUnscaled(layer2, 0, 0);

            }

            private void MyCanvas_MouseUp(object sender, MouseEventArgs e)
            {
                //при отпускании ЛКМ отключаем режим рисования
                if (e.Button == MouseButtons.Left)
                    painting_mode = false;
            }

            private void MyCanvas_MouseDown(object sender, MouseEventArgs e)
            {
                //при нажании ЛКМ включаем режим рисования
                if (e.Button == MouseButtons.Left)
                    painting_mode = true;

                var mouse_pos = PointToClient(MousePosition);

                g_layer1.FillRectangle(Brushes.Navy, mouse_pos.X-3, mouse_pos.Y-3, 6, 6);



                graphPointsList.Add(mouse_pos);

                g_layer1.Clear(Color.FromArgb(0, 0, 0, 0));
                foreach(var graphPoint in graphPointsList)
                {
                    g_layer1.FillRectangle(Brushes.Navy, graphPoint.X-3, graphPoint.Y-3, 6, 6);
                }

                if (graphPointsList.Count > 1)
                {
                    graphPointsList.Sort(Compare);
                    g_layer1.DrawCurve(Pens.Red, graphPointsList.ToArray());
                }
                

                return;
            }


            public static int Compare(Point p1,Point p2)
            {
                return p1.X.CompareTo(p2.X);
            }


            private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
            {
                //Если есть режим рисования, то нарисовать красный круг под мышкой.
                //ф-ция вызывается при движении мыши по канве
                if (painting_mode)
                {
                   // var mouse_pos = PointToClient(MousePosition);
                   // int r = 50;
                   // g_layer1.FillEllipse(Brushes.Red, mouse_pos.X - r / 2, mouse_pos.Y - r / 2, r, r);
                }

            }


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
