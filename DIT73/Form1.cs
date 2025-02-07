using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnMul_Click(object sender, EventArgs e)
        {

        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            txtResult.Text = (Int32.Parse(txtNumber1.Text) - Int32.Parse(txtNumber2.Text)).ToString();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            txtResult.Text = (Int32.Parse(txtNumber1.Text) + Int32.Parse(txtNumber2.Text)).ToString();
        }

        private void txtNumber2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            try
            {
                txtResult.Text = (Int32.Parse(txtNumber1.Text) / Int32.Parse(txtNumber2.Text)).ToString();
            }
            catch (DivideByZeroException ex) {
                MessageBox.Show("Number2 cannot be zero");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNumber1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
