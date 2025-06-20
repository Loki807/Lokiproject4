namespace Lokiproject4.Views
{
    partial class txtTimeslot
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
            this.cmbSubjects = new System.Windows.Forms.ComboBox();
            this.cmbRooms = new System.Windows.Forms.ComboBox();
            this.TimeSlot = new System.Windows.Forms.TextBox();
            this.btnAddTimetable = new System.Windows.Forms.Button();
            this.dgvTimetables = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimetables)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSubjects
            // 
            this.cmbSubjects.FormattingEnabled = true;
            this.cmbSubjects.Location = new System.Drawing.Point(654, 31);
            this.cmbSubjects.Name = "cmbSubjects";
            this.cmbSubjects.Size = new System.Drawing.Size(121, 24);
            this.cmbSubjects.TabIndex = 0;
            // 
            // cmbRooms
            // 
            this.cmbRooms.FormattingEnabled = true;
            this.cmbRooms.Location = new System.Drawing.Point(654, 108);
            this.cmbRooms.Name = "cmbRooms";
            this.cmbRooms.Size = new System.Drawing.Size(121, 24);
            this.cmbRooms.TabIndex = 1;
            // 
            // TimeSlot
            // 
            this.TimeSlot.Location = new System.Drawing.Point(654, 186);
            this.TimeSlot.Name = "TimeSlot";
            this.TimeSlot.Size = new System.Drawing.Size(100, 22);
            this.TimeSlot.TabIndex = 2;
            // 
            // btnAddTimetable
            // 
            this.btnAddTimetable.Location = new System.Drawing.Point(404, 368);
            this.btnAddTimetable.Name = "btnAddTimetable";
            this.btnAddTimetable.Size = new System.Drawing.Size(75, 23);
            this.btnAddTimetable.TabIndex = 3;
            this.btnAddTimetable.Text = "ADD";
            this.btnAddTimetable.UseVisualStyleBackColor = true;
            this.btnAddTimetable.Click += new System.EventHandler(this.btnAddTimetable_Click);
            // 
            // dgvTimetables
            // 
            this.dgvTimetables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimetables.Location = new System.Drawing.Point(12, 12);
            this.dgvTimetables.Name = "dgvTimetables";
            this.dgvTimetables.RowHeadersWidth = 51;
            this.dgvTimetables.RowTemplate.Height = 24;
            this.dgvTimetables.Size = new System.Drawing.Size(414, 281);
            this.dgvTimetables.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(603, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(536, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "subjects";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(545, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Rooms";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(552, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Timeslot";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtTimeslot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvTimetables);
            this.Controls.Add(this.btnAddTimetable);
            this.Controls.Add(this.TimeSlot);
            this.Controls.Add(this.cmbRooms);
            this.Controls.Add(this.cmbSubjects);
            this.Name = "txtTimeslot";
            this.Text = "TimetablesForm";
            this.Load += new System.EventHandler(this.txtTimeslot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimetables)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSubjects;
        private System.Windows.Forms.ComboBox cmbRooms;
        private System.Windows.Forms.TextBox TimeSlot;
        private System.Windows.Forms.Button btnAddTimetable;
        private System.Windows.Forms.DataGridView dgvTimetables;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}