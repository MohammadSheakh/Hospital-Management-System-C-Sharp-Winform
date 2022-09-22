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

namespace LOGIN_FORM.Component.Doctor
{
    public partial class DoctorsCurrentPatientList : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        ///public DoctorsCurrentPatientList()
        //{
         //   InitializeComponent();
        //    if (DoctorLoginForm.doctorId < 199 && PatientLogin.patient_Id < 200)
        //    {
        //        takeAppointMent.Hide();
        //        followBtn.Hide();
        //        BindGridView();
        //        panel7.Hide();
        //    }
       //     panel7.Hide();
       // }
        int DocId;
        public DoctorsCurrentPatientList(int doctorId)
        {
            DocId = doctorId;
            InitializeComponent();
            // amra ei doctor id er jonno doctor er shob information database theke niye ashbo .. 
            SqlConnection con1 = new SqlConnection(cs);
            string query1 = "select * from Doctor where DoctorId=@DoctorId";
            SqlCommand cmd1 = new SqlCommand(query1, con1);
            cmd1.Parameters.AddWithValue("@DoctorId", doctorId.ToString());
            con1.Open();
            SqlDataReader rd1 = cmd1.ExecuteReader();
            if (rd1.HasRows == true)
            {
                rd1.Read();
                doctorId = Convert.ToInt32(rd1["DoctorId"]);
                label1.Text = rd1["FullName"].ToString();
                department.Text = rd1["Department"].ToString();
                degree.Text = rd1["Degree"].ToString();
                medicalCollege.Text = rd1["MedicalCollege"].ToString();

                con1.Close();
            }
            else
            {
                MessageBox.Show("Sorry");
            }
            if (DoctorLoginForm.doctorId < 199 && PatientLogin.patient_Id < 200)
            {
                takeAppointMent.Hide();
                followBtn.Hide();
                BindGridView();
                panel7.Hide();
            }
            panel7.Hide();
        }
        void BindGridView()
        {

            // doctorIdTxtBox.Text = DoctorLoginForm.doctorId.ToString();

            SqlConnection con3 = new SqlConnection(cs);
          
            string query = "select PatientId, DoctorId, SelectedTime, SelectedDate, ShortNote, SerialNo from DoctorAppointment where DoctorId = @id and SerialNo > 0";
            SqlCommand cmd3 = new SqlCommand(query, con3);

            SqlDataAdapter sda = new SqlDataAdapter(query, con3);
            sda.SelectCommand.Parameters.AddWithValue("@id", DoctorLoginForm.doctorId.ToString());
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.ColumnCount = 0;
            dataGridView1.DataSource = data;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DoctorsCurrentPatientList_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // jei row select kori .. shetai 0 row
            if (String.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells[5].Value.ToString()) == true)
            {
                serial.Text = "";
            }
            else
            {
                serial.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }

            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();


            panel7.Show();
        }

        // 😀 For Delete a Appointment 
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
            string query = "delete from DoctorAppointment where PatientId = @PatientId and SerialNo = @SerialNo";
            SqlCommand cmd = new SqlCommand(query, con); // con for connection
            cmd.Parameters.AddWithValue("@PatientId", textBox2.Text); // koi theke ashbe .. textbox theke ashbe 
            cmd.Parameters.AddWithValue("@SerialNo", serial.Text);


            // connection open korbo ekhon
            con.Open();
            int a = cmd.ExecuteNonQuery();



            // ekhon row delete hoye gele .. a er value hobe 1  .. delete na hoile a er value 0 hobe 
            if (a > 0)
            {
                MessageBox.Show("Deleted successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                dataGridView1.DataSource = null; //  null na korle error dekhabe  😀😀
                BindGridView();
            }
            else
            {
                MessageBox.Show("Sorry ! Can not be Deleted..", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
            }
            con.Close();
            panel7.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorProfile dp = new DoctorProfile(DocId);
            dp.Show();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            panel7.Hide();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorProfile dp = new DoctorProfile(DocId);
            dp.Show();
        }
    }
}
