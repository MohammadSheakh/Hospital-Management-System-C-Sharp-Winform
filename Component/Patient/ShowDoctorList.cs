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
using LOGIN_FORM;
using LOGIN_FORM.Component.Doctor;
using ABC_Hospital_MS.Component.ExtraFeature;

namespace ABC_Hospital_MS.Component.Patient
{
    public partial class ShowDoctorList : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        string pid;
        string customFirstName;
        string customLastName;
        public ShowDoctorList()
        {
            InitializeComponent();
            
            panel4.Hide();
        }
        public ShowDoctorList(string patientId)
        {
            pid = patientId;
            InitializeComponent();

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

            panel4.Hide();
        }

        private void ShowDoctorList_Load(object sender, EventArgs e)
        {

        }

        private void FindDoctor_Click(object sender, EventArgs e)
        {
            if (SelectDepartment != null)
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from Doctor where Department=@Department";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Department", SelectDepartment.SelectedItem);

                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows == true)
                {

                    // connection string pass kore dite hobe
                    // ekhon query likhte hobe
                    con.Close();

                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.Parameters.AddWithValue("@Department", SelectDepartment.SelectedItem.ToString());


                    DataTable data = new DataTable();
                    sda.Fill(data);
                    // dataGridView1.ColumnCount = 0;     😀😀😀😀😀
                    dataGridView1.DataSource = data;
                    panel4.Show();


                }
                else
                {
                    MessageBox.Show("Department Not Found!");

                }
            }
            else
            {
                MessageBox.Show("Please Fill Both Fields");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int selectedDoctorId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            this.Hide();
            DoctorProfile doctorProfile = new DoctorProfile(selectedDoctorId);
            doctorProfile.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            FloorMap1 fm = new FloorMap1();
            fm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainFeedback mf = new MainFeedback();
            mf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientProfile pp = new PatientProfile(pid);
            pp.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowDoctorList sdl = new ShowDoctorList(pid);
            sdl.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainFeedback mf = new MainFeedback();
            mf.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           // ei patient er favourit article gula dekhabe ekhane .. 
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            CurrentAppointments currentAppoints = new CurrentAppointments(pid);
            currentAppoints.Show();
        }
    }
}
