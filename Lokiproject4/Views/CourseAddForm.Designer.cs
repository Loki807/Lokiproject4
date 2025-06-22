namespace Lokiproject4
{
    partial class CourseAddForm
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
            this.coursenameadd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnupdatecourse = new System.Windows.Forms.Button();
            this.datagridcourse = new System.Windows.Forms.DataGridView();
            this.btndeletecourse = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagridcourse)).BeginInit();
            this.SuspendLayout();
            // 
            // coursenameadd
            // 
            this.coursenameadd.Location = new System.Drawing.Point(395, 39);
            this.coursenameadd.Name = "coursenameadd";
            this.coursenameadd.Size = new System.Drawing.Size(294, 22);
            this.coursenameadd.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(214, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Course Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.Location = new System.Drawing.Point(509, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "ADD Course";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnupdatecourse
            // 
            this.btnupdatecourse.BackColor = System.Drawing.Color.Blue;
            this.btnupdatecourse.Location = new System.Drawing.Point(509, 316);
            this.btnupdatecourse.Name = "btnupdatecourse";
            this.btnupdatecourse.Size = new System.Drawing.Size(119, 38);
            this.btnupdatecourse.TabIndex = 7;
            this.btnupdatecourse.Text = "Update";
            this.btnupdatecourse.UseVisualStyleBackColor = false;
            this.btnupdatecourse.Click += new System.EventHandler(this.btnupdatecourse_Click);
            // 
            // datagridcourse
            // 
            this.datagridcourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridcourse.Location = new System.Drawing.Point(2, 159);
            this.datagridcourse.Name = "datagridcourse";
            this.datagridcourse.RowHeadersWidth = 51;
            this.datagridcourse.RowTemplate.Height = 24;
            this.datagridcourse.Size = new System.Drawing.Size(426, 222);
            this.datagridcourse.TabIndex = 8;
            this.datagridcourse.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btndeletecourse
            // 
            this.btndeletecourse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btndeletecourse.Location = new System.Drawing.Point(509, 222);
            this.btndeletecourse.Name = "btndeletecourse";
            this.btndeletecourse.Size = new System.Drawing.Size(119, 40);
            this.btndeletecourse.TabIndex = 5;
            this.btndeletecourse.Text = "Delete";
            this.btndeletecourse.UseVisualStyleBackColor = false;
            this.btndeletecourse.Click += new System.EventHandler(this.btndeletecourse_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(528, 398);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // CourseAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(726, 488);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.datagridcourse);
            this.Controls.Add(this.btnupdatecourse);
            this.Controls.Add(this.btndeletecourse);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.coursenameadd);
            this.Name = "CourseAddForm";
            this.Text = "CourseAdd";
            this.Load += new System.EventHandler(this.CourseAddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridcourse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox coursenameadd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnupdatecourse;
        private System.Windows.Forms.DataGridView datagridcourse;
        private System.Windows.Forms.Button btndeletecourse;
        private System.Windows.Forms.Button button2;
    }
}