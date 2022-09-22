using ABC_Hospital_MS.Component.Admin;
using LOGIN_FORM.Component.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGIN_FORM.Component.Admin
{
    public partial class AdminHome : Form
    {
        public AdminHome()
        {
            InitializeComponent();
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AppointmentApproval appointmentApproval = new AppointmentApproval();
            appointmentApproval.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorCRUD doctorCRUD = new DoctorCRUD();
            doctorCRUD.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Suggestions_Click(object sender, EventArgs e)
        {
            this.Hide();
            Suggestions suggestions = new Suggestions();
            suggestions.Show();
            
        }

        private void DoctorListBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome adminHome = new AdminHome();
            adminHome.Show();
        }

        private void AdminLoginBtn_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeMain empMain = new EmployeeMain();
            empMain.Show(); 
        }
    }
}
