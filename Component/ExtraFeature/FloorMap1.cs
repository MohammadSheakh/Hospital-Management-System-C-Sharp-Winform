using ABC_Hospital_MS.Component.Patient;
using LOGIN_FORM;
using LOGIN_FORM.Component.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_Hospital_MS.Component.ExtraFeature
{
    public partial class FloorMap1 : Form
    {
        public FloorMap1()
        {
            InitializeComponent();
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
            panel3.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void FloorMap1_Load(object sender, EventArgs e)
        {

        }

        private void DoctorListBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowDoctorList sdl = new ShowDoctorList();
            sdl.Show();
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
