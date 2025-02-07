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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void loadForm(Form frm) {
            if (this.panelMain.Controls.Count > 0)
                this.panelMain.Controls.RemoveAt(0);

            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(frm);
            frm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            loadForm(new frmDash());
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            loadForm(new frmStudents());
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            loadForm(new frmCourses());
        }

        private void btnTeachers_Click(object sender, EventArgs e)
        {
            loadForm(new frmTeachers());
        }
    }
}
