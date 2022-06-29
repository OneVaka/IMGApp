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
                Form_overlap overlap_window = new Form_overlap();
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
                Form_graph graph_window = new Form_graph();
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
                Form_binarization binarization_window = new Form_binarization();
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
                Form_masking mask_window = new Form_masking();
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
                Form_fourier fourier_window = new Form_fourier();
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
