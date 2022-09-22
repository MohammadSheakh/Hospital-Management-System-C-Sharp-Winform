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
using LOGIN_FORM.Component.Doctor;
using LOGIN_FORM;

namespace ABC_Hospital_MS.Component.Doctor
{
    public partial class AppointmentFormPage : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        int CurrentDocId;
        string currentPatientId;

        public static string doctorId;
        public static string nineToTenAM;
        public static string tenToElevenAM;
        public static string twelveToOnePM;
        public static string oneToTwoPM;
        public static string twoToThreePM;
        public static string threeToFourPM;

        public AppointmentFormPage(int doctorId)
        {
            CurrentDocId = doctorId;
            InitializeComponent();
            // age data load hobe .. then grid view te dekhabe ... patient jei doctor er profile e ashse .. tar data load hoite hobe .. 
            BindGridView();
            currentPatientId = currentPatientId;
            textBox1.Text = PatientLogin.patient_Id.ToString();
            textBox2.Text = doctorId.ToString();

            if(nineToTenAM == "Booked" || nineToTenAM == "Off")
            {
                NineToTen.Hide();
            }
            if(tenToElevenAM == "Booked" || tenToElevenAM == "Off")
            {
                TenToEleven.Hide();
            }
            if (twelveToOnePM == "Booked" || twelveToOnePM == "Off")
            {
                TwelveToOne.Hide();
            }
            if (oneToTwoPM == "Booked" || oneToTwoPM == "Off")
            {
                OneToTwo.Hide();
            }
            if (twoToThreePM == "Booked" || twoToThreePM == "Off")
            {
                TwoToThree.Hide();
            }
            if (threeToFourPM == "Booked" || threeToFourPM == "Off")
            {
                ThreeToFour.Hide();
            }


        }

        private void AppointmentFormPage_Load(object sender, EventArgs e)
        {

        }
        void BindGridView()
        {
            
            
            SqlConnection con3 = new SqlConnection(cs);
            
            string query = "select DoctorId, NineToTenAM, TenToElevenAM, TwelveToOnePM, OneToTwoPM, TwoToThreePM, ThreeToFourPM from DoctorTimeTable where DoctorId = @id";
            SqlCommand cmd3 = new SqlCommand(query, con3);
            //////////////////////////////////////////////////////////////////////////////////////////////////
            con3.Open();
            cmd3.Parameters.AddWithValue("@id", CurrentDocId.ToString());
            SqlDataReader rd = cmd3.ExecuteReader();
            if (rd.HasRows == true)
            {
                rd.Read();
                doctorId = rd["DoctorId"].ToString();
                nineToTenAM = rd["NineToTenAM"].ToString();
                tenToElevenAM = rd["TenToElevenAM"].ToString();
                twelveToOnePM = rd["TwelveToOnePM"].ToString();
                oneToTwoPM = rd["OneToTwoPM"].ToString();
                twoToThreePM = rd["TwoToThreePM"].ToString();
                threeToFourPM = rd["ThreeToFourPM"].ToString();
                /////////////////////////////////////////////////////////////////////////
                SqlDataAdapter sda = new SqlDataAdapter(query, con3);
                sda.SelectCommand.Parameters.AddWithValue("@id", CurrentDocId.ToString());
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.ColumnCount = 0;
                dataGridView1.DataSource = data;
            }


                
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void takeAppointment_Click(object sender, EventArgs e)
        {
            AppointmentFormPage afpage = new AppointmentFormPage(CurrentDocId);
            afpage.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Request For Appointment
        private void button17_Click(object sender, EventArgs e)
        {
            
            // Doctor Appointment Database table e ekta appointment insert korte hobe .. 
            SqlConnection con1 = new SqlConnection(cs);
            string query1 = "insert into DoctorAppointment values(@PatientId, @DoctorId, @SelectedTime, @SelectedDate, @ShortNote, @SerialNo)";
            SqlCommand cmd1 = new SqlCommand(query1, con1);
            cmd1.Parameters.AddWithValue("@PatientId", Convert.ToInt32(textBox1.Text));
            cmd1.Parameters.AddWithValue("@DoctorId", textBox2.Text);
            if (NineToTen.Checked)
            {
               
                cmd1.Parameters.AddWithValue("@SelectedTime", NineToTen.Text);
            }
            if (TenToEleven.Checked)
            {
                
                cmd1.Parameters.AddWithValue("@SelectedTime", TenToEleven.Text);
            }
            if (TwelveToOne.Checked)
            {
              
                cmd1.Parameters.AddWithValue("@SelectedTime", TwelveToOne.Text);
            }
            if (OneToTwo.Checked)
            {
               
                cmd1.Parameters.AddWithValue("@SelectedTime", OneToTwo.Text);
            }
            if (TwoToThree.Checked)
            {
                
                cmd1.Parameters.AddWithValue("@SelectedTime", TwoToThree.Text);
            }
            if (ThreeToFour.Checked)
            {
      
                cmd1.Parameters.AddWithValue("@SelectedTime", ThreeToFour.Text);
            }
            
            cmd1.Parameters.AddWithValue("@SelectedDate", dateTimePicker1.Value);
            cmd1.Parameters.AddWithValue("@ShortNote", richTextBox1.Text);
            cmd1.Parameters.AddWithValue("@SerialNo", "");
            con1.Open();
            int a = cmd1.ExecuteNonQuery(); //  insert korar jonno  // eta kichu integer return korbe
                                            // 1 row insert korle 1 return korbe 
            if (a > 0)
            {
                MessageBox.Show("inserted successfully ! Please Wait for Admin Approval", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 

                this.Hide();
                PatientProfile patientProfile = new PatientProfile(PatientLogin.patient_Id.ToString());
                patientProfile.Show();
            }
            else
            {
                MessageBox.Show("Sorry, value can not be inserted !", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
            }
            con1.Close();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorProfile dp = new DoctorProfile();
            dp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();


        }

        private void button16_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //DoctorArticle da = new DoctorArticle(CurrentDocId, userName.Text);
            //da.Show();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }
    }
}
