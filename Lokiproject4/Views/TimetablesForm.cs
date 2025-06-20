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
            LoadRooms();
        }
        private void LoadRooms()
        {
            cmbRooms.DataSource = new RoomController().ViewRooms();
            cmbRooms.DisplayMember = "RoomName";
            cmbRooms.ValueMember = "RoomId";
        }

        private void LoadSubjects()
        {
            cmbSubjects.DataSource = new SubjectController().ViewSubjects();
            cmbSubjects.DisplayMember = "SubName";
            cmbSubjects.ValueMember = "SubId";
        }

        private void txtTimeslot_Load(object sender, EventArgs e)
        {

        }
        private void LoadTimetables()
        {
            dgvTimetables.DataSource = new TimetableController().ViewTimetables();
        }

        private void btnAddTimetable_Click(object sender, EventArgs e)
        {
            Timetables tt = new Timetables
            {
                SubId = Convert.ToInt32(cmbSubjects.SelectedValue),
                TimeSlot = TimeSlot.Text,
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
    }
    
}
