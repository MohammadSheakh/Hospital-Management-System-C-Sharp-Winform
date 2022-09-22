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
using LOGIN_FORM.Component.Admin;
using LOGIN_FORM;
using ABC_Hospital_MS.Component.Patient;
using ABC_Hospital_MS.Component.Doctor;

namespace LOGIN_FORM.Component.Doctor
{
    public partial class DoctorArticle : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        int doctorId;
        string FullName;
        string email;
        string status;
        string articleCode;

        string likeStatus;
        string dislikeStatus;
        
        public DoctorArticle(int docId, string docName)
        {
            doctorId = docId;
            FullName = docName;
           
              
            InitializeComponent();
            // BindGridView();
            textBox1.Text = DoctorLoginForm.doctorId.ToString();
            textBox6.Text = DoctorLoginForm.fullName;

            // amra ei doctor id er jonno doctor er shob information database theke niye ashbo .. 
            SqlConnection con5 = new SqlConnection(cs);
            string query5 = "select * from Doctor where DoctorId=@DoctorId";
            SqlCommand cmd5 = new SqlCommand(query5, con5);
            cmd5.Parameters.AddWithValue("@DoctorId", doctorId.ToString());
            con5.Open();
            SqlDataReader rd5 = cmd5.ExecuteReader();
            if (rd5.HasRows == true)
            {
                rd5.Read();
                doctorId = Convert.ToInt32(rd5["DoctorId"]);
                if(PatientLogin.patient_Id > 199)
                {
                    label1.Text = PatientLogin.firstName.ToString();
                }
                else
                {
                    label1.Text = rd5["FullName"].ToString();
                }
                
                userName.Text = rd5["FullName"].ToString();
                department.Text = rd5["Department"].ToString();
                degree.Text = rd5["Degree"].ToString();
                medicalCollege.Text = rd5["MedicalCollege"].ToString();

                con5.Close();
            }
            else
            {
               // MessageBox.Show("Sorry");
            }



            if (DoctorLoginForm.doctorId < 199 && PatientLogin.patient_Id < 200)
            {
                // Doctor can add, update his timetable ..
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from DoctorArticle where Doctor_Id = @Doctor_Id and Doctor_Name=@Doctor_Name";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Doctor_Id", textBox1.Text);
                cmd.Parameters.AddWithValue("@Doctor_Name", textBox6.Text);
                

                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    // jodi paowa jay .. taile kichui korbo na ... 

                    BindGridView();
                    panel1.Hide();
                    doctorId = docId;
                    FullName = docName;

                }
                else
                {
                    //     na paile insert korte hobe 
                    //    MessageBox.Show("no row found !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SqlConnection con1 = new SqlConnection(cs); // connection string pass kore dite hobe 
                    string query1 = "insert into DoctorArticle values(@Doctor_Id, @Doctor_Name,@Article_Code,@Article_Title,@Body, @LikeCount, @DislikeCount, @Patient_Id, @LikeStatus)";
                    SqlCommand cmd1 = new SqlCommand(query1, con1); // con for connection
                    
                    cmd1.Parameters.AddWithValue("@Doctor_Id", Convert.ToInt32(textBox1.Text));
                    cmd1.Parameters.AddWithValue("@Doctor_Name", textBox6.Text);
                    cmd1.Parameters.AddWithValue("@Article_Code", textBox7.Text);
                    cmd1.Parameters.AddWithValue("@Article_Title", textBox2.Text);
                    cmd1.Parameters.AddWithValue("@Body", textBox3.Text);
                    cmd1.Parameters.AddWithValue("@LikeCount", 0.ToString());
                    cmd1.Parameters.AddWithValue("@DislikeCount", 0.ToString());
                    cmd1.Parameters.AddWithValue("@Patient_Id", "");
                    cmd1.Parameters.AddWithValue("@LikeStatus", "no");


                    // connection open korbo ekhon
                    con1.Open();
                    int a = cmd1.ExecuteNonQuery(); //  insert korar jonno  // eta kichu integer return korbe
                                                    // 1 row insert korle 1 return korbe 
                    if (a > 0)
                    {
                        //MessageBox.Show("Value is pushed / inserted successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 

                        BindGridView();
                        panel1.Hide();
                        doctorId = docId;
                        FullName = docName;
                    }
                    else
                    {
                        MessageBox.Show("value can not be inserted !", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                    }
                    con1.Close();
                    textBox3.Text = "";

                    
                    


                    panel1.Hide();
                }
                con.Close();
            }
            else
            {
                // Patient can watch time table
                
               button4.Hide();
               BindGridView();
                panel1.Hide();
                // patient jeno grid view te double click na korte pare .. shei bebostha korte hobe 
            }

        }
        void BindGridView()
        {
            textBox1.Text = DoctorLoginForm.doctorId.ToString();
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe
                                                       // ekhon query likhte hobe
            string query = "select Doctor_Id,Doctor_Name,Article_Code,Article_Title,Body, LikeCount, DislikeCount, Patient_Id, LikeStatus from DoctorArticle where Doctor_Id = @DoctorID";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            sda.SelectCommand.Parameters.AddWithValue("@DoctorID", doctorId.ToString());
            sda.SelectCommand.Parameters.AddWithValue("@Doctor_Name", FullName.ToString());
           

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.ColumnCount = 0;   // ei line ta important... 
            dataGridView1.DataSource = data;

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        // For Update.... 
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
            string query = "update DoctorArticle set Doctor_Name=@Doctor_Name,Article_Code=@Article_Code,Article_Title=@Article_Title, Body = @Body where Article_Code=@Article_Code";
            SqlCommand cmd = new SqlCommand(query, con); // con for connection

            cmd.Parameters.AddWithValue("@Doctor_Name", textBox6.Text);
            cmd.Parameters.AddWithValue("@Article_Code", textBox7.Text);
            cmd.Parameters.AddWithValue("@Article_Title", textBox2.Text);
            cmd.Parameters.AddWithValue("@Body", textBox3.Text);




            //// connection open korbo ekhon
            con.Open();
            int a = cmd.ExecuteNonQuery();
            //// kono row update hoile 1 pabo .. na hoile 0 pabo .. 

            if (a > 0)
            {
                MessageBox.Show("Information is updated successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                dataGridView1.DataSource = null; //  null na korle error dekhabe  😀😀
                BindGridView();
            }
            else
            {
                MessageBox.Show("Sorry ! Updation Failed ..", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
            }
            con.Close();
            panel1.Hide();



        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Patient hishebe article show hobe .. 
            if (PatientLogin.patient_Id > 199)
            {

                button4.Hide();
                
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                articleCode = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox7.Enabled = false;
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                //likeBtn.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString() + " Like";
                if (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value) < 10)
                {
                    likeBtn.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString() + " Like";
                    
                }
                else
                {
                    likeBtn.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString() + " Likes";
                }
                ///////////////////////////////////////////////////////////////////////////
                if (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value) < 10)
                {
                    dislikeBtn.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString() + " Dislike";
                }
                else
                {
                    dislikeBtn.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString() + "Dislikes";
                }

                //////////////////////////////// Status ta Patient_Like_Status Database theke ashbe .. ////////////////////////
                ///

                SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
                string query = "select * from Patient_Like_Status";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader DR1 = cmd.ExecuteReader();
                if (DR1.Read())
                {
                    likeStatus = DR1.GetValue(2).ToString();
                    dislikeStatus = DR1.GetValue(3).ToString();

                }
                con.Close();


                //MessageBox.Show(status);

                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

                



                panel1.Show();
                button1.Hide();
                button2.Hide();
                button3.Hide();
              


                

            }
            else if (DoctorLoginForm.doctorId < 199)
            {
               
                textBox1.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                articleCode = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                // textBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

                if (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value) < 10)
                {
                    likeBtn.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString() + " Like";

                }
                else
                {
                    likeBtn.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString() + " Likes";
                }
                ///////////////////////////////////////////////////////////////////////////
                if (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value) < 10)
                {
                    dislikeBtn.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString() + " Dislike";
                }
                else
                {
                    dislikeBtn.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString() + "Dislikes";
                }

                status = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();

                //MessageBox.Show(status);


                panel1.Show();
                button2.Show();
                button1.Show();
                button3.Hide();
                //button4.Show();
             
                

                //textBox3.Visible= true; 
            }





        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
            string query = "delete from DoctorArticle where Article_Code = @Article_Code";
            SqlCommand cmd = new SqlCommand(query, con); // con for connection
            cmd.Parameters.AddWithValue("@Article_Code", textBox7.Text); // koi theke ashbe .. textbox theke ashbe 


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
            panel1.Hide();
        }
        // Insert ... 
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
            string query = "insert into DoctorArticle values(@Doctor_Id,@Doctor_Name,@Article_Code, @Article_Title,@Body, @LikeCount, @DislikeCount, @Patient_Id, @LikeStatus)";
            SqlCommand cmd = new SqlCommand(query, con); // con for connection
                                                         //cmd.Parameters.AddWithValue("@DoctorId", textBox1.Text);
            
            cmd.Parameters.AddWithValue("@Doctor_Id", textBox1.Text);
            cmd.Parameters.AddWithValue("@Doctor_Name", textBox6.Text);
            cmd.Parameters.AddWithValue("@Article_Code", textBox7.Text);
            cmd.Parameters.AddWithValue("@Article_Title", textBox2.Text);
            cmd.Parameters.AddWithValue("@Body", textBox3.Text);
            cmd.Parameters.AddWithValue("@LikeCount", 0.ToString());
            cmd.Parameters.AddWithValue("@DislikeCount", 0.ToString());
            cmd.Parameters.AddWithValue("@Patient_Id", "");
            cmd.Parameters.AddWithValue("@LikeStatus", "no");


            // connection open korbo ekhon
            con.Open();
            int a = cmd.ExecuteNonQuery(); //  insert korar jonno  // eta kichu integer return korbe
            // 1 row insert korle 1 return korbe 
            if (a > 0)
            {
                dataGridView1.DataSource = null; //  null na korle error dekhabe  😀😀
                MessageBox.Show("Article is added successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                

                BindGridView();
            }
            else
            {
                MessageBox.Show("Please Give Proper Value to add Doctor !", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
            }
            con.Close();

            textBox6.Text = "";
            textBox2.Text = " ";
            textBox3.Text = "";
            


            panel1.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (DoctorLoginForm.doctorId < 199)
            {

                panel1.Show();
                button3.Show();
                button2.Hide();
                button1.Hide();
                //button4.Hide();
            }
            else
            {
                this.Hide();
            }
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void DoctorArticle_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if(PatientLogin.patient_Id > 199)
            {
                this.Hide();
                PatientProfile pp = new PatientProfile(PatientLogin.patient_Id.ToString());
                pp.Show();
            }
            else if(DoctorLoginForm.doctorId < 199)
            {
                this.Hide();
                DoctorProfile pp = new DoctorProfile(doctorId);
                pp.Show();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            
            panel1.Hide();
        }

        private void likeBtn_Click(object sender, EventArgs e)
        {
            // data base er code likhbo .. like er count baranor jonno .. 

            //textBox7.Text // ekhane article code ase .. ami tar jonno ar doctor id er jonno like count er 
            // value 1 barabo

            if(status == "no")
            {
                SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
                string query = "update DoctorArticle set LikeCount = @LikeCount, LikeStatus=@LikeStatus where Doctor_Id = @DoctorId or Patient_Id = @Patient_Id  and Article_Code = @Article_Code";
                SqlCommand cmd = new SqlCommand(query, con); // con for connection

                cmd.Parameters.AddWithValue("@Article_Code", textBox7.Text);

                cmd.Parameters.AddWithValue("@DoctorId", doctorId);
                cmd.Parameters.AddWithValue("@LikeStatus", "yes");
                if(String.IsNullOrEmpty(PatientLogin.patient_Id.ToString()) == true)
                {
                    cmd.Parameters.AddWithValue("@Patient_Id", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Patient_Id", PatientLogin.patient_Id);
                }
                
                

                cmd.Parameters.AddWithValue("@LikeCount", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value) + 1);



                // connection open korbo ekhon
                con.Open();
                int a = cmd.ExecuteNonQuery();
                // kono row update hoile 1 pabo .. na hoile 0 pabo .. 

                if (a > 0)
                {
                    status = "yes";
                    
                }
                else
                {
                    MessageBox.Show("Sorry", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                }
                con.Close();
            }
            else
            {
                // status yes hoile like dite deowa jabe na ..  // like er value ek komay dibo
                SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
                string query = "update DoctorArticle set LikeCount = @LikeCount, LikeStatus=@LikeStatus where Doctor_Id = @DoctorId or Patient_Id = @Patient_Id  and Article_Code = @Article_Code";
                SqlCommand cmd = new SqlCommand(query, con); // con for connection

                cmd.Parameters.AddWithValue("@Article_Code", textBox7.Text);

                cmd.Parameters.AddWithValue("@DoctorId", doctorId);
                cmd.Parameters.AddWithValue("@LikeStatus", "no");

                if (String.IsNullOrEmpty(PatientLogin.patient_Id.ToString()) == true)
                {
                    cmd.Parameters.AddWithValue("@Patient_Id", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Patient_Id", PatientLogin.patient_Id);
                }
                if (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value) > 0)
                {
                    cmd.Parameters.AddWithValue("@LikeCount", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value) - 1);
                }


                // connection open korbo ekhon
                con.Open();
                int a = cmd.ExecuteNonQuery();
                // kono row update hoile 1 pabo .. na hoile 0 pabo .. 

                if (a > 0)
                {
                    status = "no";

                }
                else
                {
                    MessageBox.Show("Sorry", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                }
                con.Close();
            }

            ///////////////////////////////////////////////////////
            if (PatientLogin.patient_Id > 199)
            {
                // age check korbo .. ei article er code er jonno Patient_Like_Status er moddhe likeStatus no deowa ase kina
                // Article successfully add hoile Patient_Like_Status database eo ei article code er jonno assign kore dibo 

                // 🎯 likeStatus ar DislikeStatus e kono value na thakle .. amader age eder value yes assign korte hobe 

                if (likeStatus == "no" && dislikeStatus == "no")
                {
                    SqlConnection con8 = new SqlConnection(cs); // connection string pass kore dite hobe 
                    string query8 = "update Patient_Like_Status set LikeStatus = @LikeStatus , DislikeStatus = @DislikeStatus where Article_Code = @Article_Code and Patient_Id = @Patient_Id";
                    SqlCommand cmd8 = new SqlCommand(query8, con8); // con for connection
                                                                    //cmd.Parameters.AddWithValue("@DoctorId", textBox1.Text);

                    cmd8.Parameters.AddWithValue("@Article_Code", articleCode);
                    cmd8.Parameters.AddWithValue("@Patient_Id", PatientLogin.patient_Id);
                    cmd8.Parameters.AddWithValue("@LikeStatus", "yes");
                    cmd8.Parameters.AddWithValue("@DislikeStatus", "no");

                    // connection open korbo ekhon
                    con8.Open();
                    int a = cmd8.ExecuteNonQuery();
                    // kono row update hoile 1 pabo .. na hoile 0 pabo .. 

                    if (a > 0)
                    {
                        // 🎯 main database e like er count 1 baraite hobe ...
                        SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
                        string query = "update DoctorArticle set LikeCount = @LikeCount where Article_Code = @Article_Code";
                        SqlCommand cmd = new SqlCommand(query, con); // con for connection

                        cmd.Parameters.AddWithValue("@Article_Code", textBox7.Text);
                        cmd.Parameters.AddWithValue("@LikeCount", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value) + 1);
                        // connection open korbo ekhon
                        con.Open();
                        int b = cmd.ExecuteNonQuery();
                        // kono row update hoile 1 pabo .. na hoile 0 pabo .. 

                        if (a > 0)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Sorry ! Updation Failed ..", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                        }
                        con8.Close();
                    }


                    else if (likeStatus == "yes" && dislikeStatus == "no")
                    {
                        // tahole amra like er value 1 komay dibo .. dislikeStatus er value no kore dibo ..
                        SqlConnection con9 = new SqlConnection(cs); // connection string pass kore dite hobe 
                        string query9 = "update Patient_Like_Status set LikeStatus = @LikeStatus , DislikeStatus = @DislikeStatus where Article_Code = @Article_Code and Patient_Id = @Patient_Id";
                        SqlCommand cmd9 = new SqlCommand(query9, con9); // con for connection
                                                                        //cmd.Parameters.AddWithValue("@DoctorId", textBox1.Text);

                        cmd8.Parameters.AddWithValue("@Article_Code", articleCode);
                        cmd8.Parameters.AddWithValue("@Patient_Id", PatientLogin.patient_Id);
                        cmd8.Parameters.AddWithValue("@LikeStatus", "no");
                        cmd8.Parameters.AddWithValue("@DislikeStatus", "no");

                        // connection open korbo ekhon
                        con8.Open();
                        int k = cmd8.ExecuteNonQuery();
                        // kono row update hoile 1 pabo .. na hoile 0 pabo .. 

                        if (k > 0)
                        {
                            // 🎯 main database e like er count 1 baraite hobe ...
                            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
                            string query = "update DoctorArticle set LikeCount = @LikeCount where Article_Code = @Article_Code";
                            SqlCommand cmd = new SqlCommand(query, con); // con for connection

                            cmd.Parameters.AddWithValue("@Article_Code", textBox7.Text);
                            if(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value) > 0)
                            {
                                cmd.Parameters.AddWithValue("@LikeCount", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value) - 1);

                            }
                            // connection open korbo ekhon
                            con.Open();
                            int b = cmd.ExecuteNonQuery();
                            // kono row update hoile 1 pabo .. na hoile 0 pabo .. 

                            if (b > 0)
                            {

                            }
                            else
                            {
                                MessageBox.Show("Sorry ! Updation Failed ..", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                            }
                            con8.Close();
                        }
                    }
                    else if (likeStatus == "no" && dislikeStatus == "yes")
                    {
                        // tahole amra like er value 1 barabo dibo .. dislikeStatus er value 1 komabo status no korbo kore dibo ..
                        SqlConnection con9 = new SqlConnection(cs); // connection string pass kore dite hobe 
                        string query9 = "update Patient_Like_Status set LikeStatus = @LikeStatus , DislikeStatus = @DislikeStatus where Article_Code = @Article_Code and Patient_Id = @Patient_Id";
                        SqlCommand cmd9 = new SqlCommand(query9, con9); // con for connection
                                                                        //cmd.Parameters.AddWithValue("@DoctorId", textBox1.Text);

                        cmd8.Parameters.AddWithValue("@Article_Code", articleCode);
                        cmd8.Parameters.AddWithValue("@Patient_Id", PatientLogin.patient_Id);
                        cmd8.Parameters.AddWithValue("@LikeStatus", "yes");
                        cmd8.Parameters.AddWithValue("@DislikeStatus", "no");

                        // connection open korbo ekhon
                        con8.Open();
                        int k = cmd8.ExecuteNonQuery();
                        // kono row update hoile 1 pabo .. na hoile 0 pabo .. 

                        if (k > 0)
                        {
                            // 🎯 main database e like er count 1 baraite hobe ...
                            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
                            string query = "update DoctorArticle set LikeCount = @LikeCount, DislikeCount = @DislikeCount where Article_Code = @Article_Code";
                            SqlCommand cmd = new SqlCommand(query, con); // con for connection

                            cmd.Parameters.AddWithValue("@Article_Code", textBox7.Text);
                            cmd.Parameters.AddWithValue("@LikeCount", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value) + 1);
                            if (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value) > 0)
                            {
                                cmd.Parameters.AddWithValue("@DislikeCount", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value) - 1);

                            }
                            // connection open korbo ekhon
                            con.Open();
                            int b = cmd.ExecuteNonQuery();
                            // kono row update hoile 1 pabo .. na hoile 0 pabo .. 

                            if (b > 0)
                            {

                            }
                            else
                            {
                                MessageBox.Show("Sorry ! Updation Failed ..", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                            }
                            con8.Close();
                        }
                    }
                }
            }
        }

        private void dislikeBtn_Click(object sender, EventArgs e)
        {
            // data base er code likhbo .. like er count baranor jonno .. 

            //textBox7.Text // ekhane article code ase .. ami tar jonno ar doctor id er jonno like count er 
            // value 1 barabo

            if (status == "no")
            {
                SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
                string query = "update DoctorArticle set DislikeCount = @DislikeCount, LikeStatus=@LikeStatus where Doctor_Id = @DoctorId  or Patient_Id = @Patient_Id   and Article_Code = @Article_Code";
                SqlCommand cmd = new SqlCommand(query, con); // con for connection

                cmd.Parameters.AddWithValue("@Article_Code", textBox7.Text);

                cmd.Parameters.AddWithValue("@DoctorId", doctorId);
                cmd.Parameters.AddWithValue("@LikeStatus", "yes");
                if (String.IsNullOrEmpty(PatientLogin.patient_Id.ToString()) == true)
                {
                    cmd.Parameters.AddWithValue("@Patient_Id", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Patient_Id", PatientLogin.patient_Id);
                }

                cmd.Parameters.AddWithValue("@DislikeCount", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value) + 1);



                // connection open korbo ekhon
                con.Open();
                int a = cmd.ExecuteNonQuery();
                // kono row update hoile 1 pabo .. na hoile 0 pabo .. 

                if (a > 0)
                {
                    status = "yes";

                }
                else
                {
                    MessageBox.Show("Sorry", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                }
                con.Close();
            }
            else
            {
                // status yes hoile like dite deowa jabe na ..  // like er value ek komay dibo
                SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
                string query = "update DoctorArticle set DislikeCount = @DislikeCount, LikeStatus=@LikeStatus where Doctor_Id = @DoctorId  or Patient_Id = @Patient_Id   and Article_Code = @Article_Code";
                SqlCommand cmd = new SqlCommand(query, con); // con for connection

                cmd.Parameters.AddWithValue("@Article_Code", textBox7.Text);

                cmd.Parameters.AddWithValue("@DoctorId", doctorId);
                cmd.Parameters.AddWithValue("@LikeStatus", "no");

                if (String.IsNullOrEmpty(PatientLogin.patient_Id.ToString()) == true)
                {
                    cmd.Parameters.AddWithValue("@Patient_Id", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Patient_Id", PatientLogin.patient_Id);
                }
                if (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value) > 0)
                {
                    cmd.Parameters.AddWithValue("@DislikeCount", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value) - 1);
                }


                // connection open korbo ekhon
                con.Open();
                int a = cmd.ExecuteNonQuery();
                // kono row update hoile 1 pabo .. na hoile 0 pabo .. 

                if (a > 0)
                {
                    status = "no";

                }
                else
                {
                    MessageBox.Show("Sorry", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                }
                con.Close();
            }



            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////
            if (PatientLogin.patient_Id > 199)
            {
                // age check korbo .. ei article er code er jonno Patient_Like_Status er moddhe likeStatus no deowa ase kina
                // Article successfully add hoile Patient_Like_Status database eo ei article code er jonno assign kore dibo 

                // 🎯 likeStatus ar DislikeStatus e kono value na thakle .. amader age eder value yes assign korte hobe 

                if (likeStatus == "no" && dislikeStatus == "no")
                {
                    SqlConnection con8 = new SqlConnection(cs); // connection string pass kore dite hobe 
                    string query8 = "update Patient_Like_Status set LikeStatus = @LikeStatus , DislikeStatus = @DislikeStatus where Article_Code = @Article_Code and Patient_Id = @Patient_Id";
                    SqlCommand cmd8 = new SqlCommand(query8, con8); // con for connection
                                                                    //cmd.Parameters.AddWithValue("@DoctorId", textBox1.Text);

                    cmd8.Parameters.AddWithValue("@Article_Code", articleCode);
                    cmd8.Parameters.AddWithValue("@Patient_Id", PatientLogin.patient_Id);
                    cmd8.Parameters.AddWithValue("@LikeStatus", "no");
                    cmd8.Parameters.AddWithValue("@DislikeStatus", "yes");

                    // connection open korbo ekhon
                    con8.Open();
                    int a = cmd8.ExecuteNonQuery();
                    // kono row update hoile 1 pabo .. na hoile 0 pabo .. 

                    if (a > 0)
                    {
                        // 🎯 main database e dislike er count 1 baraite hobe ...
                        SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
                        string query = "update DoctorArticle set DislikeCount = @DislikeCount where Article_Code = @Article_Code";
                        SqlCommand cmd = new SqlCommand(query, con); // con for connection

                        cmd.Parameters.AddWithValue("@Article_Code", textBox7.Text);
                        cmd.Parameters.AddWithValue("@DislikeCount", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value) + 1);
                        // connection open korbo ekhon
                        con.Open();
                        int b = cmd.ExecuteNonQuery();
                        // kono row update hoile 1 pabo .. na hoile 0 pabo .. 

                        if (a > 0)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Sorry ! Updation Failed ..", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                        }
                        con8.Close();
                    }

                    
                    else if ( dislikeStatus == "yes" && likeStatus == "no")
                    {
                        // tahole amra dislike er value 1 komay dibo .. likeStatus er value no kore dibo ..
                        SqlConnection con9 = new SqlConnection(cs); // connection string pass kore dite hobe 
                        string query9 = "update Patient_Like_Status set LikeStatus = @LikeStatus , DislikeStatus = @DislikeStatus where Article_Code = @Article_Code and Patient_Id = @Patient_Id";
                        SqlCommand cmd9 = new SqlCommand(query9, con9); // con for connection
                                                                        //cmd.Parameters.AddWithValue("@DoctorId", textBox1.Text);

                        cmd8.Parameters.AddWithValue("@Article_Code", articleCode);
                        cmd8.Parameters.AddWithValue("@Patient_Id", PatientLogin.patient_Id);
                        cmd8.Parameters.AddWithValue("@LikeStatus", "no");
                        cmd8.Parameters.AddWithValue("@DislikeStatus", "no");

                        // connection open korbo ekhon
                        con8.Open();
                        int k = cmd8.ExecuteNonQuery();
                        // kono row update hoile 1 pabo .. na hoile 0 pabo .. 

                        if (k > 0)
                        {
                            // 🎯 main database e like er count 1 baraite hobe ...
                            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
                            string query = "update DoctorArticle set DislikeCount = @DislikeCount where Article_Code = @Article_Code";
                            SqlCommand cmd = new SqlCommand(query, con); // con for connection

                            cmd.Parameters.AddWithValue("@Article_Code", textBox7.Text);
                            if (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value) > 0)
                            {
                                cmd.Parameters.AddWithValue("@DislikeCount", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value) - 1);
                            }
                             // connection open korbo ekhon
                            con.Open();
                            int b = cmd.ExecuteNonQuery();
                            // kono row update hoile 1 pabo .. na hoile 0 pabo .. 

                            if (b > 0)
                            {

                            }
                            else
                            {
                                MessageBox.Show("Sorry ! Updation Failed ..", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                            }
                            con8.Close();
                        }
                    }
                    else if (dislikeStatus == "no" && likeStatus == "yes")
                    {
                        // tahole amra dislike er value 1 barabo dibo .. likeStatus er value 1 komabo status no korbo kore dibo ..
                        SqlConnection con9 = new SqlConnection(cs); // connection string pass kore dite hobe 
                        string query9 = "update Patient_Like_Status set LikeStatus = @LikeStatus , DislikeStatus = @DislikeStatus where Article_Code = @Article_Code and Patient_Id = @Patient_Id";
                        SqlCommand cmd9 = new SqlCommand(query9, con9); // con for connection
                                                                        //cmd.Parameters.AddWithValue("@DoctorId", textBox1.Text);

                        cmd8.Parameters.AddWithValue("@Article_Code", articleCode);
                        cmd8.Parameters.AddWithValue("@Patient_Id", PatientLogin.patient_Id);
                        cmd8.Parameters.AddWithValue("@DislikeStatus", "yes");
                        cmd8.Parameters.AddWithValue("@LikeStatus", "no");

                        // connection open korbo ekhon
                        con8.Open();
                        int k = cmd8.ExecuteNonQuery();
                        // kono row update hoile 1 pabo .. na hoile 0 pabo .. 

                        if (k > 0)
                        {
                            // 🎯 main database e like er count 1 baraite hobe ...
                            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
                            string query = "update DoctorArticle set LikeCount = @LikeCount, DislikeCount = @DislikeCount where Article_Code = @Article_Code";
                            SqlCommand cmd = new SqlCommand(query, con); // con for connection

                            cmd.Parameters.AddWithValue("@Article_Code", textBox7.Text);
                            cmd.Parameters.AddWithValue("@DislikeCount", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value) + 1);
                            if (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value) > 0)
                            {
                                cmd.Parameters.AddWithValue("@LikeCount", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value) - 1);
                            }
                            // connection open korbo ekhon
                            con.Open();
                            int b = cmd.ExecuteNonQuery();
                            // kono row update hoile 1 pabo .. na hoile 0 pabo .. 

                            if (b > 0)
                            {

                            }
                            else
                            {
                                MessageBox.Show("Sorry ! Updation Failed ..", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                            }
                            con8.Close();
                        }
                    }
                }
            }
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
            DoctorArticle da = new DoctorArticle(doctorId, FullName);
            da.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorsCurrentPatientList dcp = new DoctorsCurrentPatientList(doctorId);
            dcp.Show();
        }
    }
 }
    


