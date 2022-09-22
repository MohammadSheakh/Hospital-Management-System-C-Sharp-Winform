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
using ABC_Hospital_MS.Component.Patient;
using LOGIN_FORM;

namespace ABC_Hospital_MS.Component.Admin
{
    public partial class Suggestions : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public Suggestions()
        {
            InitializeComponent();
            panel1.Hide();
            BindGridView();
        }
        // To Read Data from database and Show those data into tables
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe
            // ekhon query likhte hobe
            string query = "select Suggestion_Id, UserName, Suggestion, Reply from Suggestion";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
             dataGridView1.ColumnCount = 0;    
            dataGridView1.DataSource = data;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Suggestions_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // jei row select kori .. shetai 0 row
            SuggestionIdTxtBox.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            UserNameTxBx.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            suggestionBoxTxtBx.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            replyTxtBx.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            
            panel1.Show();
            
            submit.Show();
            delete.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        // 😀 For Update a suggestion information
        private void submit_Click(object sender, EventArgs e)
        {
            //Suggestion = @Suggestion, 
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
            string query = "update Suggestion set Reply = @Reply where Suggestion_Id = @Suggestion_Id";
            SqlCommand cmd = new SqlCommand(query, con); // con for connection
            cmd.Parameters.AddWithValue("@Suggestion_Id", SuggestionIdTxtBox.Text);
            cmd.Parameters.AddWithValue("@UserName", UserNameTxBx.Text);
            cmd.Parameters.AddWithValue("@Suggestion", suggestionBoxTxtBx.Text);
            cmd.Parameters.AddWithValue("@Reply", replyTxtBx.Text);
            

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
        // 😀 For Delete a suggestion
        private void delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe 
            string query = "delete from Suggestion where Suggestion_Id = @Suggestion_Id";
            SqlCommand cmd = new SqlCommand(query, con); // con for connection
            cmd.Parameters.AddWithValue("@Suggestion_Id", SuggestionIdTxtBox.Text); // koi theke ashbe .. textbox theke ashbe 


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
            this.Hide();
            AdminHome ah = new AdminHome();
            ah.Show();
        }

        private void DoctorListBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowDoctorList sdl = new ShowDoctorList();
            sdl.Show();
        }

        private void AdminLoginBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
