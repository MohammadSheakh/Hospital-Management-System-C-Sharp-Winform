namespace ABC_Hospital_MS.Component.Admin
{
    partial class Suggestions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Suggestions));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.HomeBtn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.AdminLoginBtn = new System.Windows.Forms.Button();
            this.DoctorListBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Suggestion_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Suggestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Option = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.suggestionBoxTxtBx = new System.Windows.Forms.RichTextBox();
            this.delete = new System.Windows.Forms.Button();
            this.submit = new System.Windows.Forms.Button();
            this.replyTxtBx = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UserNameTxBx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuggestionIdTxtBox = new System.Windows.Forms.TextBox();
            this.SuggestionId = new System.Windows.Forms.Label();
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
            this.pictureBox1.Location = new System.Drawing.Point(0, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1240, 204);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.HomeBtn);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.AdminLoginBtn);
            this.panel4.Controls.Add(this.DoctorListBtn);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(400, 40, 3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1240, 57);
            this.panel4.TabIndex = 4;
            // 
            // HomeBtn
            // 
            this.HomeBtn.Location = new System.Drawing.Point(553, 3);
            this.HomeBtn.Name = "HomeBtn";
            this.HomeBtn.Size = new System.Drawing.Size(91, 56);
            this.HomeBtn.TabIndex = 3;
            this.HomeBtn.Text = "Home";
            this.HomeBtn.UseVisualStyleBackColor = true;
            this.HomeBtn.Click += new System.EventHandler(this.HomeBtn_Click);
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel5.Location = new System.Drawing.Point(29, 1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(73, 59);
            this.panel5.TabIndex = 0;
            // 
            // AdminLoginBtn
            // 
            this.AdminLoginBtn.Location = new System.Drawing.Point(880, 3);
            this.AdminLoginBtn.Name = "AdminLoginBtn";
            this.AdminLoginBtn.Size = new System.Drawing.Size(91, 56);
            this.AdminLoginBtn.TabIndex = 2;
            this.AdminLoginBtn.Text = "Logout";
            this.AdminLoginBtn.UseVisualStyleBackColor = true;
            this.AdminLoginBtn.Click += new System.EventHandler(this.AdminLoginBtn_Click);
            // 
            // DoctorListBtn
            // 
            this.DoctorListBtn.Location = new System.Drawing.Point(650, 3);
            this.DoctorListBtn.Name = "DoctorListBtn";
            this.DoctorListBtn.Size = new System.Drawing.Size(91, 56);
            this.DoctorListBtn.TabIndex = 1;
            this.DoctorListBtn.Text = "Doctor List";
            this.DoctorListBtn.UseVisualStyleBackColor = true;
            this.DoctorListBtn.Click += new System.EventHandler(this.DoctorListBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(29, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "Suggestions..";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Suggestion_Id,
            this.UserName,
            this.Suggestion,
            this.Option});
            this.dataGridView1.Location = new System.Drawing.Point(171, 212);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(496, 226);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // Suggestion_Id
            // 
            this.Suggestion_Id.HeaderText = "Suggestion ID";
            this.Suggestion_Id.Name = "Suggestion_Id";
            // 
            // UserName
            // 
            this.UserName.HeaderText = "User Name";
            this.UserName.Name = "UserName";
            // 
            // Suggestion
            // 
            this.Suggestion.HeaderText = "Suggestion";
            this.Suggestion.Name = "Suggestion";
            // 
            // Option
            // 
            this.Option.HeaderText = "Option";
            this.Option.Name = "Option";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.suggestionBoxTxtBx);
            this.panel1.Controls.Add(this.delete);
            this.panel1.Controls.Add(this.submit);
            this.panel1.Controls.Add(this.replyTxtBx);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.UserNameTxBx);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.SuggestionIdTxtBox);
            this.panel1.Controls.Add(this.SuggestionId);
            this.panel1.Location = new System.Drawing.Point(171, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 472);
            this.panel1.TabIndex = 9;
            // 
            // suggestionBoxTxtBx
            // 
            this.suggestionBoxTxtBx.Location = new System.Drawing.Point(96, 213);
            this.suggestionBoxTxtBx.Name = "suggestionBoxTxtBx";
            this.suggestionBoxTxtBx.Size = new System.Drawing.Size(307, 74);
            this.suggestionBoxTxtBx.TabIndex = 10;
            this.suggestionBoxTxtBx.Text = "";
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(382, 435);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 9;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(279, 435);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 8;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // replyTxtBx
            // 
            this.replyTxtBx.Location = new System.Drawing.Point(96, 334);
            this.replyTxtBx.Name = "replyTxtBx";
            this.replyTxtBx.Size = new System.Drawing.Size(307, 84);
            this.replyTxtBx.TabIndex = 7;
            this.replyTxtBx.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Reply";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Suggestion";
            // 
            // UserNameTxBx
            // 
            this.UserNameTxBx.Location = new System.Drawing.Point(92, 139);
            this.UserNameTxBx.Name = "UserNameTxBx";
            this.UserNameTxBx.ReadOnly = true;
            this.UserNameTxBx.Size = new System.Drawing.Size(311, 23);
            this.UserNameTxBx.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "User Name";
            // 
            // SuggestionIdTxtBox
            // 
            this.SuggestionIdTxtBox.Location = new System.Drawing.Point(92, 66);
            this.SuggestionIdTxtBox.Name = "SuggestionIdTxtBox";
            this.SuggestionIdTxtBox.ReadOnly = true;
            this.SuggestionIdTxtBox.Size = new System.Drawing.Size(311, 23);
            this.SuggestionIdTxtBox.TabIndex = 1;
            // 
            // SuggestionId
            // 
            this.SuggestionId.AutoSize = true;
            this.SuggestionId.Location = new System.Drawing.Point(92, 34);
            this.SuggestionId.Name = "SuggestionId";
            this.SuggestionId.Size = new System.Drawing.Size(81, 15);
            this.SuggestionId.TabIndex = 0;
            this.SuggestionId.Text = "Suggestion_Id";
            this.SuggestionId.Click += new System.EventHandler(this.label2_Click);
            // 
            // Suggestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 660);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel4);
            this.Name = "Suggestions";
            this.Text = "Suggestions";
            this.Load += new System.EventHandler(this.Suggestions_Load);
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
        private System.Windows.Forms.Button HomeBtn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button AdminLoginBtn;
        private System.Windows.Forms.Button DoctorListBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Suggestion_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Suggestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Option;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label SuggestionId;
        private System.Windows.Forms.TextBox SuggestionIdTxtBox;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.RichTextBox replyTxtBx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UserNameTxBx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox suggestionBoxTxtBx;
    }
}