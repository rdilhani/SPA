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
    public partial class frmEvents : Form
    {
        public frmEvents()
        {
            InitializeComponent();
        }

        private void btnClickMe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You've clicked click me");
        }

        private void frmEvents_MouseMove(object sender, MouseEventArgs e)
        {
            txtCoord.Text = "("+e.X+","+e.Y+")";
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            lblTextLength.Text = "Text Length: " + txtText.Text.Length + "";
        }

        private void frmEvents_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.AliceBlue;
            MessageBox.Show("Your form is loaded!");
        }

        private void timerColor_Tick(object sender, EventArgs e)
        {
            int red = trcbRed.Value;
            int green = trcbGreen.Value;
            int blue = trcbBlue.Value;

            this.BackColor = Color.FromArgb(red, green, blue);
        }
    }
}
