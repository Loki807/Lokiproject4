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
    public partial class txtTimeslot : Form
    {
        public txtTimeslot()
        {
            InitializeComponent();
            LoadSubjects();
            LoadTimetables();
            LoadRoomTypes();
            LoadLecturers();

        }
        private void LoadSubjects()
        {
            comboBox1.DataSource = new SubjectController().ViewSubjects();
            comboBox1.DisplayMember = "SubName";
            comboBox1.ValueMember = "SubId";
        }

        private void LoadLecturers()
        {
            comboBox3.DataSource = new LecturerController().ViewLecturers();
            comboBox3.DisplayMember = "LName";
            comboBox3.ValueMember = "LecturerId";
        }

        private void LoadRoomTypes()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Lab");
            comboBox2.Items.Add("Hall");

            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;
        }

        private void LoadTimetables()
        {
            dataGridView1.DataSource = new TimetableController().ViewTimetables();
        }

        private void ClearForm()
        {
            comboBox1.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            textBox1.Text = "";
        }

        private void btnAddTimetable_Click(object sender, EventArgs e)
        {
            Timetables tt = new Timetables
            {
                SubId = Convert.ToInt32(comboBox1.SelectedValue),
                TimeSlot = textBox1.Text,
                RoomId = Convert.ToInt32(cmbRooms.SelectedValue)
            };
            new TimetableController().AddTimetable(tt);
            MessageBox.Show("Timetable Added");
            LoadTimetables();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard board = new Dashboard();
            board.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtTimeslot_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int timetableId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["TimetableId"].Value);
                new TimetableController().DeleteTimetable(timetableId);
                MessageBox.Show("Timetable Deleted");
                LoadTimetables();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Please select a timetable to delete.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int timetableId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["TimetableId"].Value);
                Timetables tt = new Timetables
                {
                    TimetableId = timetableId,
                    SubId = Convert.ToInt32(comboBox1.SelectedValue),
                    LecturerId = Convert.ToInt32(comboBox3.SelectedValue),
                    TimeSlot = textBox1.Text,
                    RoomId = Convert.ToInt32(comboBox2.SelectedValue)
                };

                new TimetableController().UpdateTimetable(tt);
                MessageBox.Show("Timetable Updated");
                LoadTimetables();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Please select a timetable to update.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Timetables tt = new Timetables
            {
                SubId = Convert.ToInt32(comboBox1.SelectedValue),
                LecturerId = Convert.ToInt32(comboBox3.SelectedValue),
                TimeSlot = textBox1.Text,
                RoomId = Convert.ToInt32(comboBox2.SelectedValue)
            };

            new TimetableController().AddTimetable(tt);
            MessageBox.Show("Timetable Added");
            LoadTimetables();
            ClearForm();
        }
    }
    
}
