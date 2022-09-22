using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LOGIN_FORM.Component.Admin;
using System.Configuration;
using System.Data.SqlClient;
using ABC_Hospital_MS.Component.Doctor;
using LOGIN_FORM.Component.Patient;
using ABC_Hospital_MS.Component.Patient;

namespace LOGIN_FORM.Component.Doctor
{
    public partial class DoctorProfile : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        
        public DoctorProfile()
        {
            InitializeComponent();
           
        }
        int DoctorId;
        //string currentPatientId;
        public DoctorProfile(int doctorId)
        {
            
            InitializeComponent();
            DoctorId = doctorId;

            // amra ei doctor id er jonno doctor er shob information database theke niye ashbo .. 
            SqlConnection con1 = new SqlConnection(cs);
            string query1 = "select * from Doctor where DoctorId=@DoctorId";
            SqlCommand cmd1 = new SqlCommand(query1, con1);
            cmd1.Parameters.AddWithValue("@DoctorId", DoctorId.ToString());
            con1.Open();
            SqlDataReader rd = cmd1.ExecuteReader();
            if (rd.HasRows == true)
            {
                rd.Read();
                doctorId = Convert.ToInt32(rd["DoctorId"]);
                if (PatientLogin.patient_Id > 199)
                {
                    label18.Text = PatientLogin.firstName.ToString();
                }
                else
                {
                    label18.Text = rd["FullName"].ToString();
                }
                userName.Text = rd["FullName"].ToString();
                department.Text = rd["Department"].ToString();
                degree.Text = rd["Degree"].ToString();
                medicalCollege.Text = rd["MedicalCollege"].ToString();
                ////////////////////////////////////////////////////////////
               
                textBox1.Text = rd["FullName"].ToString();
                textBox2.Text = rd["Department"].ToString();
                textBox4.Text = rd["Degree"].ToString();
                textBox5.Text = rd["MedicalCollege"].ToString();
                textBox3.Text = rd["Experience"].ToString();
                textBox6.Text = rd["DoctorPassword"].ToString();
                
                con1.Close();
                
            }
            else
            {
                MessageBox.Show("Sorry");
            }

            
            ////////////////////////////////////////////////////////////////////////
             
            // ekhanei may be kichu ekta korte hobe .. 
            if (DoctorLoginForm.doctorId < 199 && PatientLogin.patient_Id < 200)
            {
                takeAppointMent.Hide();
                followBtn.Hide();
            }

        }

        public void loadDataFromDatabase()
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DoctorProfile_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorArticle da = new DoctorArticle(DoctorId, userName.Text);
            da.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Sign out btn e click kora hoile sign out hoye jabe .. Home page e move korbe
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AppointmentFormPage appointmentForm = new AppointmentFormPage(DoctorId);
            appointmentForm.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorTimeTable doctorTimeTable = new DoctorTimeTable(DoctorId);
            doctorTimeTable.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorsCurrentPatientList dcpl = new DoctorsCurrentPatientList(DoctorId);
            dcpl.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        // update information ... for doctor ... 
        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
            string query = "update Doctor set FullName = @FullName, Department = @Department, Degree = @Degree, MedicalCollege = @MedicalCollege, Experience = @Experience, DoctorPassword = @DoctorPassword where DoctorId = @DoctorId";
            SqlCommand cmd = new SqlCommand(query, con); // con for connection
            cmd.Parameters.AddWithValue("@DoctorId", DoctorId);

            cmd.Parameters.AddWithValue("@FullName", textBox1.Text);
            cmd.Parameters.AddWithValue("@Department", textBox2.Text);
            cmd.Parameters.AddWithValue("@Degree", textBox4.Text);
            cmd.Parameters.AddWithValue("@MedicalCollege", textBox5.Text);
            cmd.Parameters.AddWithValue("@Experience", textBox3.Text);
            cmd.Parameters.AddWithValue("@DoctorPassword", textBox6.Text);



            // connection open korbo ekhon
            con.Open();
            int a = cmd.ExecuteNonQuery();
            // kono row update hoile 1 pabo .. na hoile 0 pabo .. 

            if (a > 0)
            {
                MessageBox.Show("Information is updated successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                this.Hide();
                DoctorProfile dp = new DoctorProfile(DoctorId);
                dp.Show();
            }
            else
            {
                MessageBox.Show("Sorry ! Updation Failed ..", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
            }
            con.Close();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            if (PatientLogin.patient_Id > 199)
            {
                this.Hide();
                PatientProfile pp = new PatientProfile(PatientLogin.patient_Id.ToString());
                pp.Show();
            }
            else if (DoctorLoginForm.doctorId < 199)
            {
                this.Hide();
                DoctorProfile pp = new DoctorProfile(DoctorLoginForm.doctorId);
                pp.Show();
            }
        }
    }
}
