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
            LoadLecturers();
           
            LoadRooms();
            LoadTimetables();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

        }
        public bool CanAdd
        {
            get => button2.Visible;
            set => button2.Visible = value;
        }

        public bool CanUpdate
        {
            get => button3.Visible;
            set => button3.Visible = value;
        }

        public bool CanDelete
        {
            get => button4.Visible;
            set => button4.Visible = value;
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

        
        private void LoadTimetables()
        {
            dataGridView1.DataSource = new TimetableController().ViewTimetables();
        }

        private void ClearForm()
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            textBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now; 
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
                    RoomId = Convert.ToInt32(cmbRooms.SelectedValue),
                    DateTimeSlot = dateTimePicker1.Value
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
                RoomId = Convert.ToInt32(comboBox2.SelectedValue),
                DateTimeSlot = dateTimePicker1.Value
            };
            new TimetableController().AddTimetable(tt);
            MessageBox.Show("Timetable Added");
            LoadTimetables();
            ClearForm();
        }
        private void LoadRooms()
        {
            comboBox2.DataSource = new RoomController().ViewRooms();
            comboBox2.DisplayMember = "RoomType";  // Or "RoomName" if you have
            comboBox2.ValueMember = "RoomId";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];

                if (row.Cells["SubId"].Value != DBNull.Value)
                    comboBox1.SelectedValue = Convert.ToInt32(row.Cells["SubId"].Value);

                if (row.Cells["LecturerId"].Value != DBNull.Value)
                    comboBox3.SelectedValue = Convert.ToInt32(row.Cells["LecturerId"].Value);

              

                if (row.Cells["TimeSlot"].Value != DBNull.Value)
                    textBox1.Text = row.Cells["TimeSlot"].Value.ToString();

                if (row.Cells["DateTimeSlot"].Value != DBNull.Value &&
                    DateTime.TryParse(row.Cells["DateTimeSlot"].Value.ToString(), out DateTime dt))
                {
                    dateTimePicker1.Value = dt;
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}
