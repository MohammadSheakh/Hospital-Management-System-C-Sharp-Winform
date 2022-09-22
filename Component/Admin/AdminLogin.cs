using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using ABC_Hospital_MS.Component.Patient;

namespace LOGIN_FORM.Component.Admin
{
    public partial class AdminLogin : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString; 
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            // for transperant backcolor for login admin
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void AdminLogin_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (adminid.Text != "" && password.Text != "")
            {
                
                SqlConnection con = new SqlConnection(cs); // connection // connection string 

                string query = "select * from admin_login where AdminId=@adminid and AdminPassword=@password";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@adminid", adminid.Text); // value er ekta reference
                cmd.Parameters.AddWithValue("@password", password.Text);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdminHome adminHome = new AdminHome();
                    adminHome.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed!", "Email or Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Fill Both Fields");
            }




            

            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowDoctorList sdl = new ShowDoctorList();
             sdl.Show();
        }
    }
}
