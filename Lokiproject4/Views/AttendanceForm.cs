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
    public partial class AttendanceForm : Form
    {
        AttendanceController attendanceController = new AttendanceController();
        StudentController studentController = new StudentController();
        SubjectController subjectController = new SubjectController();

        public AttendanceForm()
        {
            InitializeComponent();
            // sync method calling sync controller methods

            LoadSubjects();
            LoadStudents();
            LoadAttendanceGrid();
            SetupStatusCombo();
        }
        private void LoadSubjects()
        {
            var subjects = subjectController.ViewSubjects();
            comboBox1.DataSource = subjects;
            comboBox1.DisplayMember = "DisplayName"; // Must be SubName + (CourseName) in Subject model
            comboBox1.ValueMember = "SubId";
        }
        private void AttendanceForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadStudents()
        {
            var students = studentController.ViewStudent();
            comboBox2.DataSource = students;
            comboBox2.DisplayMember = "SName";
            comboBox2.ValueMember = "SId";
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1 || comboBox1.SelectedIndex == -1 || cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a student, subject and status");
                return;
            }

            if (!DateTime.TryParse(dateTimePicker1.Text, out DateTime selectedDate))
            {
                MessageBox.Show("Invalid date");
                return;
            }

            var attendance = new Attendance
            {
                SId = Convert.ToInt32(comboBox2.SelectedValue),
                SubId = Convert.ToInt32(comboBox1.SelectedValue),
                Date = selectedDate,
                Status = cmbStatus.SelectedItem.ToString()
            };

            attendanceController.AddAttendance(attendance);
            MessageBox.Show("Attendance saved successfully!");

            LoadAttendanceGrid();
        }

           
        

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadAttendanceGrid()
        {
            var attendanceList = attendanceController.ViewAttendance();
            var students = studentController.ViewStudent();
            var subjects = subjectController.ViewSubjects();

            var data = attendanceList.Select(a => new
            {
                a.AttendanceId,
                a.SId,
                SName = students.FirstOrDefault(s => s.SId == a.SId)?.SName ?? "Unknown",
                a.SubId,
                SubName = subjects.FirstOrDefault(sub => sub.SubId == a.SubId)?.SubName ?? "Unknown",
                Date = a.Date.ToString("yyyy-MM-dd"),
                a.Status
            }).ToList();

            dataGridView1.DataSource = data;
        }
        private void SetupStatusCombo()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[] { "Present", "Absent", "Late", "Excused" });
            cmbStatus.SelectedIndex = 0;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an attendance record to update.");
                return;
            }

            if (comboBox2.SelectedIndex == -1 || comboBox1.SelectedIndex == -1 || cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a student, subject and status");
                return;
            }

            if (!DateTime.TryParse(dateTimePicker1.Text, out DateTime selectedDate))
            {
                MessageBox.Show("Invalid date");
                return;
            }

            int attendanceId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AttendanceId"].Value);

            var attendance = new Attendance
            {
                AttendanceId = attendanceId,
                SId = Convert.ToInt32(comboBox2.SelectedValue),
                SubId = Convert.ToInt32(comboBox1.SelectedValue),
                Date = selectedDate,
                Status = cmbStatus.SelectedItem.ToString()
            };

            attendanceController.UpdateAttendance(attendance);
            MessageBox.Show("Attendance updated successfully!");

            LoadAttendanceGrid();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an attendance record to delete.");
                return;
            }

            int attendanceId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AttendanceId"].Value);

            var confirm = MessageBox.Show("Are you sure you want to delete this attendance record?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                attendanceController.DeleteAttendance(attendanceId);
                MessageBox.Show("Attendance deleted successfully!");

                LoadAttendanceGrid();
            }
        }
    }
}
