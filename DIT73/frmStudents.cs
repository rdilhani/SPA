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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SMS
{
    public partial class frmStudents : Form
    {
        SqlConnection con = new dbConnection().getConnection();

        public frmStudents()
        {
            InitializeComponent();
        }

        private void frmStudents_Load(object sender, EventArgs e)
        {
            string existingID = "C000500";
            con.Open();
            SqlCommand cmd = new SqlCommand("select id from student",con);
             SqlDataReader reader=cmd.ExecuteReader();
            while (reader.Read())
            {
                existingID = reader["id"].ToString();
            }
            string nextID;
            int id = int.Parse(existingID.Substring(1));
            nextID="C"+(id+1).ToString("D6");
            txtStudentId.Text = nextID;
            con.Close();

            displayGrid(); //fill the grid with student data

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd=new SqlCommand("insert into student values (@ID,@Name,@Address,@Gender,@DOB,@Contact,@Email,@Image)",con);
            cmd.Parameters.AddWithValue("@ID",txtStudentId.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Address", rtxtAddress.Text);
            cmd.Parameters.AddWithValue("@Gender", cmbGender.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@DOB", dtpDOB.Value.Date.ToString());
            cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Image", convertImage());
            int result = cmd.ExecuteNonQuery();
            if (result != 0)
            {
                MessageBox.Show("Student added tot the system!");
            }
            
            con.Close();
     
        }

        //Converting image to a byte[]
        private byte[] convertImage()
        {
            MemoryStream stream=new MemoryStream();
            if (!(picStudent.Image == null)) {
                picStudent.Image.Save(stream, picStudent.Image.RawFormat);
            }
            return stream.GetBuffer();
        }

        private void picStudent_Click(object sender, EventArgs e)
        {
            OpenFileDialog image= new OpenFileDialog(); 
            if(image.ShowDialog() == DialogResult.OK)
            {
                picStudent.Image=new Bitmap(image.FileName);
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            string id = txtName.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Name cannot be empty.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void rtxtAddress_Leave(object sender, EventArgs e)
        {
            string address=rtxtAddress.Text;
            if (string.IsNullOrEmpty(address))
            {
                lblAddValidatr.Text = "Address cannot be empty !";
            }
            else {
                lblAddValidatr.Text = "";
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email is not valid.", "Validation Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // Helper method to validate email using System.Net.Mail.MailAddress 
        private bool IsValidEmail(string email)
        {
            try
            {
                // Try to create a new MailAddress object with the input email 
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                // If an exception is thrown, the email is not valid 
                return false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update student set (name=@Name,address=@Address,gender=@Gender,dob=@DOB,contact=@Contact,email=@Email,image=@Image where id=@ID)", con);
            cmd.Parameters.AddWithValue("@ID", txtStudentId.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Address", rtxtAddress.Text);
            cmd.Parameters.AddWithValue("@Gender", cmbGender.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@DOB", dtpDOB.Value.Date.ToString());
            cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Image", convertImage());
            int result = cmd.ExecuteNonQuery();
            if (result != 0)
            {
                MessageBox.Show("Student details updated!");
            }

            con.Close();
        }

        //Display items in the grid
        private void displayGrid() { 
            con.Open();
            SqlCommand cmd = new SqlCommand("select id,name,address,gender,dob,contact,email from student",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            da.Fill(dt);
            dgStudents.DataSource= dt;
            con.Close() ;
        }

        private void dgStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) { 
                txtName.Text = dgStudents.SelectedRows[0].Cells[1].Value.ToString();
                   rtxtAddress.Text = dgStudents.SelectedRows[0].Cells[2].Value.ToString();

                }

            }catch (Exception ex){
            MessageBox.Show(ex.Message);
            }
        }
    }
}
