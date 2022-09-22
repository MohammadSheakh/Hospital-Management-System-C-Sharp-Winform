using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data.SqlClient;
using LOGIN_FORM.Component.Doctor;
using LOGIN_FORM.Component.Patient;


namespace LOGIN_FORM.Component.Patient
{
    public partial class PatientRegestration : Form
    {
        string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"; // regular expression
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public PatientRegestration()
        {
            InitializeComponent();
        }

        private void PatientRegestration_Load(object sender, EventArgs e, PatientRegestration patientRegestration)
        {
            
        }
        
        // text field e kichu na likhle error show korbe ... 
        private void firstname_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstname.Text) == true)
            {
                firstname.Focus();
                errorProvider1.SetError(this.firstname, "Please Fill First Name");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void firstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (char.IsLetter(c) == true)
            {
                // handled true kora mane hocche error show kora ... 
                e.Handled = false;
            }
            else if (c == 8) 
            {
                e.Handled = false;
            }
            else if (c == 32) 
            {
                e.Handled = false; // false na korle space nibe na 
             }
            else
            {
                e.Handled = true; // error show korbo 
            }
        }

        private void lastname_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(lastname.Text) == true)
            {
                lastname.Focus();
                errorProvider2.SetError(this.lastname, "Please Fill Last Name");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void lastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (char.IsLetter(c) == true)
            {
                e.Handled = false;
            }
            else if (c == 8)
            {
                e.Handled = false;
            }
            else if (c == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void nationality_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nationality.Text) == true)
            {
                nationality.Focus();
                errorProvider3.SetError(this.nationality, "Please Fill the Field Nationallity");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void nationality_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (char.IsLetter(c) == true)
            {
                e.Handled = false;
            }
            else if (c == 8)
            {
                e.Handled = false;
            }
            else if (c == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void emailaddress_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(emailaddress.Text, pattern) == false)
            {
                emailaddress.Focus();
                errorProvider4.SetError(this.emailaddress, "Invalid Email");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void username_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(username.Text) == true)
            {
                username.Focus();
                errorProvider5.SetError(this.username, "Please Fill the Field Nationallity");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void username_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (char.IsLetter(c) == true)
            {
                e.Handled = false;
            }
            else if (c == 8)
            {
                e.Handled = false;
            }
            else if (c == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void gender_Leave(object sender, EventArgs e)
        {
            if (gender.SelectedItem == null)
            {
                gender.Focus();
                errorProvider6.SetError(this.gender, "Please select Gender");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void bloodgroup_Leave(object sender, EventArgs e)
        {
            if (bloodgroup.SelectedItem == null)
            {
                gender.Focus();
                errorProvider8.SetError(this.bloodgroup, "Please select Blood Group");
            }
            else
            {
                errorProvider8.Clear();
            }
        }

        private void address_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(address.Text) == true)
            {
                address.Focus();
                errorProvider9.SetError(this.address, "Please Fill the Field Address");
            }
            else
            {
                errorProvider9.Clear();
            }
        }

        private void mobile_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mobile.Text) == true)
            {
                mobile.Focus();
                errorProvider10.SetError(this.mobile, "Please Fill the Field Mobile Number");
            }
            else
            {
                errorProvider10.Clear();
            }
        }

        private void mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (char.IsDigit(c)== true)
            {
                e.Handled = false;
            }
            else if (c == 8)
            {
                e.Handled = false;
            }
            else if (c == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void password_Leave(object sender, EventArgs e)
        {
           
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            if (textBox12.Text != password.Text)
            {
                textBox12.Focus();
                errorProvider12.SetError(this.textBox12, "Password didn't Match");
            }
            else
            {
                errorProvider12.Clear();
            }
        }

        private void submitForm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstname.Text) == true)
            {
                firstname.Focus();
                errorProvider1.SetError(this.firstname, "Please Fill First Name");
            }
            else if (string.IsNullOrEmpty(lastname.Text) == true)
            {
                lastname.Focus();
                errorProvider2.SetError(this.lastname, "Please Fill Last Name");
            }
            else if (string.IsNullOrEmpty(nationality.Text) == true)
            {
                nationality.Focus();
                errorProvider3.SetError(this.nationality, "Please Fill the Field Nationallity");
            }
           else  if (Regex.IsMatch(emailaddress.Text, pattern) == false)
            {
                emailaddress.Focus();
                errorProvider4.SetError(this.emailaddress, "Invalid Email");
            }
            else if (string.IsNullOrEmpty(username.Text) == true)
            {
                username.Focus();
                errorProvider5.SetError(this.username, "Please Fill the Field Nationallity");
            }

            else if (gender.SelectedItem == null)
            {
                gender.Focus();
                errorProvider6.SetError(this.gender, "Please select Gender");
            }
           else if (bloodgroup.SelectedItem == null)
            {
                gender.Focus();
                errorProvider8.SetError(this.bloodgroup, "Please select Blood Group");
            }
            else if (string.IsNullOrEmpty(address.Text) == true)
            {
                address.Focus();
                errorProvider9.SetError(this.address, "Please Fill the Field Address");
            }
            else if (string.IsNullOrEmpty(mobile.Text) == true)
            {
                mobile.Focus();
                errorProvider10.SetError(this.mobile, "Please Fill the Field Mobile Number");
            }
            //else if (Regex.IsMatch(password.Text, passpattern) == false)
            //{
            //    password.Focus();
            //    errorProvider11.SetError(this.password, "Uppercase,lowercase,symbol,character");
            //}
           else if (textBox12.Text != password.Text)
            {
                textBox12.Focus();
                errorProvider12.SetError(this.textBox12, "Password didn't Match");
            }
            else
            {
                /// Database er kaj hobe ekhane ...  Insert Data ... 
                
                SqlConnection con = new SqlConnection(cs);

                string query2 = "select * from Patient_SignUp where UserName = @username ";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@username", username.Text);
                con.Open();
                SqlDataReader rd = cmd2.ExecuteReader();
                if (rd.HasRows == true)
                {
                    MessageBox.Show(username.Text + "Username Already Exit!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
                else
                {
                    con.Close();
                    string query = "insert into patient_signup values(@FirstName,@LastName,@Nationality,@Email,@UserName,@Gender,@Age,@BloodGroup,@Address,@MobileNumber,@Password, @ConfirmPassword)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@FirstName", firstname.Text);
                    cmd.Parameters.AddWithValue("@LastName", lastname.Text);
                    cmd.Parameters.AddWithValue("@Nationality", nationality.Text);
                    cmd.Parameters.AddWithValue("@Email", emailaddress.Text);
                    cmd.Parameters.AddWithValue("@UserName", username.Text);
                    cmd.Parameters.AddWithValue("@Gender", gender.Text);
                    cmd.Parameters.AddWithValue("@Age", age.Text);
                    cmd.Parameters.AddWithValue("@BloodGroup", bloodgroup.Text);
                    cmd.Parameters.AddWithValue("@Address", address.Text);
                    cmd.Parameters.AddWithValue("@MobileNumber", mobile.Text);
                    cmd.Parameters.AddWithValue("@Password", password.Text);
                    cmd.Parameters.AddWithValue("@ConfirmPassword", textBox12.Text);


                    



                    con.Open();

                    int a = cmd.ExecuteNonQuery();//for insert,delete,update
                    if (a > 0)
                    {
                        con.Close();
                        string query1 = "select Patient_Id from patient_signup";
                        SqlCommand cmd3 = new SqlCommand(query1, con);
                        
                        con.Open();
                        SqlDataReader rd1 = cmd2.ExecuteReader();
                        

                        rd1.Read(); 
                        MessageBox.Show("Registration Successfull!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Your Id is : "+rd1["Patient_Id"].ToString() +" Your Email is: " + emailaddress.Text + "\n\n" + " " + "Your Password is: " + password.Text);
                        this.Hide();

                        ///////// ekhane profile dekhabo 😀😀😀😀😀😀😀😀
                        PatientLogin plogin = new PatientLogin();
                        plogin.Show();
                    }
                    else
                    {
                        MessageBox.Show("Registration Failed!", "failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    con.Close();

                }

                MessageBox.Show("Regietration Done.Please Login Now");
            }


        }

        private void clearForm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("all section is cleared");
            firstname.Clear();
            lastname.Clear();
            nationality.Clear();
            emailaddress.Clear();
            username.Clear();
            gender.SelectedItem = null;
            age.Value = 0;  
            bloodgroup.SelectedItem = null;
            address.Clear();
            mobile.Clear();
            password.Clear();
            textBox12.Clear();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sumbitBtn_Click(object sender, EventArgs e)
        {

        }

        private void reset_Click_1(object sender, EventArgs e)
        {

        }

        private void firstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void PatientRegestration_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientLogin pl = new PatientLogin();
            pl.Show();
        }
    }
}
