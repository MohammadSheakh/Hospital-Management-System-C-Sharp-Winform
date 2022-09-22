using LOGIN_FORM.Component.Admin;
using LOGIN_FORM.Component.Doctor;
using LOGIN_FORM.Component.Patient;
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
using ABC_Hospital_MS.Component.ExtraFeature;
using ABC_Hospital_MS.Component.Home;

namespace LOGIN_FORM
{
    public partial class Form1 : Form
    {
        //string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            PatientLogin patientLogin = new PatientLogin();
            patientLogin.Show();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // 😀 Doctor Profile Login Page
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();


            DoctorLoginForm doctorLoginForm = new DoctorLoginForm();
            doctorLoginForm.Show();



            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorList doctorlist = new DoctorList();
            doctorlist.Show();
        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void AdminLoginBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin adminlogin = new AdminLogin();
            adminlogin.Show();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FloorMap1 floorMap1 = new FloorMap1();
            floorMap1.Show();
            
            this.Hide();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MainFeedback mainFeedback = new MainFeedback();
            mainFeedback.Show();
        }
    }
}
