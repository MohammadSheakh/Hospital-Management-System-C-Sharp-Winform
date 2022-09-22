using LOGIN_FORM;
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
using LOGIN_FORM.Component.Admin;

namespace ABC_Hospital_MS.Component.ExtraFeature
{
    public partial class MainFeedback : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public MainFeedback()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        // Suggestion insert
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into Suggestion values( @UserName, @Suggestion, @Reply)";
            SqlCommand cmd = new SqlCommand(query, con); // con for connection


            cmd.Parameters.AddWithValue("@UserName", UserName.Text);
            cmd.Parameters.AddWithValue("@Suggestion", SuggestionBox.Text);
            cmd.Parameters.AddWithValue("@Reply", "");




            // connection open korbo ekhon
            con.Open();
            int a = cmd.ExecuteNonQuery(); //  insert korar jonno  // eta kichu integer return korbe
            // 1 row insert korle 1 return korbe 
            if (a > 0)
            {
                MessageBox.Show("Suggestion is added successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                // BindGridView();
            }
            else
            {
                MessageBox.Show("Please Give Proper Value to add Suggestion !", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
            }
            con.Close();

            UserName.Text = "";
            SuggestionBox.Text = "";

            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();  
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DoctorListBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowDoctorList sdl = new ShowDoctorList();
            sdl.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FloorMap1 fm = new FloorMap1();
            fm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainFeedback mf = new MainFeedback();
            mf.Show();
        }

        private void AdminLoginBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin al = new AdminLogin();
            al.Show();
        }
    }
}
