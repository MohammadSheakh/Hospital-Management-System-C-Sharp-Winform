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
using LOGIN_FORM.Component.Doctor;
using LOGIN_FORM.Component.Patient;
using ABC_Hospital_MS.Component.Patient;
using LOGIN_FORM;
using ABC_Hospital_MS.Component.ExtraFeature;

namespace ABC_Hospital_MS.Component.Doctor
{
    public partial class DoctorTimeTable : Form
    { 
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        int doctorId; 
        public DoctorTimeTable(int docId)
        {
            
            InitializeComponent();
            doctorIdTxtBox.Text = DoctorLoginForm.doctorId.ToString();
            doctorId = docId;
            if (PatientLogin.patient_Id > 199)
            {
                button15.Hide();// doctor na hoile she profile dekhte parbe na .. 
                       
            }

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
                userName.Text = rd1["FullName"].ToString();
                department.Text = rd1["Department"].ToString();
                degree.Text = rd1["Degree"].ToString();
                medicalCollege.Text = rd1["MedicalCollege"].ToString();
                label1.Text = rd1["FullName"].ToString();


                con1.Close();
            }
            if(PatientLogin.patient_Id > 199)
            {
                SqlConnection con2 = new SqlConnection(cs);
                string query2 = "select * from Patient_SignUp where Patient_Id=@Patient_Id";
                SqlCommand cmd2 = new SqlCommand(query2, con2);
                cmd2.Parameters.AddWithValue("@Patient_Id", PatientLogin.patient_Id);
                con2.Open();
                SqlDataReader rd2 = cmd2.ExecuteReader();
                if (rd2.HasRows == true)
                {
                    rd2.Read();
                   
                    label1.Text = rd2["FirstName"].ToString();
                    
                    con2.Close();
                }
            }
            // else er part ta kora hoy nai .. 
            //BindGridView();
            /////////////////////////////////////////////////////////////////////////////////////////////
            if (DoctorLoginForm.doctorId < 199 && PatientLogin.patient_Id < 200) {
                takeAppointMent.Hide();
                followBtn.Hide();
                // Doctor can add, update his timetable ..
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from DoctorTimeTable where DoctorId = @DoctorId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DoctorId", doctorIdTxtBox.Text);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    // jodi paowa jay .. taile kichui korbo na ... 
                    //dataGridView1.DataSource = null;
                    BindGridView();
                    panel2.Hide();
                    doctorId = docId;
                }
                else
                {
                    // na paile insert korte hobe 
                    
                    SqlConnection con3 = new SqlConnection(cs); // connection string pass kore dite hobe 
                    string query3 = "insert into DoctorTimeTable values(@DoctorId, @NineToTenAM, @TenToElevenAM, @TwelveToOnePM, @OneToTwoPM, @TwoToThreePM, @ThreeToFourPM)";
                    SqlCommand cmd3 = new SqlCommand(query3, con3); // con for connection
                    cmd3.Parameters.AddWithValue("@DoctorId", Convert.ToInt32(doctorIdTxtBox.Text));
                    cmd3.Parameters.AddWithValue("@NineToTenAM", "");
                    cmd3.Parameters.AddWithValue("@TenToElevenAM", "");
                    cmd3.Parameters.AddWithValue("@TwelveToOnePM", "");
                    cmd3.Parameters.AddWithValue("@OneToTwoPM", "");
                    cmd3.Parameters.AddWithValue("@TwoToThreePM", "");
                    cmd3.Parameters.AddWithValue("@ThreeToFourPM", "");
                    // connection open korbo ekhon
                    con3.Open();
                    int a = cmd3.ExecuteNonQuery(); //  insert korar jonno  // eta kichu integer return korbe
                                                    // 1 row insert korle 1 return korbe 
                    if (a > 0)
                    {
                        //dataGridView1.DataSource = null;
                        BindGridView();
                        panel2.Hide();
                        doctorId = docId;
                    }
                    else
                    {
                        MessageBox.Show("value can not be inserted !", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                    }
                    con3.Close();
                }
                con.Close();
            }
            else
            {
                // Patient can watch time table
                BindGridView();
                //dataGridView1.DataSource = null;
                
                panel2.Hide();
                // patient jeno grid view te double click na korte pare .. shei bebostha korte hobe 
            }

            


            


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //BindGridView();
        }

