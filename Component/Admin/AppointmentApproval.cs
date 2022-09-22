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
using LOGIN_FORM;

namespace ABC_Hospital_MS.Component.Admin
{
    public partial class AppointmentApproval : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public AppointmentApproval()
        {
            InitializeComponent();
            BindGridView();
        }
        // To Read Data from database and Show those data into tables
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe
            // ekhon query likhte hobe
            string query = "select * from DoctorAppointment";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.ColumnCount = 0;   
            dataGridView1.DataSource = data;
        }

        private void AppointmentApproval_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // jei row select kori .. shetai 0 row
            if (String.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells[5].Value.ToString()) == true)
            {
                serial.Text = "";
            }
            else {
                serial.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
            
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
      
            
            panel1.Show();
           
        }

        // For Approval with serial number ... 
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
            string query = "update DoctorAppointment set PatientId = @PatientId, DoctorId = @DoctorId, SelectedTime = @SelectedTime, SelectedDate = @SelectedDate, ShortNote = @ShortNote, SerialNo = @SerialNo where PatientId = @PatientId and SelectedDate = @SelectedDate and ShortNote = @ShortNote";
            SqlCommand cmd = new SqlCommand(query, con); // con for connection
            cmd.Parameters.AddWithValue("@PatientId", textBox2.Text);
            cmd.Parameters.AddWithValue("@DoctorId", textBox3.Text);
            cmd.Parameters.AddWithValue("@SelectedTime", textBox5.Text);
            cmd.Parameters.AddWithValue("@SelectedDate", DateTime.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@ShortNote", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@SerialNo", serial.Text);
           


            // connection open korbo ekhon
            con.Open();
            int a = cmd.ExecuteNonQuery();
            // kono row update hoile 1 pabo .. na hoile 0 pabo .. 

            if (a > 0)
            {
                if (textBox5.Text.Equals("9 - 10 AM"))
                {
                    SqlConnection con1 = new SqlConnection(cs); // connection string pass kore dite hobe 

                    string query1 = "update DoctorTimeTable set NineToTenAM = @NineToTenAM where DoctorId = @DocId";
                    SqlCommand cmd1 = new SqlCommand(query1, con1);
                    cmd1.Parameters.AddWithValue("@DocId", textBox3.Text);
                    cmd1.Parameters.AddWithValue("@NineToTenAM", "Booked");
                    // connection open korbo ekhon
                    con1.Open();
                    int b = cmd1.ExecuteNonQuery();
                    //if (b > 0)
                    //{
                    //    MessageBox.Show("Time Update for Doctor Time table");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Time can not Update for Doctor Time table");
                    //}
                    con1.Close();


                }
                if (textBox5.Text.Equals("10 - 11 AM")) {
                    SqlConnection con2 = new SqlConnection(cs); // connection string pass kore dite hobe 

                    string query2 = "update DoctorTimeTable set TenToElevenAM = @TenToElevenAM where DoctorId = @DocId";
                    SqlCommand cmd2 = new SqlCommand(query2, con2);
                    cmd2.Parameters.AddWithValue("@DocId", textBox3.Text);
                    cmd2.Parameters.AddWithValue("@TenToElevenAM", "Booked");
                    // connection open korbo ekhon
                    con2.Open();
                    int c = cmd2.ExecuteNonQuery();
                    con2.Close();
                }
                if (textBox5.Text.Equals("12 - 1 PM"))
                {
                    SqlConnection con3 = new SqlConnection(cs); // connection string pass kore dite hobe 

                    string query3 = "update DoctorTimeTable set TwelveToOnePM = @TwelveToOnePM where DoctorId = @DocId";
                    SqlCommand cmd3 = new SqlCommand(query3, con3);
                    cmd3.Parameters.AddWithValue("@DocId", textBox3.Text);
                    cmd3.Parameters.AddWithValue("@TwelveToOnePM", "Booked");
                    // connection open korbo ekhon
                    con3.Open();
                    int d = cmd3.ExecuteNonQuery();
                    con3.Close();
                }
                if (textBox5.Text.Equals("1 - 2 PM"))
                {
                    SqlConnection con4 = new SqlConnection(cs); // connection string pass kore dite hobe 

                    string query4 = "update DoctorTimeTable set OneToTwoPM = @OneToTwoPM where DoctorId = @DocId";
                    SqlCommand cmd4 = new SqlCommand(query4, con4);
                    cmd4.Parameters.AddWithValue("@DocId", textBox3.Text);
                    cmd4.Parameters.AddWithValue("@OneToTwoPM", "Booked");
                    // connection open korbo ekhon
                    con4.Open();
                    int g = cmd4.ExecuteNonQuery();
                    con4.Close();
                }
                if (textBox5.Text.Equals("2 - 3 PM"))
                {
                    SqlConnection con5 = new SqlConnection(cs); // connection string pass kore dite hobe 

                    string query5 = "update DoctorTimeTable set TwoToThreePM = @TwoToThreePM where DoctorId = @DocId";
                    SqlCommand cmd5 = new SqlCommand(query5, con5);
                    cmd5.Parameters.AddWithValue("@DocId", textBox3.Text);
                    cmd5.Parameters.AddWithValue("@TwoToThreePM", "Booked");
                    // connection open korbo ekhon
                    con5.Open();
                    int f = cmd5.ExecuteNonQuery();
                    con5.Close();
                }
                if (textBox5.Text.Equals("3 - 4 PM"))
                {
                    SqlConnection con6 = new SqlConnection(cs); // connection string pass kore dite hobe 

                    string query6 = "update DoctorTimeTable set ThreeToFourPM = @ThreeToFourPM where DoctorId = @DocId";
                    SqlCommand cmd6 = new SqlCommand(query6, con6);
                    cmd6.Parameters.AddWithValue("@DocId", textBox3.Text);
                    cmd6.Parameters.AddWithValue("@ThreeToFourPM", "Booked");
                    // connection open korbo ekhon
                    con6.Open();
                    int f = cmd6.ExecuteNonQuery();
                    con6.Close();
                }
                MessageBox.Show("Information is updated successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                dataGridView1.DataSource = null; //  null na korle error dekhabe  😀😀

                // jodi update hoy .. taile amra Doctor id er jonno patient er new selected time ta 
                // booked kore dibo .. database e doctor time table e ...////////////////////////////////////////////////

               
                BindGridView();
            }
            else
            {
                MessageBox.Show("Sorry ! Updation Failed ..", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
            }
            con.Close();
            panel1.Hide();
        }

        private void DoctorListBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome ah = new AdminHome();
            ah.Show();
        }

        private void AdminLoginBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin al = new AdminLogin();   
            al.Show();  
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
