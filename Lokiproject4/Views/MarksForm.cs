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

            dgvMarks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMarks.MultiSelect = false;

            LoadStudents();
            LoadSubjects();
            LoadExams();

            dgvMarks.SelectionChanged += dgvMarks_SelectionChanged;

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
            dgvMarks.DataSource = null;
            new MarkController().LoadMarksGrid(dgvMarks);
            dgvMarks.ClearSelection(); // avoid auto selection
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
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void LoadSubjects()
        {
            cmbSubjects.DataSource = new SubjectController().ViewSubjects();
            cmbSubjects.DisplayMember = "SubName";
            cmbSubjects.ValueMember = "SubId";
        }
       
        private void ClearFields()
        {
            selectedMarkId = -1;
            cmbStudents.SelectedIndex = -1;
            cmbSubjects.SelectedIndex = -1;
            cmbExams.SelectedIndex = -1;
            numScore.Value = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedMarkId == -1)
            {
                MessageBox.Show("Please select a mark to update.");
                return;
            }

            if (cmbStudents.SelectedValue == null || cmbExams.SelectedValue == null || cmbSubjects.SelectedValue == null)
            {
                MessageBox.Show("Please select student, exam, and subject.");
                return;
            }

            Mark mark = new Mark
            {
                MarkId = selectedMarkId,
                SId = Convert.ToInt32(cmbStudents.SelectedValue),
                SubId = Convert.ToInt32(cmbSubjects.SelectedValue),
                ExamId = Convert.ToInt32(cmbExams.SelectedValue),
                Score = (int)numScore.Value
            };

            new MarkController().UpdateMark(mark);
            MessageBox.Show("Mark updated successfully.");
            LoadMarksGrid();
            ClearFields();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedMarkId == -1)
            {
                MessageBox.Show("Please select a mark to delete.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this mark?",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                new MarkController().DeleteMark(selectedMarkId);
                MessageBox.Show("Mark deleted successfully.");
                LoadMarksGrid();
                ClearFields();
            }
        }
        private void dgvMarks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMarks.SelectedRows.Count > 0 && dgvMarks.CurrentRow != null)
            {
                var row = dgvMarks.SelectedRows[0];

                if (row.Cells["MarkId"].Value != DBNull.Value &&
                    row.Cells["SId"].Value != DBNull.Value &&
                    row.Cells["SubId"].Value != DBNull.Value &&
                    row.Cells["ExamId"].Value != DBNull.Value &&
                    row.Cells["Score"].Value != DBNull.Value)
                {
                    selectedMarkId = Convert.ToInt32(row.Cells["MarkId"].Value);
                    cmbStudents.SelectedValue = Convert.ToInt32(row.Cells["SId"].Value);
                    cmbSubjects.SelectedValue = Convert.ToInt32(row.Cells["SubId"].Value);
                    cmbExams.SelectedValue = Convert.ToInt32(row.Cells["ExamId"].Value);
                    numScore.Value = Convert.ToDecimal(row.Cells["Score"].Value);
                }
            }
        }


    }
}

