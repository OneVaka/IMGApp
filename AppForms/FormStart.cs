using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMGApp.AppForms
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void button_Form_Overlap_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 overlap_window = new Form1();
                overlap_window.Show();
            }
            catch
            {
                MessageBox.Show("error!");
                Application.Exit();
            }
        }

        private void button_Form_Graph_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 graph_window = new Form2();
                graph_window.Show();
            }
            catch
            {
                MessageBox.Show("error!");
                Application.Exit();
            }
        }

        private void button_Form_Binarization_Click(object sender, EventArgs e)
        {
            try
            {
                Form3 binarization_window = new Form3();
                binarization_window.Show();
            }
            catch
            {
                MessageBox.Show("error!");
                Application.Exit();
            }
        }

        private void button_Form_Masking_Click(object sender, EventArgs e)
        {
            try
            {
                Form4 mask_window = new Form4();
                mask_window.Show();
            }
            catch
            {
                MessageBox.Show("error!");
                Application.Exit();
            }
        }

        private void button_Form_Fourier_Click(object sender, EventArgs e)
        {
            try
            {
                Form5 fourier_window = new Form5();
                fourier_window.Show();
            }
            catch
            {
                MessageBox.Show("error!");
                Application.Exit();
            }
        }
    }
}
