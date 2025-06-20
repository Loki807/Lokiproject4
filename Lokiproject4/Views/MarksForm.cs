using Lokiproject4.Controllers;
using Lokiproject4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lokiproject4.Views
{
    public partial class MarksForm : Form
    {
        private int selectedMarkId = -1;

        public MarksForm()
        {
            InitializeComponent();
            LoadStudents();
            
            LoadExams();
            LoadMarksGrid();
        }

        private void MarksForm_Load(object sender, EventArgs e)
        {
            
        }
        private void LoadExams()
        {
            cmbExams.DataSource = new ExamController().ViewExams();
            cmbExams.DisplayMember = "ExamName";
            cmbExams.ValueMember = "ExamId";
        }

        private void LoadMarksGrid( )
        {
            MarkController e = new MarkController();
            e.LoadMarksGrid(dgvMarks);
              
        }

        private void ClearFields()
        {
            selectedMarkId = -1;
            cmbStudents.SelectedIndex = 0;
            cmbExams.SelectedIndex = 0;
            numScore.Value = 0;
        }
        private void LoadStudents()
        {
            cmbStudents.DataSource = new StudentController().ViewStudent();
            cmbStudents.DisplayMember = "SName";
            cmbStudents.ValueMember = "SId";
        }



        private void FormatGrid()
        {
            dgvMarks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
       

        private void cmbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveMark_Click(object sender, EventArgs e)
        {
            if (cmbStudents.SelectedValue == null || cmbExams.SelectedValue == null || cmbSubjects.SelectedValue == null)
            {
                MessageBox.Show("Please select student, exam, and subject.");
                return;
            }

            Mark mark = new Mark
            {
                SId = Convert.ToInt32(cmbStudents.SelectedValue),
                SubId = Convert.ToInt32(cmbSubjects.SelectedValue),
                ExamId = Convert.ToInt32(cmbExams.SelectedValue),
                Score = (int)numScore.Value
            };

            new MarkController().AddOrUpdateMark(mark);
            MessageBox.Show("Mark added successfully.");
            LoadMarksGrid();
            ClearFields();// Refresh grid
        }
        

        private void dgvMarks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMarks.Rows[e.RowIndex].Cells["MarkId"].Value != null)
            {
                selectedMarkId = Convert.ToInt32(dgvMarks.Rows[e.RowIndex].Cells["MarkId"].Value);
                cmbStudents.SelectedValue = dgvMarks.Rows[e.RowIndex].Cells["SId"].Value;
                cmbExams.Text = dgvMarks.Rows[e.RowIndex].Cells["ExamName"].Value.ToString();
                numScore.Value = Convert.ToInt32(dgvMarks.Rows[e.RowIndex].Cells["Score"].Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard board = new Dashboard();
            board.Show();
            this.Hide();
        }
    }
}

