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
using ABC_Hospital_MS.Component.Patient;

namespace LOGIN_FORM.Component.Admin
{
    public partial class DoctorCRUD : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        
        public DoctorCRUD()
        {
            InitializeComponent();
            BindGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Show();
            button3.Hide();
            button2.Show();
            button5.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // 😀 For Insert a doctor
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
            string query = "insert into Doctor values(@FullName, @Department, @Degree, @MedicalCollege, @Experience, @DoctorPassword)";
            SqlCommand cmd = new SqlCommand(query, con); // con for connection
            //cmd.Parameters.AddWithValue("@DoctorId", textBox1.Text);
            cmd.Parameters.AddWithValue("@FullName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Department", DeptComboBox.SelectedItem);
            cmd.Parameters.AddWithValue("@Degree", textBox4.Text);
            cmd.Parameters.AddWithValue("@MedicalCollege", textBox5.Text);
            cmd.Parameters.AddWithValue("@Experience", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@DoctorPassword", DoctorPassword.Text);

            

            // connection open korbo ekhon
            con.Open();
            int a = cmd.ExecuteNonQuery(); //  insert korar jonno  // eta kichu integer return korbe
            // 1 row insert korle 1 return korbe 
            if (a > 0)
            {
                MessageBox.Show("Doctor is added successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                BindGridView();
            }
            else
            {
                MessageBox.Show("Please Give Proper Value to add Doctor !", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
            }
            con.Close();

            textBox2.Text = "";
            DeptComboBox.SelectedItem = null;
            textBox4.Text = "";
            textBox5.Text = "";
            numericUpDown1.Value = 3; //  minimum experience 

            panel1.Hide();
        }

        // To Read Data from database and Show those data into tables
        void BindGridView() {
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe
            // ekhon query likhte hobe
            string query = "select * from Doctor";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            // dataGridView1.ColumnCount = 0;     😀😀😀😀😀
            dataGridView1.DataSource = data;
        } 

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // 😀 For Update a doctor information
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
            string query = "update Doctor set FullName = @FullName, Department = @Department, Degree = @Degree, MedicalCollege = @MedicalCollege, Experience = @Experience, DoctorPassword = @DoctorPassword where DoctorId = @DoctorId";
            SqlCommand cmd = new SqlCommand(query, con); // con for connection
            cmd.Parameters.AddWithValue("@DoctorId", textBox1.Text);
            
            cmd.Parameters.AddWithValue("@FullName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Department", DeptComboBox.SelectedItem);
            cmd.Parameters.AddWithValue("@Degree", textBox4.Text);
            cmd.Parameters.AddWithValue("@MedicalCollege", textBox5.Text);
            cmd.Parameters.AddWithValue("@Experience", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@DoctorPassword", DoctorPassword.Text);
            

            // connection open korbo ekhon
            con.Open();
            int a = cmd.ExecuteNonQuery(); 
            // kono row update hoile 1 pabo .. na hoile 0 pabo .. 
            
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
            // jei row select kori .. shetai 0 row
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            DeptComboBox.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value);
            DoctorPassword.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            panel1.Show();
            button2.Hide();
            button3.Show();
            button5.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //panel1.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        // 😀 For Delete a doctor 
        private void button5_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
            string query = "delete from Doctor where DoctorId = @DoctorId";
            SqlCommand cmd = new SqlCommand(query, con); // con for connection
            cmd.Parameters.AddWithValue("@DoctorId", textBox1.Text); // koi theke ashbe .. textbox theke ashbe 


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

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void DoctorCRUD_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
            
          

    }

        private void AdminLoginBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin al = new AdminLogin();
            al.Show();
        }

        private void DoctorListBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowDoctorList sdl = new ShowDoctorList();
            sdl.Show();
        }
    }
}
