using Lokiproject4.Controllers;
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
    public partial class StudentSubjectForm : Form
    {
       
        private StudentController controller1;
        private SubjectController controller2;
        private StudentSubjectController controller;
        private int oldStudentId = -1;
        private int oldSubjectId = -1;
        public StudentSubjectForm()
        {
            InitializeComponent();
            controller1 = new StudentController();
            controller2 = new SubjectController();
            controller = new StudentSubjectController(); // ✅ FIXED

            LoadStudentsCombo();
            LoadSubjectsCombo();
            LoadStudentSubjectsGrid();

            datagridviewStudentSubject.SelectionChanged += datagridviewStudentSubject_SelectionChanged;
        }

        private void StudentSubjectForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadStudentsCombo()
        {
            controller1 = new StudentController();
            controller2 = new SubjectController();
            var students = controller1.GetStudents();
            cmbStudents.DataSource = students;
            cmbStudents.DisplayMember = "SName";
            cmbStudents.ValueMember = "SId";
        }

        private void LoadSubjectsCombo()
        {
            var subjects = controller2.GetSubjects(); 
            if (subjects != null && subjects.Count > 0)
            {
                cmbSubjects.DataSource = subjects;
                cmbSubjects.DisplayMember = "SubName";
                cmbSubjects.ValueMember = "SubId";
            }
            else
            {
                cmbSubjects.DataSource = null;
            }
        }


        private void LoadStudentSubjectsGrid()
        {
            controller = new StudentSubjectController();
            
            var list = controller.ViewStudentSubjects();

            DataTable dt = new DataTable();
            dt.Columns.Add("Student ID");
            dt.Columns.Add("Student Name");
            dt.Columns.Add("Subject ID");
            dt.Columns.Add("Subject Name");

            foreach (var item in list)
            {
                dt.Rows.Add(item.SId, item.SName, item.SubId, item.SubName);
            }

            datagridviewStudentSubject.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int studentId = (int)cmbStudents.SelectedValue;
            int subjectId = (int)cmbSubjects.SelectedValue;

            try
            {
                controller.AddStudentSubject(studentId, subjectId);
                MessageBox.Show("Added successfully");
                LoadStudentSubjectsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding record: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (oldStudentId == -1 || oldSubjectId == -1)
            {
                MessageBox.Show("Please select a record to delete.");
                return;
            }

            try
            {
                controller.DeleteStudentSubject(oldStudentId, oldSubjectId);
                MessageBox.Show("Deleted successfully");
                LoadStudentSubjectsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (oldStudentId == -1 || oldSubjectId == -1)
            {
                MessageBox.Show("Please select a record to update.");
                return;
            }

            int newStudentId = (int)cmbStudents.SelectedValue;
            int newSubjectId = (int)cmbSubjects.SelectedValue;

            try
            {
                controller.UpdateStudentSubject(oldStudentId, oldSubjectId, newStudentId, newSubjectId);
                MessageBox.Show("Updated successfully");
                LoadStudentSubjectsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message);
            }
        }
        private void datagridviewStudentSubject_SelectionChanged(object sender, EventArgs e)
        {
            if (datagridviewStudentSubject.SelectedRows.Count > 0)
            {
                var row = datagridviewStudentSubject.SelectedRows[0];
                oldStudentId = Convert.ToInt32(row.Cells["Student ID"].Value);
                oldSubjectId = Convert.ToInt32(row.Cells["Subject ID"].Value);
            }
        }

    }
}

