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
    public partial class LectureSubjectsForm : Form
    {

        private int selectedLecturerId = -1;
        private int selectedSubId = -1;
        public LectureSubjectsForm()
        {
            InitializeComponent();
            LoadLecturersCombo();
            LoadSubjectsCombo();
            LoadLecturerSubjectsGrid();
        }

        private void LectureSubjectsForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadLecturersCombo()
        {
            var lecturers = new LecturerController().GetLecturers();
            cmbLecturers.DataSource = lecturers;
            cmbLecturers.DisplayMember = "LName";
            cmbLecturers.ValueMember = "LecturerId";
        }
        private void LoadSubjectsCombo()
        {
            var subjects = new SubjectController().GetSubjects();
            cmbSubjects.DataSource = subjects;
            cmbSubjects.DisplayMember = "SubName";
            cmbSubjects.ValueMember = "SubId";
        }
        private void LoadLecturerSubjectsGrid()
        {
            LectureSubjectController controller=new LectureSubjectController();
            var list = controller.ViewLecturerSubjects();
            DataTable dt = new DataTable();
            dt.Columns.Add("Lecturer ID");
            dt.Columns.Add("Lecturer Name");
            dt.Columns.Add("Subject ID");
            dt.Columns.Add("Subject Name");

            foreach (var item in list)
                dt.Rows.Add(item.LecturerId, item.LName, item.SubId, item.SubName);

            dataGridView1.DataSource = dt;
        }
        private void dgvLecturerSubjects_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedLecturerId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Lecturer ID"].Value);
                selectedSubId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Subject ID"].Value);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedLecturerId == -1 || selectedSubId == -1)
            {
                MessageBox.Show("Please select a record to delete.");
                return;
            }

            try
            {
                LectureSubjectController controller1 = new LectureSubjectController();
                controller1.DeleteLecturerSubject(selectedLecturerId, selectedSubId);
                MessageBox.Show("Deleted successfully.");
                LoadLecturerSubjectsGrid();
                selectedLecturerId = -1;
                selectedSubId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int lecturerId = (int)cmbLecturers.SelectedValue;
            int subId = (int)cmbSubjects.SelectedValue;

            try
            {
                LectureSubjectController controller2 = new LectureSubjectController();
                controller2.AddLecturerSubject(lecturerId, subId);
                MessageBox.Show("Added successfully.");
                LoadLecturerSubjectsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding: " + ex.Message);
            }
        }
    }
}
