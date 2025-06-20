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
        }

        private void LecturerForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lname = txtLName.Text.Trim();
            string department = txtDepartment.Text.Trim();
            string username = lname;
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(lname) || string.IsNullOrWhiteSpace(department) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            Lecturer lec = new Lecturer
            {
                LName = lname,
                Department = department
            };

            LecturerController lecCtrl = new LecturerController();
            UserController userCtrl = new UserController();

            int newLecturerId = lecCtrl.AddLecturertogetId(lec);

            Users user = new Users
            {
                Username = username,
                Password = password,
                Role = "Lecturer",
                
                LecturerId = newLecturerId,
                
            };

            userCtrl.AddUser(user);

            MessageBox.Show("Lecturer and user added successfully.");
            ClearForm();
            LoadLecturers();
        }
        private void ClearForm()
        {
            txtLName.Text = "";
            txtDepartment.Text = "";
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

                LecturerController ctrl = new LecturerController();
                ctrl.DeleteLecturer(lecturerId);

                MessageBox.Show("Lecturer deleted successfully.");
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
                    Department = txtDepartment.Text.Trim()
                };

                LecturerController ctrl = new LecturerController();
                ctrl.UpdateLecturer(updated);

                MessageBox.Show("Lecturer updated successfully.");
                LoadLecturers();
                ClearForm();
            }
        }
    }
}
