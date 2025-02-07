using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class frmLogin : Form
    {
        SqlConnection con=new dbConnection().getConnection();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           /* string user = "Admin";
            string pass = "123";

            if (txtUsername.Text == user && txtPassword.Text == pass)
            {
                //MessageBox.Show("Login Success!");
                new frmEvents().Show();
                this.Hide();
            }
            else {
                MessageBox.Show("Login Error! Please login again..");
            }*/

            string user=txtUsername.Text;
            string password= encryptPass(txtPassword.Text);

            con.Open();
            SqlCommand cmd = new SqlCommand("select 1 from login where username=@UN and password=@PW",con);
            cmd.Parameters.AddWithValue("@UN", user);
            cmd.Parameters.AddWithValue("@PW", password);  
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                new Dashboard().Show();
                this.Hide();
            }
            else {
                MessageBox.Show("Login Error! Please login again..");
            }
            con.Close();


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picHide_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void picHide_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar=true;
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = encryptPass(txtPassword.Text);

            con.Open();
            SqlCommand cmd=new SqlCommand("insert into login (username,password) select @UN, @PW where not exists (select username from login where username=@UN)  ",con);
            cmd.Parameters.AddWithValue("@UN", user);
            cmd.Parameters.AddWithValue("@PW", pass);
            int result=cmd.ExecuteNonQuery();
            if (result != 0)
            {
                MessageBox.Show("User Registered!");
            }
            else {
                MessageBox.Show("Username already taken..");
            }
            con.Close();

        }

        private string encryptPass(string passwd) {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] data = md5.ComputeHash(new UTF8Encoding().GetBytes(passwd));
                return Convert.ToBase64String(data);
            }
        }
    }
}
