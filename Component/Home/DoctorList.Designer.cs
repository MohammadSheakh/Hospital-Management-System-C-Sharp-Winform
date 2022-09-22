namespace ABC_Hospital_MS.Component.Home
{
    partial class DoctorList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorList));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.HomeBtn = new System.Windows.Forms.Button();
            this.AdminLoginBtn = new System.Windows.Forms.Button();
            this.DoctorListBtn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DoctorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Degree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedicalCollege = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Experience = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.docIdField = new System.Windows.Forms.TextBox();
            this.docNameTxBx = new System.Windows.Forms.TextBox();
            this.deptTxBx = new System.Windows.Forms.TextBox();
            this.degreeTxBx = new System.Windows.Forms.TextBox();
            this.experienceTxBx = new System.Windows.Forms.TextBox();
            this.medicalCollegeTxBx = new System.Windows.Forms.TextBox();
            this.docidText = new System.Windows.Forms.Label();
            this.docName = new System.Windows.Forms.Label();
            this.dept = new System.Windows.Forms.Label();
            this.degreeText = new System.Windows.Forms.Label();
            this.experienceText = new System.Windows.Forms.Label();
            this.college = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1416, 199);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.HomeBtn);
            this.panel4.Controls.Add(this.AdminLoginBtn);
            this.panel4.Controls.Add(this.DoctorListBtn);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(400, 40, 3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1416, 63);
            this.panel4.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(703, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 56);
            this.button2.TabIndex = 5;
            this.button2.Text = "Floor Map";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(800, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 56);
            this.button1.TabIndex = 4;
            this.button1.Text = "Feedback";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HomeBtn
            // 
            this.HomeBtn.Location = new System.Drawing.Point(509, 0);
            this.HomeBtn.Name = "HomeBtn";
            this.HomeBtn.Size = new System.Drawing.Size(91, 56);
            this.HomeBtn.TabIndex = 3;
            this.HomeBtn.Text = "Home";
            this.HomeBtn.UseVisualStyleBackColor = true;
            this.HomeBtn.Click += new System.EventHandler(this.HomeBtn_Click);
            // 
            // AdminLoginBtn
            // 
            this.AdminLoginBtn.Location = new System.Drawing.Point(897, 0);
            this.AdminLoginBtn.Name = "AdminLoginBtn";
            this.AdminLoginBtn.Size = new System.Drawing.Size(91, 56);
            this.AdminLoginBtn.TabIndex = 2;
            this.AdminLoginBtn.Text = "Admin Login";
            this.AdminLoginBtn.UseVisualStyleBackColor = true;
            this.AdminLoginBtn.Click += new System.EventHandler(this.AdminLoginBtn_Click);
            // 
            // DoctorListBtn
            // 
            this.DoctorListBtn.Location = new System.Drawing.Point(606, 0);
            this.DoctorListBtn.Name = "DoctorListBtn";
            this.DoctorListBtn.Size = new System.Drawing.Size(91, 56);
            this.DoctorListBtn.TabIndex = 1;
            this.DoctorListBtn.Text = "Doctor List";
            this.DoctorListBtn.UseVisualStyleBackColor = true;
            this.DoctorListBtn.Click += new System.EventHandler(this.DoctorListBtn_Click);
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel5.Location = new System.Drawing.Point(17, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(73, 59);
            this.panel5.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(408, 277);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(897, 113);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // DoctorID
            // 
            this.DoctorID.HeaderText = "DoctorID";
            this.DoctorID.Name = "DoctorID";
            // 
            // FullName
            // 
            this.FullName.HeaderText = "Full Name";
            this.FullName.Name = "FullName";
            // 
            // Department
            // 
            this.Department.HeaderText = "Department";
            this.Department.Name = "Department";
            // 
            // Degree
            // 
            this.Degree.HeaderText = "Degree";
            this.Degree.Name = "Degree";
            // 
            // MedicalCollege
            // 
            this.MedicalCollege.HeaderText = "Medical College";
            this.MedicalCollege.Name = "MedicalCollege";
            // 
            // Experience
            // 
            this.Experience.HeaderText = "Experience";
            this.Experience.Name = "Experience";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Search here";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(96, 292);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(255, 23);
            this.textBox1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Search By";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Name",
            "DoctorID",
            "Department",
            "Degree",
            "MedicalCollege",
            "Experience"});
            this.comboBox1.Location = new System.Drawing.Point(96, 355);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(255, 23);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 429);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Want to See";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Controls.Add(this.checkBox6);
            this.panel1.Controls.Add(this.checkBox5);
            this.panel1.Controls.Add(this.checkBox4);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Location = new System.Drawing.Point(96, 429);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 147);
            this.panel1.TabIndex = 12;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(22, 59);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(89, 19);
            this.checkBox3.TabIndex = 6;
            this.checkBox3.Text = "Department";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(22, 98);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(83, 19);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.Text = "Experience";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(129, 98);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(108, 19);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "MedicalCollege";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(129, 59);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(63, 19);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "Degree";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(129, 24);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(97, 19);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Doctor Name";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(22, 24);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(76, 19);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Doctor ID";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(247, 615);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 32);
            this.button3.TabIndex = 13;
            this.button3.Text = "Search";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // docIdField
            // 
            this.docIdField.Location = new System.Drawing.Point(552, 453);
            this.docIdField.Name = "docIdField";
            this.docIdField.Size = new System.Drawing.Size(255, 23);
            this.docIdField.TabIndex = 14;
            this.docIdField.Visible = false;
            // 
            // docNameTxBx
            // 
            this.docNameTxBx.Location = new System.Drawing.Point(985, 453);
            this.docNameTxBx.Name = "docNameTxBx";
            this.docNameTxBx.Size = new System.Drawing.Size(255, 23);
            this.docNameTxBx.TabIndex = 15;
            this.docNameTxBx.Visible = false;
            // 
            // deptTxBx
            // 
            this.deptTxBx.Location = new System.Drawing.Point(552, 523);
            this.deptTxBx.Name = "deptTxBx";
            this.deptTxBx.Size = new System.Drawing.Size(255, 23);
            this.deptTxBx.TabIndex = 16;
            this.deptTxBx.Visible = false;
            // 
            // degreeTxBx
            // 
            this.degreeTxBx.Location = new System.Drawing.Point(985, 523);
            this.degreeTxBx.Name = "degreeTxBx";
            this.degreeTxBx.Size = new System.Drawing.Size(255, 23);
            this.degreeTxBx.TabIndex = 17;
            this.degreeTxBx.Visible = false;
            // 
            // experienceTxBx
            // 
            this.experienceTxBx.Location = new System.Drawing.Point(552, 596);
            this.experienceTxBx.Name = "experienceTxBx";
            this.experienceTxBx.Size = new System.Drawing.Size(255, 23);
            this.experienceTxBx.TabIndex = 18;
            this.experienceTxBx.Visible = false;
            // 
            // medicalCollegeTxBx
            // 
            this.medicalCollegeTxBx.Location = new System.Drawing.Point(985, 596);
            this.medicalCollegeTxBx.Name = "medicalCollegeTxBx";
            this.medicalCollegeTxBx.Size = new System.Drawing.Size(255, 23);
            this.medicalCollegeTxBx.TabIndex = 19;
            this.medicalCollegeTxBx.Visible = false;
            // 
            // docidText
            // 
            this.docidText.AutoSize = true;
            this.docidText.Location = new System.Drawing.Point(458, 457);
            this.docidText.Name = "docidText";
            this.docidText.Size = new System.Drawing.Size(57, 15);
            this.docidText.TabIndex = 20;
            this.docidText.Text = "Doctor ID";
            this.docidText.Visible = false;
            // 
            // docName
            // 
            this.docName.AutoSize = true;
            this.docName.Location = new System.Drawing.Point(888, 456);
            this.docName.Name = "docName";
            this.docName.Size = new System.Drawing.Size(78, 15);
            this.docName.TabIndex = 21;
            this.docName.Text = "Doctor Name";
            this.docName.Visible = false;
            // 
            // dept
            // 
            this.dept.AutoSize = true;
            this.dept.Location = new System.Drawing.Point(458, 531);
            this.dept.Name = "dept";
            this.dept.Size = new System.Drawing.Size(70, 15);
            this.dept.TabIndex = 22;
            this.dept.Text = "Department";
            this.dept.Visible = false;
            // 
            // degreeText
            // 
            this.degreeText.AutoSize = true;
            this.degreeText.Location = new System.Drawing.Point(897, 531);
            this.degreeText.Name = "degreeText";
            this.degreeText.Size = new System.Drawing.Size(44, 15);
            this.degreeText.TabIndex = 23;
            this.degreeText.Text = "Degree";
            this.degreeText.Visible = false;
            // 
            // experienceText
            // 
            this.experienceText.AutoSize = true;
            this.experienceText.Location = new System.Drawing.Point(458, 604);
            this.experienceText.Name = "experienceText";
            this.experienceText.Size = new System.Drawing.Size(64, 15);
            this.experienceText.TabIndex = 24;
            this.experienceText.Text = "Experience";
            this.experienceText.Visible = false;
            // 
            // college
            // 
            this.college.AutoSize = true;
            this.college.Location = new System.Drawing.Point(887, 599);
            this.college.Name = "college";
            this.college.Size = new System.Drawing.Size(92, 15);
            this.college.TabIndex = 25;
            this.college.Text = "Medical College";
            this.college.Visible = false;
            this.college.Click += new System.EventHandler(this.college_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(118, 615);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 32);
            this.button4.TabIndex = 26;
            this.button4.Text = "Reset";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.userName.Location = new System.Drawing.Point(377, 402);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(140, 28);
            this.userName.TabIndex = 48;
            this.userName.Text = "Search Result";
            // 
            // DoctorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 711);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.college);
            this.Controls.Add(this.experienceText);
            this.Controls.Add(this.degreeText);
            this.Controls.Add(this.dept);
            this.Controls.Add(this.docName);
            this.Controls.Add(this.docidText);
            this.Controls.Add(this.medicalCollegeTxBx);
            this.Controls.Add(this.experienceTxBx);
            this.Controls.Add(this.degreeTxBx);
            this.Controls.Add(this.deptTxBx);
            this.Controls.Add(this.docNameTxBx);
            this.Controls.Add(this.docIdField);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel4);
            this.Name = "DoctorList";
            this.Text = "DoctorList";
            this.Load += new System.EventHandler(this.DoctorList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button HomeBtn;
        private System.Windows.Forms.Button AdminLoginBtn;
        private System.Windows.Forms.Button DoctorListBtn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn Degree;
        private System.Windows.Forms.DataGridViewTextBoxColumn MedicalCollege;
        private System.Windows.Forms.DataGridViewTextBoxColumn Experience;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox docIdField;
        private System.Windows.Forms.TextBox docNameTxBx;
        private System.Windows.Forms.TextBox deptTxBx;
        private System.Windows.Forms.TextBox degreeTxBx;
        private System.Windows.Forms.TextBox experienceTxBx;
        private System.Windows.Forms.TextBox medicalCollegeTxBx;
        private System.Windows.Forms.Label docidText;
        private System.Windows.Forms.Label docName;
        private System.Windows.Forms.Label dept;
        private System.Windows.Forms.Label degreeText;
        private System.Windows.Forms.Label experienceText;
        private System.Windows.Forms.Label college;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label userName;
    }
}