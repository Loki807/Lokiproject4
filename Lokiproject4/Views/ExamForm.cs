using Lokiproject4.Controllers;
using Lokiproject4.DataConnect;
using Lokiproject4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lokiproject4.Views
{
    public partial class ExamForm : Form
    {
        public ExamForm()
        {
            InitializeComponent();
            LoadExams();
            LoadSubjects();
            LoadStudents();

        }
        private void LoadStudents()
        {
            cmbStudents.DataSource = new StudentController().ViewStudent();
            cmbStudents.DisplayMember = "SName";
            cmbStudents.ValueMember = "SId";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Exam exam = new Exam
            {
                ExamName = txtExamName.Text,
                SubId = Convert.ToInt32(cmbsubjects.SelectedValue),  // ComboBox with subjects
                SId = Convert.ToInt32(cmbStudents.SelectedValue)     // NEW: Get SId from student ComboBox
            };

            new ExamController().AddExam(exam);
            MessageBox.Show("Exam Added");
            LoadExams();
        }
        private void LoadExams()
        {
            var exams = new ExamController().ViewExams();
            dgvExams.DataSource = exams;
        }
        private void LoadSubjects()
        {
            var subjectList = new SubjectController().ViewSubjects();
            cmbsubjects.DataSource = subjectList;
            cmbsubjects.DisplayMember = "SubName"; // What shows in ComboBox
            cmbsubjects.ValueMember = "SubId";     // What gets used when selected (SubId)
        }


        private void ExamForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard board = new Dashboard();
            board.Show();
            this.Hide();
        }
        public void DeleteExam(int examId)
        {
            using (var connect = Connection.GetConnection())
            {
                connect.Open();
                string query = "DELETE FROM Exams WHERE ExamId = @ExamId";
                SQLiteCommand cmd = new SQLiteCommand(query, connect);
                cmd.Parameters.AddWithValue("@ExamId", examId);
                cmd.ExecuteNonQuery();
            }
        }

        
        

        private void button3_Click(object sender, EventArgs e)
        {

            if (dgvExams.SelectedRows.Count > 0)
            {
                int examId = Convert.ToInt32(dgvExams.SelectedRows[0].Cells["ExamId"].Value);
                new ExamController().DeleteExam(examId);
                MessageBox.Show("Exam Deleted");
                LoadExams();
            }
            else
            {
                MessageBox.Show("Please select an exam to delete.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgvExams.SelectedRows.Count > 0)
            {
                int examId = Convert.ToInt32(dgvExams.SelectedRows[0].Cells["ExamId"].Value);
                Exam exam = new Exam
                {
                    ExamId = examId,
                    ExamName = txtExamName.Text.Trim(),
                    SubId = Convert.ToInt32(cmbsubjects.SelectedValue),
                    SId = Convert.ToInt32(cmbStudents.SelectedValue) // NEW: for update too
                };

                new ExamController().UpdateExam(exam);
                MessageBox.Show("Exam Updated");
                LoadExams();
            }
            else
            {
                MessageBox.Show("Please select an exam to update.");
            }
        }

        private void txtExamName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
