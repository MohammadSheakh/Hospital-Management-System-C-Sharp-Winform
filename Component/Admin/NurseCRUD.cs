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
using LOGIN_FORM.Component.Employee;

namespace LOGIN_FORM.Component.Admin
{
    public partial class NurseCRUD : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public NurseCRUD()
        {
            InitializeComponent();

            BindGridView();


        }

        private void ShiftComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        //for Showing Data Entry form
        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Show();

            button6.Hide();
            button1.Show();
            button7.Hide();

        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe
            // ekhon query likhte hobe
            string query = "select * from Nurse";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.ColumnCount = 0;
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            ShiftcomboBox.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            numericUpDown1.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value);
            NursePassword.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            panel1.Show();
            button6.Show();
            button7.Show();
            button1.Hide();
        }
        
        //Update
        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs); // Pass connection string 
            string query = "update Nurse set FullName = @FullName,Shift = @Shift, Experience = @Experience, Password = @NursePassword where NurseId = @NurseId";
            SqlCommand cmd = new SqlCommand(query, con); // con for connection
            cmd.Parameters.AddWithValue("@NurseId", textBox1.Text);
            cmd.Parameters.AddWithValue("@FullName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Shift", ShiftcomboBox.Text);
            cmd.Parameters.AddWithValue("@Experience", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@NursePassword", NursePassword.Text);


            //Openning connection 
            con.Open();
            int a = cmd.ExecuteNonQuery();
            // if row is update get 1 else ..  0 .. 

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

        //Delete
        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs); // Pass connection string
            string query = "delete from Nurse where NurseId = @NurseId";
            SqlCommand cmd = new SqlCommand(query, con); // con for connection
            cmd.Parameters.AddWithValue("@NurseId", textBox1.Text); // get from textbox 


            // Open connection 
            con.Open();
            int a = cmd.ExecuteNonQuery();



            // if Row is deleted  ..then values of a is 1  .. or row is not deleted  value will be 0 . 
            if (a > 0)
            {
                MessageBox.Show("Deleted successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                dataGridView1.DataSource = null; // if is not null its will show error   😀😀
                BindGridView();
            }
            else
            {
                MessageBox.Show("Sorry ! Can not be Deleted..", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
            }
            con.Close();
            panel1.Hide();

        }
        //Insertion
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs); // pass connection string  
            string query = "insert into Nurse values(@FullName, @Shift, @Experience, @Password)";
            SqlCommand cmd = new SqlCommand(query, con); // con for connection
            //cmd.Parameters.AddWithValue("@AccountantId", textBox1.Text);
            cmd.Parameters.AddWithValue("@FullName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Shift", ShiftcomboBox.SelectedItem);
            cmd.Parameters.AddWithValue("@Experience", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@Password", NursePassword.Text);


            // Open connection 
            con.Open();
            int a = cmd.ExecuteNonQuery(); //  insert korar jonno  // eta kichu integer return korbe
            // 1 row insert korle 1 return korbe 
            if (a > 0)
            {
                MessageBox.Show("Accountant is added successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
                dataGridView1.DataSource = null;
                BindGridView();
            }
            else
            {
                MessageBox.Show("Please Give Proper Value to add Accountant !", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); // heading, 
            }
            con.Close();

            textBox2.Text = "";
            ShiftcomboBox.SelectedItem = null;

            Password.Text = "";
            numericUpDown1.Value = 3; //  minimum experience 

            panel1.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
           this.Hide();
            EmployeeMain form = new EmployeeMain();
            form.Show();  
           
        }

        private void AdminLoginBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin al = new AdminLogin();
            al.Show();
        }
    }
}
