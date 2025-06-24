namespace Lokiproject4
{
    partial class txtcoursename
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtstudentname = new System.Windows.Forms.TextBox();
            this.Dataviewstudents = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.lblstudentname = new System.Windows.Forms.Label();
            this.lblcoursename = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.STUPASSWORD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Dataviewstudents)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtstudentname
            // 
            this.txtstudentname.Location = new System.Drawing.Point(253, 28);
            this.txtstudentname.Name = "txtstudentname";
            this.txtstudentname.Size = new System.Drawing.Size(100, 22);
            this.txtstudentname.TabIndex = 1;
            this.txtstudentname.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Dataviewstudents
            // 
            this.Dataviewstudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dataviewstudents.Location = new System.Drawing.Point(46, 231);
            this.Dataviewstudents.Name = "Dataviewstudents";
            this.Dataviewstudents.RowHeadersWidth = 51;
            this.Dataviewstudents.RowTemplate.Height = 24;
            this.Dataviewstudents.Size = new System.Drawing.Size(460, 194);
            this.Dataviewstudents.TabIndex = 2;
            this.Dataviewstudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(374, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Location = new System.Drawing.Point(558, 192);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(75, 23);
            this.btnupdate.TabIndex = 4;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // lblstudentname
            // 
            this.lblstudentname.AutoSize = true;
            this.lblstudentname.Location = new System.Drawing.Point(100, 28);
            this.lblstudentname.Name = "lblstudentname";
            this.lblstudentname.Size = new System.Drawing.Size(92, 16);
            this.lblstudentname.TabIndex = 5;
            this.lblstudentname.Text = "Student Name";
            // 
            // lblcoursename
            // 
            this.lblcoursename.AutoSize = true;
            this.lblcoursename.Location = new System.Drawing.Point(100, 125);
            this.lblcoursename.Name = "lblcoursename";
            this.lblcoursename.Size = new System.Drawing.Size(90, 16);
            this.lblcoursename.TabIndex = 6;
            this.lblcoursename.Text = "Course Name";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(715, 192);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // STUPASSWORD
            // 
            this.STUPASSWORD.Location = new System.Drawing.Point(253, 71);
            this.STUPASSWORD.Name = "STUPASSWORD";
            this.STUPASSWORD.Size = new System.Drawing.Size(100, 22);
            this.STUPASSWORD.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "password";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(586, 21);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(100, 22);
            this.txtAddress.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(449, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "address";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(253, 122);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 14;
            // 
            // txtcoursename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 526);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.STUPASSWORD);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lblcoursename);
            this.Controls.Add(this.lblstudentname);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Dataviewstudents);
            this.Controls.Add(this.txtstudentname);
            this.Controls.Add(this.button1);
            this.Name = "txtcoursename";
            this.Text = "StudentForm";
            this.Load += new System.EventHandler(this.StudentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dataviewstudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtstudentname;
        private System.Windows.Forms.DataGridView Dataviewstudents;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Label lblstudentname;
        private System.Windows.Forms.Label lblcoursename;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox STUPASSWORD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}