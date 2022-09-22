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
using ABC_Hospital_MS.Component.ExtraFeature;
using LOGIN_FORM.Component.Admin;

namespace ABC_Hospital_MS.Component.Home
{
    public partial class DoctorList : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        string searchBy = "";
        string doctorID = "";
        string fullName = "";
        string department = "";
        string degree = "";
        string medicalCollege = "";
        string experience = "";
        public DoctorList()
        {
            InitializeComponent();

            BindGridView();

        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe
            // ekhon query likhte hobe
            string query = "select DoctorID, FullName, Department, Degree, MedicalCollege, Experience from Doctor";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            // dataGridView1.ColumnCount = 0;     😀😀😀😀😀
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DoctorList_Load(object sender, EventArgs e)
        {

        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        // Search Button... 
        private void button3_Click(object sender, EventArgs e)
        {
            string searchKeyword;
            if (String.IsNullOrEmpty(textBox1.Text) == true)
            {
                searchKeyword = searchBy;
            }
            else
            {
                searchKeyword = textBox1.Text;
            }
             
            
            SqlConnection con = new SqlConnection(cs); // connection string pass kore dite hobe
                                                       // ekhon query likhte hobe
              //string query = "select * from Doctor where " + searchBy + " = @searchBy";
                                                       //string query = "select * from Doctor where " + searchBy + " like '%@searchBy%'";
            string query = "select * from Doctor where " + searchBy + " like '%"+searchKeyword+"%'";
            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@searchBy", searchKeyword);
            //cmd.Parameters.AddWithValue("@searchBy", searchKeyword.ToString());
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            //sda.SelectCommand.Parameters.AddWithValue("@searchBy", searchKeyword);

            DataTable data = new DataTable();
            sda.Fill(data);
            //dataGridView1.ColumnCount = 0;  
            dataGridView1.DataSource = data;

            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows == true)
            {

                rd.Read();
                docIdField.Text = rd["DoctorID"].ToString();
                docNameTxBx.Text = rd["FullName"].ToString();
                deptTxBx.Text = rd["Department"].ToString();
                degreeTxBx.Text = rd["Degree"].ToString();
                medicalCollegeTxBx.Text = rd["MedicalCollege"].ToString();
                experienceTxBx.Text = rd["Experience"].ToString();

                if (checkBox1.Checked || searchBy.Equals("DoctorID"))
                {
                    docidText.Show();
                    docIdField.Show();
                }
                if (checkBox2.Checked || searchBy.Equals("FullName"))
                {
                    docName.Show();
                    docNameTxBx.Show();
                }
               if (checkBox3.Checked || searchBy.Equals("Department"))
                {
                    deptTxBx.Show();
                    dept.Show();
                }
                if (checkBox4.Checked || searchBy.Equals("Degree"))
                {
                    degreeTxBx.Show();
                    degreeText.Show();
                }
                if (checkBox5.Checked || searchBy.Equals("MedicalCollege"))
                {
                    

                    medicalCollegeTxBx.Show();
                    college.Show();
                }
                if (checkBox6.Checked || searchBy.Equals("Experience"))
                {
                    experienceTxBx.Show();
                    experienceText.Show();
                }
            }
            else
            {
                MessageBox.Show("No Data Found");
            }

            BindGridView();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            searchBy = comboBox1.SelectedItem.ToString();

            if (comboBox1.SelectedItem != null)
            {

                if (searchBy.Equals("Name"))
                {
                    searchBy = "FullName";
                    checkBox2.Hide();
                }
                else if (searchBy.Equals("Department"))
                {
                    searchBy = "Department";
                    checkBox3.Hide();
                }
                else if (searchBy.Equals("Degree"))
                {
                    searchBy = "Degree";
                    checkBox4.Hide();
                }
                else if (searchBy.Equals("MedicalCollege"))
                {
                    searchBy = "MedicalCollege";
                    checkBox5.Hide();
                }
                else if (searchBy.Equals("Experience"))
                {
                    searchBy = "Experience";
                    checkBox6.Hide();
                }
                else if (searchBy.Equals("DoctorID"))
                {
                    searchBy = "DoctorID";
                    checkBox1.Hide();
                }
                


            }
        }

        private void college_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorList dl = new DoctorList();
            dl.Show();
        }

        private void DoctorListBtn_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FloorMap1 fm1 = new FloorMap1();
            fm1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainFeedback mf = new MainFeedback();
            mf.Show();
        }

        private void AdminLoginBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin al = new AdminLogin();
            al.Show();
        }
    }
}
