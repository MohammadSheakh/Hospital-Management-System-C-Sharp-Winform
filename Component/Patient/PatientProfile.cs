using ABC_Hospital_MS.Component.ExtraFeature;
using LOGIN_FORM;
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

namespace ABC_Hospital_MS.Component.Patient
{
    public partial class PatientProfile : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        //public PatientProfile()
        //{
        //    InitializeComponent();
        //}
        string currentPatientId;
        string customFirstName;
        string customLastName;
    
        public PatientProfile(string patientId)
        {
            InitializeComponent();
            currentPatientId = patientId;

            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            string query = "select * from patient_signup where Patient_Id=@Patient_Id";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Patient_Id", currentPatientId);
           
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows == true)
            {
                rd.Read();
                //patient_Id = Convert.ToInt32(rd["Patient_Id"]);
                
                customFirstName = rd["FirstName"].ToString();
                customLastName = rd["LastName"].ToString();
                userName.Text = customFirstName + customLastName;
                label2.Text = rd["BloodGroup"].ToString();
                address.Text = rd["Address"].ToString();
                label4.Text = rd["MobileNumber"].ToString();
                ///////////////////////////////////////////////////////



                textBox1.Text = rd["Address"].ToString();
                textBox2.Text = rd["MobileNumber"].ToString();
                textBox3.Text = rd["Email"].ToString();
                textBox4.Text = rd["BloodGroup"].ToString();
                textBox5.Text = rd["Age"].ToString();
                textBox6.Text = rd["Password"].ToString();


            }


        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientProfile pp = new PatientProfile(currentPatientId);
            pp.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainFeedback mainFeedback = new MainFeedback();
            mainFeedback.Show();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowDoctorList sdl = new ShowDoctorList(currentPatientId);
            sdl.Show();
        }

        private void PatientProfile_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            CurrentAppointments currentAppoints = new CurrentAppointments(currentPatientId);
            currentAppoints.Show();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FloorMap1 fm = new FloorMap1();
            fm.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainFeedback mf = new MainFeedback();
            mf.Show();
        }

        // for update information ... 
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
            string query = "update Patient_SignUp set Address = @Address, MobileNumber = @MobileNumber, Email = @Email, BloodGroup = @BloodGroup, Age = @Age, Password = @Password where Patient_Id = @Patient_Id";
            SqlCommand cmd = new SqlCommand(query, con); // con for connection
            cmd.Parameters.AddWithValue("@Patient_Id", currentPatientId);

            cmd.Parameters.AddWithValue("@Address", textBox1.Text);
            cmd.Parameters.AddWithValue("@MobileNumber", textBox2.Text);
            cmd.Parameters.AddWithValue("@Email", textBox3.Text);
            cmd.Parameters.AddWithValue("@BloodGroup", textBox4.Text);
            cmd.Parameters.AddWithValue("@Age", textBox5.Text);
            cmd.Parameters.AddWithValue("@Password", textBox6.Text);


            // connection open korbo ekhon
            con.Open();
            int a = cmd.ExecuteNonQuery();
            // kono row update hoile 1 pabo .. na hoile 0 pabo .. 

            if (a > 0)
            {
                MessageBox.Show("Information is updated successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                this.Hide();
                PatientProfile pp = new PatientProfile(currentPatientId);
                pp.Show();
            }
            else
            {
                MessageBox.Show("Sorry ! Updation Failed ..", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
            }
            con.Close();
        }
    }
}
