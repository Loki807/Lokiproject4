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
    public partial class SubjectForm : Form
    {
        private SubjectController subjectController = new SubjectController();
        private CourseController courseController = new CourseController();
        private int selectedSubId = -1;
        public SubjectForm()
        {
            InitializeComponent();
            LoadCourses();
            LoadSubjects();

        }

        private void txtsubjectname_TextChanged(object sender, EventArgs e)
        {

        }

        private void SubjectForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadCourses()
        {
            var courses = courseController.ViewCourse();
            cmbcourses.DataSource = courses;
            cmbcourses.DisplayMember = "CName";
            cmbcourses.ValueMember = "CId";
        }

        private void LoadSubjects()
        {
            dataGridViewSubject.DataSource = subjectController.ViewSubjects();
            dataGridViewSubject.Columns["SubId"].HeaderText = "Subject ID";
            dataGridViewSubject.Columns["SubName"].HeaderText = "Subject Name";
            dataGridViewSubject.Columns["CId"].Visible = false;
            dataGridViewSubject.Columns["CName"].HeaderText = "Course Name";
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtsubjectname.Text) || cmbcourses.SelectedValue == null)
            {
                MessageBox.Show("Please enter subject name and select a course.");
                return;
            }

            Subject sub = new Subject
            {
                SubName = txtsubjectname.Text,
                CId = Convert.ToInt32(cmbcourses.SelectedValue)
            };

            subjectController.AddSubject(sub);
            LoadSubjects();
            ClearInputs();
        }

        private void dataGridViewSubject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewSubject.Rows[e.RowIndex];
                selectedSubId = Convert.ToInt32(row.Cells["SubId"].Value);
                txtsubjectname.Text = row.Cells["SubName"].Value.ToString();
                cmbcourses.Text = row.Cells["CName"].Value.ToString();
            }
        }

        private void btnDeleteSubject_Click(object sender, EventArgs e)
        {
            if (selectedSubId == -1)
            {
                MessageBox.Show("Please select a subject to update.");
                return;
            }

            Subject sub = new Subject
            {
                SubId = selectedSubId,
                SubName = txtsubjectname.Text,
                CId = Convert.ToInt32(cmbcourses.SelectedValue)
            };

            subjectController.UpdateSubject(sub);
            LoadSubjects();
            ClearInputs();
        }
        private void ClearInputs()
        {
            txtsubjectname.Text = "";
            cmbcourses.SelectedIndex = 0;
            selectedSubId = -1;
        }

        private void cmbcourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard board = new Dashboard();
            board.Show();
            this.Hide();
        }
    }

}
