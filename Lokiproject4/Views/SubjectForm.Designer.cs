namespace Lokiproject4.Views
{
    partial class SubjectForm
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
            this.cmbcourses = new System.Windows.Forms.ComboBox();
            this.txtsubjectname = new System.Windows.Forms.TextBox();
            this.dataGridViewSubject = new System.Windows.Forms.DataGridView();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.btnUpdateSubject = new System.Windows.Forms.Button();
            this.btnDeleteSubject = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubject)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbcourses
            // 
            this.cmbcourses.FormattingEnabled = true;
            this.cmbcourses.Location = new System.Drawing.Point(130, 122);
            this.cmbcourses.Name = "cmbcourses";
            this.cmbcourses.Size = new System.Drawing.Size(121, 24);
            this.cmbcourses.TabIndex = 0;
            this.cmbcourses.SelectedIndexChanged += new System.EventHandler(this.cmbcourses_SelectedIndexChanged);
            // 
            // txtsubjectname
            // 
            this.txtsubjectname.Location = new System.Drawing.Point(130, 201);
            this.txtsubjectname.Name = "txtsubjectname";
            this.txtsubjectname.Size = new System.Drawing.Size(114, 22);
            this.txtsubjectname.TabIndex = 1;
            this.txtsubjectname.TextChanged += new System.EventHandler(this.txtsubjectname_TextChanged);
            // 
            // dataGridViewSubject
            // 
            this.dataGridViewSubject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSubject.Location = new System.Drawing.Point(269, 37);
            this.dataGridViewSubject.Name = "dataGridViewSubject";
            this.dataGridViewSubject.RowHeadersWidth = 51;
            this.dataGridViewSubject.RowTemplate.Height = 24;
            this.dataGridViewSubject.Size = new System.Drawing.Size(519, 150);
            this.dataGridViewSubject.TabIndex = 2;
            this.dataGridViewSubject.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSubject_CellContentClick);
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.Location = new System.Drawing.Point(24, 342);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(75, 23);
            this.btnAddSubject.TabIndex = 3;
            this.btnAddSubject.Text = "Add";
            this.btnAddSubject.UseVisualStyleBackColor = true;
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // btnUpdateSubject
            // 
            this.btnUpdateSubject.Location = new System.Drawing.Point(316, 342);
            this.btnUpdateSubject.Name = "btnUpdateSubject";
            this.btnUpdateSubject.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateSubject.TabIndex = 4;
            this.btnUpdateSubject.Text = "Update";
            this.btnUpdateSubject.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSubject
            // 
            this.btnDeleteSubject.Location = new System.Drawing.Point(176, 342);
            this.btnDeleteSubject.Name = "btnDeleteSubject";
            this.btnDeleteSubject.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSubject.TabIndex = 5;
            this.btnDeleteSubject.Text = "Delete";
            this.btnDeleteSubject.UseVisualStyleBackColor = true;
            this.btnDeleteSubject.Click += new System.EventHandler(this.btnDeleteSubject_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Subject Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Pick the course";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(594, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SubjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteSubject);
            this.Controls.Add(this.btnUpdateSubject);
            this.Controls.Add(this.btnAddSubject);
            this.Controls.Add(this.dataGridViewSubject);
            this.Controls.Add(this.txtsubjectname);
            this.Controls.Add(this.cmbcourses);
            this.Name = "SubjectForm";
            this.Text = "SubjectForm";
            this.Load += new System.EventHandler(this.SubjectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbcourses;
        private System.Windows.Forms.TextBox txtsubjectname;
        private System.Windows.Forms.DataGridView dataGridViewSubject;
        private System.Windows.Forms.Button btnAddSubject;
        private System.Windows.Forms.Button btnUpdateSubject;
        private System.Windows.Forms.Button btnDeleteSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}