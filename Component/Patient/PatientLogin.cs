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
using LOGIN_FORM.Component.Patient;
using ABC_Hospital_MS.Component.Patient;

namespace LOGIN_FORM.Component.Patient
{
    public partial class PatientLogin : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public static int patient_Id;
        public static string firstName;
        public static string lastName;
        public static string nationality;
        public static string email;
        public static string userName;
        public static string gender;
        public static int age;
        public static string bloodGroup;
        public static string address;
        public static int mobileNumber;
        public static string pincode;



        public PatientLogin()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();   
            form.ShowDialog();  
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            PatientRegestration patientregistration = new PatientRegestration();
            patientregistration.Show();
        }

        private void signinBtn_Click(object sender, EventArgs e)
        {
            if (emailid.Text != "" && password.Text != "")
            {
                string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                string query = "select * from patient_signup where email=@email and password=@password";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", emailid.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    MessageBox.Show("Login Successful for patient", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rd.Read(); // ei method ta important .. 
                    patient_Id = Convert.ToInt32(rd["Patient_Id"]);
                    firstName = rd["FirstName"].ToString();
                    lastName =  rd["LastName"].ToString();
                    nationality = rd["Nationality"].ToString();
                    email = rd["Email"].ToString();
                    userName = rd["UserName"].ToString();
                    gender = rd["Gender"].ToString();
                    age =  Convert.ToInt32(rd["Age"]);
                    bloodGroup = rd["BloodGroup"].ToString();
                    address = rd["Address"].ToString();
                    mobileNumber = Convert.ToInt32(rd["MobileNumber"]);
                    pincode = rd["Password"].ToString();
                    
                    PatientProfile patientBase = new PatientProfile(rd["Patient_Id"].ToString());
                    this.Hide();
                    patientBase.Show(); 
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

        private void emailid_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailid_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(emailid.Text) == true)
            {
                emailid.Focus();
                errorProvider1.SetError(this.emailid, "Please Fill the EmailID!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void password_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(password.Text) == true)
            {
                password.Focus();
                errorProvider1.SetError(this.password, "Please Fill the password!");
            }
            else
            {
                errorProvider2.Clear();
            }

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            emailid.Clear();
            password.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool check=checkBox1.Checked;
            switch (check)
            {
                case true:
                    password.UseSystemPasswordChar = false;
                    break;
                default:
                    password.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void PatientLogin_Load(object sender, EventArgs e)
        {

        }
    }
    }

