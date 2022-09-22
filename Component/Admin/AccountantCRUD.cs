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
using LOGIN_FORM.Component.Employee;

namespace LOGIN_FORM.Component.Admin
{
    public partial class AccountantCRUD : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public AccountantCRUD()
        {
            InitializeComponent();

            BindGridView();
        }

        private void AccountantCRUD_Load(object sender, EventArgs e)
        {

        }


        // 😀 For form show button
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Show();
            
            button2.Show();
            button3.Hide();
            button5.Hide();
        }
        // To Read Data from database and Show those data into tables
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe
            // ekhon query likhte hobe
            string query = "select * from Accountant";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.ColumnCount = 0;    
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // jei row select kori .. shetai 0 row
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            ShiftComboBox.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value);
            AccountantPassword.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            panel1.Show();
            button2.Hide();
            button3.Show();
            button5.Show();
        }
        // update ... 
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs); // Pass connection string 
            string query = "update Accountant set FullName = @FullName,Shift = @Shift, Experience = @Experience, AccountantPassword = @AccountantPassword where AccountantId = @AccountantId";
            SqlCommand cmd = new SqlCommand(query, con); // con for connection
            cmd.Parameters.AddWithValue("@AccountantId", textBox1.Text);
            cmd.Parameters.AddWithValue("@FullName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Shift", ShiftComboBox.Text);
            cmd.Parameters.AddWithValue("@Experience", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@AccountantPassword", AccountantPassword.Text);


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
        // For Delete ... 
        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs); // Pass connection string
            string query = "delete from Accountant where AccountantId = @AccountantId";
            SqlCommand cmd = new SqlCommand(query, con); // con for connection
            cmd.Parameters.AddWithValue("@AccountantId", textBox1.Text); // get from textbox 


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

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        // Insert Information
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs); // pass connection string  
            string query = "insert into Accountant values(@FullName, @Shift, @Experience, @AccountantPassword)";
            SqlCommand cmd = new SqlCommand(query, con); // con for connection
            //cmd.Parameters.AddWithValue("@AccountantId", textBox1.Text);
            cmd.Parameters.AddWithValue("@FullName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Shift", ShiftComboBox.SelectedItem);
            cmd.Parameters.AddWithValue("@Experience", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@AccountantPassword", AccountantPassword.Text);


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
            ShiftComboBox.SelectedItem = null;

            AccountantPassword.Text = "";
            numericUpDown1.Value = 3; //  minimum experience 

            panel1.Hide();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeMain em = new EmployeeMain();
            em.Show();
        }
    }
}