        // To Read Data from database and Show those data into tables
        void BindGridView()
        {
           
            doctorIdTxtBox.Text = DoctorLoginForm.doctorId.ToString();
            
            SqlConnection con3 = new SqlConnection(cs); 
            //string query2 = "select * from DoctorTimeTable";
            string query = "select DoctorId, NineToTenAM, TenToElevenAM, TwelveToOnePM, OneToTwoPM, TwoToThreePM, ThreeToFourPM from DoctorTimeTable where DoctorId = @id";
            SqlCommand cmd3 = new SqlCommand(query, con3);
            
            SqlDataAdapter sda = new SqlDataAdapter(query, con3);
            sda.SelectCommand.Parameters.AddWithValue("@id", doctorIdTxtBox.Text);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.ColumnCount = 0; 
            dataGridView1.DataSource = data;

        }

        


        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           // BindGridView();
        }

        private void DoctorTimeTable_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dataGridView1.Hide();
            doctorIdTxtBox.Text =  DoctorLoginForm.doctorId.ToString();

            //doctorIdTxtBox.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            // jei row select kori .. shetai 0 row
            // textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (DoctorLoginForm.doctorId < 199 && PatientLogin.patient_Id < 200)
            {
                if (dataGridView1.SelectedRows[0].Cells[1].Value.ToString() == "Free")
                {
                    FreeRBtn1.Checked = true;
                }
                else if (dataGridView1.SelectedRows[0].Cells[1].Value.ToString() == "Booked")
                {
                    bookedRBtn1.Checked = true;
                }
                else if (dataGridView1.SelectedRows[0].Cells[1].Value.ToString() == "Off")
                {
                    offRBtn1.Checked = true;
                }
                else
                {
                    FreeRBtn1.Checked = false;
                    bookedRBtn1.Checked = false;
                    offRBtn1.Checked = false;
                }
                ////////////////////////////////////////////////////////////////////////////
                if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString() == "Free")
                {
                    FreeRBtn2.Checked = true;
                }
                else if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString() == "Booked")
                {
                    bookedRBtn2.Checked = true;
                }
                else if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString() == "Off")
                {
                    offRBtn2.Checked = true;
                }
                else
                {
                    FreeRBtn2.Checked = false;
                    bookedRBtn2.Checked = false;
                    offRBtn2.Checked = false;
                }
                ////////////////////////////////////////////////////////////////////////////
                if (dataGridView1.SelectedRows[0].Cells[3].Value.ToString() == "Free")
                {
                    FreeRBtn3.Checked = true;
                }
                else if (dataGridView1.SelectedRows[0].Cells[3].Value.ToString() == "Booked")
                {
                    bookedRBtn3.Checked = true;
                }
                else if (dataGridView1.SelectedRows[0].Cells[3].Value.ToString() == "Off")
                {
                    offRBtn3.Checked = true;
                }
                else
                {
                    FreeRBtn3.Checked = false;
                    bookedRBtn3.Checked = false;
                    offRBtn3.Checked = false;
                }
                ////////////////////////////////////////////////////////////////////////////
                if (dataGridView1.SelectedRows[0].Cells[4].Value.ToString() == "Free")
                {
                    FreeRBtn4.Checked = true;
                }
                else if (dataGridView1.SelectedRows[0].Cells[4].Value.ToString() == "Booked")
                {
                    bookedRBtn4.Checked = true;
                }
                else if (dataGridView1.SelectedRows[0].Cells[4].Value.ToString() == "Off")
                {
                    offRBtn4.Checked = true;
                }
                else
                {
                    FreeRBtn4.Checked = false;
                    bookedRBtn4.Checked = false;
                    offRBtn4.Checked = false;
                }
                ////////////////////////////////////////////////////////////////////////////
                if (dataGridView1.SelectedRows[0].Cells[5].Value.ToString() == "Free")
                {
                    FreeRBtn5.Checked = true;
                }
                else if (dataGridView1.SelectedRows[0].Cells[5].Value.ToString() == "Booked")
                {
                    bookedRBtn5.Checked = true;
                }
                else if (dataGridView1.SelectedRows[0].Cells[5].Value.ToString() == "Off")
                {
                    offRBtn5.Checked = true;
                }
                else
                {
                    FreeRBtn5.Checked = false;
                    bookedRBtn5.Checked = false;
                    offRBtn5.Checked = false;
                }
                ////////////////////////////////////////////////////////////////////////////
                if (dataGridView1.SelectedRows[0].Cells[6].Value.ToString() == "Free")
                {
                    FreeRBtn6.Checked = true;
                }
                else if (dataGridView1.SelectedRows[0].Cells[6].Value.ToString() == "Booked")
                {
                    bookedRBtn6.Checked = true;
                }
                else if (dataGridView1.SelectedRows[0].Cells[6].Value.ToString() == "Off")
                {
                    offRBtn6.Checked = true;
                }
                else
                {
                    FreeRBtn6.Checked = false;
                    bookedRBtn6.Checked = false;
                    offRBtn6.Checked = false;
                }

                panel2.Show();
            }
            else
            {
                MessageBox.Show("dd");
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        }

        private void ninetoten_Click(object sender, EventArgs e)
        {

        }
        // Update time table of Doctor for Doctor 
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
            
            string query = "update DoctorTimeTable set NineToTenAM = @NineToTenAM, TenToElevenAM = @TenToElevenAM, TwelveToOnePM = @TwelveToOnePM, OneToTwoPM = @OneToTwoPM, TwoToThreePM = @TwoToThreePM, ThreeToFourPM = @ThreeToFourPM where DoctorId = @DoctorId";
            SqlCommand cmd = new SqlCommand(query, con); // con for connection
            
            cmd.Parameters.AddWithValue("@DoctorId", doctorIdTxtBox.Text);

            if (FreeRBtn1.Checked == true)
            {
                cmd.Parameters.AddWithValue("@NineToTenAM", "Free");
            }
            else if (bookedRBtn1.Checked == true)
            {
                cmd.Parameters.AddWithValue("@NineToTenAM", "Booked");
            }
            else if (offRBtn1.Checked == true) {
                cmd.Parameters.AddWithValue("@NineToTenAM", "Off");
            }
            else
            {
                cmd.Parameters.AddWithValue("@NineToTenAM", "");
            }
            /////////////////////////////////////////////////////
            if (FreeRBtn2.Checked == true)
            {
                cmd.Parameters.AddWithValue("@TenToElevenAM", "Free");
            }
            else if (bookedRBtn2.Checked == true)
            {
                cmd.Parameters.AddWithValue("@TenToElevenAM", "Booked");
            }
            else if (offRBtn2.Checked == true)
            {
                cmd.Parameters.AddWithValue("@TenToElevenAM", "Off");
            }
            else
            {
                cmd.Parameters.AddWithValue("@TenToElevenAM", "");
            }
            /////////////////////////////////////////////////////
            if (FreeRBtn3.Checked == true)
            {
                cmd.Parameters.AddWithValue("@TwelveToOnePM", "Free");
            }
            else if (bookedRBtn3.Checked == true)
            {
                cmd.Parameters.AddWithValue("@TwelveToOnePM", "Booked");
            }
            else if (offRBtn3.Checked == true)
            {
                cmd.Parameters.AddWithValue("@TwelveToOnePM", "Off");
            }
            else
            {
                cmd.Parameters.AddWithValue("@TwelveToOnePM", "");
            }
            /////////////////////////////////////////////////////
            if (FreeRBtn4.Checked == true)
            {
                cmd.Parameters.AddWithValue("@OneToTwoPM", "Free");
            }
            else if (bookedRBtn4.Checked == true)
            {
                cmd.Parameters.AddWithValue("@OneToTwoPM", "Booked");
            }
            else if (offRBtn4.Checked == true)
            {
                cmd.Parameters.AddWithValue("@OneToTwoPM", "Off");
            }
            else
            {
                cmd.Parameters.AddWithValue("@OneToTwoPM", "");
            }
            /////////////////////////////////////////////////////
            if (FreeRBtn5.Checked == true)
            {
                cmd.Parameters.AddWithValue("@TwoToThreePM", "Free");
            }
            else if (bookedRBtn5.Checked == true)
            {
                cmd.Parameters.AddWithValue("@TwoToThreePM", "Booked");
            }
            else if (offRBtn5.Checked == true)
            {
                cmd.Parameters.AddWithValue("@TwoToThreePM", "Off");
            }
            else
            {
                cmd.Parameters.AddWithValue("@TwoToThreePM", "");
            }
            /////////////////////////////////////////////////////
            if (FreeRBtn6.Checked == true)
            {
                cmd.Parameters.AddWithValue("@ThreeToFourPM", "Free");
            }
            else if (bookedRBtn6.Checked == true)
            {
                cmd.Parameters.AddWithValue("@ThreeToFourPM", "Booked");
            }
            else if (offRBtn6.Checked == true)
            {
                cmd.Parameters.AddWithValue("@ThreeToFourPM", "Off");
            }
            else
            {
                cmd.Parameters.AddWithValue("@ThreeToFourPM", "");
            }


            // connection open korbo ekhon
            con.Open();
            int a = cmd.ExecuteNonQuery();
            // kono row update hoile 1 pabo .. na hoile 0 pabo .. 

            if (a > 0)
            {
                panel2.Hide();
                MessageBox.Show("Information is updated successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                dataGridView1.DataSource = null; //  null na korle error dekhabe  😀😀
                BindGridView();
            }
            else
            {
                MessageBox.Show("Sorry ! Updation Failed ..", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
            }
            con.Close();
            dataGridView1.Show();
            //panel1.Hide();
        }

        private void doctorIdTxtBox_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorProfile dp = new DoctorProfile(doctorId);
            dp.Show(); 
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorProfile dp = new DoctorProfile(doctorId);
            dp.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (PatientLogin.patient_Id > 199)
            {
                this.Hide();
                PatientProfile pp = new PatientProfile(PatientLogin.patient_Id.ToString());
                pp.Show();
            }
            else
            {

            }
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();  
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorTimeTable dtt = new DoctorTimeTable(doctorId);
            dtt.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorArticle da = new DoctorArticle(doctorId, userName.Text);
            da.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainFeedback mfb = new MainFeedback();
            mfb.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorsCurrentPatientList dcpl = new DoctorsCurrentPatientList(doctorId);
            dcpl.Show();
        }
    }
}
