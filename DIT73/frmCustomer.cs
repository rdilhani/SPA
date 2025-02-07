using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DIT72
{
    public partial class frmCustomer : Form
    {
        SqlConnection con = new DBConnection().getSqlConnection();
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void picCustomer_Click(object sender, EventArgs e)
        {
            OpenFileDialog cusImage = new OpenFileDialog();
            if (cusImage.ShowDialog() == DialogResult.OK) { 
            picCustomer.Image=new Bitmap(cusImage.FileName);
            }
                  
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            string cusID = "0000";
            con.Open();
            SqlCommand cmd = new SqlCommand("select cusId from customer",con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read()) {
                    cusID = reader["cusId"].ToString();  
                 }
                int id = Convert.ToInt32(cusID.Substring(3));
                id = id + 1;
                String nextCusId="CUS"+id.ToString("D4");
                txtCustomerID.Text= nextCusId;
            }
           con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd=new SqlCommand("insert into customer values (@Id,@Name,@Address,@Gender,@Dob,@Contact,@Email,@Image)",con);
            cmd.Parameters.AddWithValue("@Id",txtCustomerID.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Address", rtxtAddress.Text);
            cmd.Parameters.AddWithValue("@Gender",cmbGender.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@Dob",dtpDOB.Value.Date.ToString());
            cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Image", convertImage());
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data inserted successfully");
        }

        private byte[] convertImage() {
            MemoryStream stream = new MemoryStream();
            if (!(picCustomer.Image == null))
            {
                picCustomer.Image.Save(stream, picCustomer.Image.RawFormat);
            }
            else {
                MessageBox.Show("Select a valid Customer Image");
            }
            return stream.GetBuffer();
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                // MessageBox.Show("Customer name is required!");
                lblErrName.Text = "Error! Customer name is required";
                txtName.Focus();
            }
            else {
                lblErrName.Text = "";
            }


        }
    }
}
