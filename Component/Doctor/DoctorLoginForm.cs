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
using LOGIN_FORM.Component.Admin;

namespace LOGIN_FORM.Component.Doctor
{
    public partial class DoctorLoginForm : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public static int doctorId;
        public static string fullName;
        public static string department;
        public static string degree;
        public static string medicalCollege;
        public static int experience;
        public static int doctorPassword;
        
        public DoctorLoginForm()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(DoctorId.Text != "" && DoctorPassword.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from Doctor where DoctorId=@DoctorId and DoctorPassword=@DoctorPassword";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DoctorId", DoctorId.Text);
                cmd.Parameters.AddWithValue("@DoctorPassword", DoctorPassword.Text);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    MessageBox.Show("Doctor Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    rd.Read();

                    doctorId = Convert.ToInt32(rd["DoctorId"]);
                    fullName = rd["FullName"].ToString();
                    department = rd["Department"].ToString();
                    degree = rd["Degree"].ToString();
                    medicalCollege = rd["MedicalCollege"].ToString();
                    experience = Convert.ToInt32(rd["Experience"]);
                    doctorPassword = Convert.ToInt32(rd["DoctorPassword"]);
                    
                    DoctorProfile docProfile = new DoctorProfile(doctorId);
                    docProfile.Show();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Doctor Login Failed!", "Email or Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Fill Both Fields");
            }
            

            
        }

        private void DoctorLoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdminLogin al = new AdminLogin();
            al.Show();
        }
    }
}
