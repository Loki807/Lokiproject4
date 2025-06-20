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
    public partial class LecturerForm : Form
    {
        public LecturerForm()
        {
            InitializeComponent();
            LoadLecturers();
            LoadCourses();
            LoadSubjects();
        }
        private void LoadCourses()
        {
            cmbCourses.DataSource = new CourseController().ViewCourse();
            cmbCourses.DisplayMember = "CName";
            cmbCourses.ValueMember = "CId";
        }

        private void LoadSubjects()
        {
            cmbSubjects.DataSource = new SubjectController().ViewSubjects();
            cmbSubjects.DisplayMember = "SubName";
            cmbSubjects.ValueMember = "SubId";
        }

        private void LecturerForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lname = txtLName.Text.Trim();
            int cid = Convert.ToInt32(cmbCourses.SelectedValue);
            int subid = Convert.ToInt32(cmbSubjects.SelectedValue);
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(lname) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            Lecturer lec = new Lecturer
            {
                LName = lname,
                CId = cid,
                SubId = subid
            };

            LecturerController lecCtrl = new LecturerController();
            UserController userCtrl = new UserController();

            int newLecturerId = lecCtrl.AddLecturertogetId(lec);

            Users user = new Users
            {
                Username = lname,
                Password = password,
                Role = "Lecturer",
                LecturerId = newLecturerId
            };

            userCtrl.AddUser(user);
            MessageBox.Show("Lecturer and user added successfully.");
            ClearForm();
            LoadLecturers();
        }
        private void ClearForm()
        {
            txtLName.Clear();
            txtPassword.Clear();
            cmbCourses.SelectedIndex = 0;
            cmbSubjects.SelectedIndex = 0;
        }

        private void LoadLecturers()
        {
            dgvLecturers.DataSource = new LecturerController().ViewLecturers();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvLecturers.SelectedRows.Count > 0)
            {
                int lecturerId = Convert.ToInt32(dgvLecturers.SelectedRows[0].Cells["LecturerId"].Value);
                new LecturerController().DeleteLecturer(lecturerId);
                MessageBox.Show("Lecturer deleted.");
                LoadLecturers();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvLecturers.SelectedRows.Count > 0)
            {
                int lecturerId = Convert.ToInt32(dgvLecturers.SelectedRows[0].Cells["LecturerId"].Value);

                Lecturer updated = new Lecturer
                {
                    LecturerId = lecturerId,
                    LName = txtLName.Text.Trim(),
                    CId = Convert.ToInt32(cmbCourses.SelectedValue),
                    SubId = Convert.ToInt32(cmbSubjects.SelectedValue)
                };

                new LecturerController().UpdateLecturer(updated);
                MessageBox.Show("Lecturer updated.");
                LoadLecturers();
                ClearForm();
            }
        }
        
    }
}
