namespace Lokiproject4.Views
{
    partial class MarksForm
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
            this.cmbStudents = new System.Windows.Forms.ComboBox();
            this.cmbExams = new System.Windows.Forms.ComboBox();
            this.dgvMarks = new System.Windows.Forms.DataGridView();
            this.btnSaveMark = new System.Windows.Forms.Button();
            this.numScore = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.Student = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSubjects = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScore)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbStudents
            // 
            this.cmbStudents.FormattingEnabled = true;
            this.cmbStudents.Location = new System.Drawing.Point(380, 61);
            this.cmbStudents.Name = "cmbStudents";
            this.cmbStudents.Size = new System.Drawing.Size(121, 24);
            this.cmbStudents.TabIndex = 0;
            this.cmbStudents.SelectedIndexChanged += new System.EventHandler(this.cmbStudents_SelectedIndexChanged);
            // 
            // cmbExams
            // 
            this.cmbExams.FormattingEnabled = true;
            this.cmbExams.Location = new System.Drawing.Point(380, 129);
            this.cmbExams.Name = "cmbExams";
            this.cmbExams.Size = new System.Drawing.Size(121, 24);
            this.cmbExams.TabIndex = 1;
            // 
            // dgvMarks
            // 
            this.dgvMarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarks.Location = new System.Drawing.Point(12, 260);
            this.dgvMarks.Name = "dgvMarks";
            this.dgvMarks.RowHeadersWidth = 51;
            this.dgvMarks.RowTemplate.Height = 24;
            this.dgvMarks.Size = new System.Drawing.Size(758, 150);
            this.dgvMarks.TabIndex = 2;
            this.dgvMarks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarks_CellContentClick);
            // 
            // btnSaveMark
            // 
            this.btnSaveMark.Location = new System.Drawing.Point(579, 199);
            this.btnSaveMark.Name = "btnSaveMark";
            this.btnSaveMark.Size = new System.Drawing.Size(75, 23);
            this.btnSaveMark.TabIndex = 4;
            this.btnSaveMark.Text = "Add";
            this.btnSaveMark.UseVisualStyleBackColor = true;
            this.btnSaveMark.Click += new System.EventHandler(this.btnSaveMark_Click);
            // 
            // numScore
            // 
            this.numScore.Location = new System.Drawing.Point(380, 200);
            this.numScore.Name = "numScore";
            this.numScore.Size = new System.Drawing.Size(120, 22);
            this.numScore.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(704, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Student
            // 
            this.Student.AutoSize = true;
            this.Student.Location = new System.Drawing.Point(251, 68);
            this.Student.Name = "Student";
            this.Student.Size = new System.Drawing.Size(52, 16);
            this.Student.TabIndex = 7;
            this.Student.Text = "Student";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(254, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Exams";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "marks";
            // 
            // cmbSubjects
            // 
            this.cmbSubjects.FormattingEnabled = true;
            this.cmbSubjects.Location = new System.Drawing.Point(379, 99);
            this.cmbSubjects.Name = "cmbSubjects";
            this.cmbSubjects.Size = new System.Drawing.Size(121, 24);
            this.cmbSubjects.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "subjects";
            // 
            // MarksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbSubjects);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Student);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numScore);
            this.Controls.Add(this.btnSaveMark);
            this.Controls.Add(this.dgvMarks);
            this.Controls.Add(this.cmbExams);
            this.Controls.Add(this.cmbStudents);
            this.Name = "MarksForm";
            this.Text = "MarksForm";
            this.Load += new System.EventHandler(this.MarksForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbStudents;
        private System.Windows.Forms.ComboBox cmbExams;
        private System.Windows.Forms.DataGridView dgvMarks;
        private System.Windows.Forms.Button btnSaveMark;
        private System.Windows.Forms.NumericUpDown numScore;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Student;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSubjects;
        private System.Windows.Forms.Label label3;
    }
}