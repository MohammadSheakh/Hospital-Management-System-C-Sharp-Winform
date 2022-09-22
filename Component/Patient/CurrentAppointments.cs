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
using LOGIN_FORM;

namespace ABC_Hospital_MS.Component.Patient
{
    public partial class CurrentAppointments : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        string pid;
        string customFirstName;
        string customLastName;
        public CurrentAppointments()
        {
            InitializeComponent();
            BindGridView();
        }
        public CurrentAppointments(string patientId)
        {
            pid = patientId;
            InitializeComponent();
            BindGridView();

            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            string query = "select * from patient_signup where Patient_Id=@Patient_Id";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Patient_Id", pid);

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

            }
        }
        void BindGridView()
        {

            // doctorIdTxtBox.Text = DoctorLoginForm.doctorId.ToString();

            SqlConnection con3 = new SqlConnection(cs);

            string query = "select PatientId, DoctorId, SelectedTime, SelectedDate, ShortNote, SerialNo from DoctorAppointment where PatientId = @id and SerialNo > 0";
            SqlCommand cmd3 = new SqlCommand(query, con3);

            SqlDataAdapter sda = new SqlDataAdapter(query, con3);
            sda.SelectCommand.Parameters.AddWithValue("@id", PatientLogin.patient_Id.ToString());
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.ColumnCount = 0;
            dataGridView1.DataSource = data;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientProfile pp = new PatientProfile(PatientLogin.patient_Id.ToString());
            pp.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowDoctorList sdl = new ShowDoctorList();
            sdl.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
