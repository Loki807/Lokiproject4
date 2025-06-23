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
    public partial class MainStudentDashboard : Form
    {
        public MainStudentDashboard()
        {
            InitializeComponent();
        }

        private void MainStudentDashboard_Load(object sender, EventArgs e)
        {

        }
        private void LoadFormIntoPanel(Form formToLoad)
        {
            panel2.Controls.Clear();
            formToLoad.TopLevel = false;
            formToLoad.FormBorderStyle = FormBorderStyle.None;
            formToLoad.Dock = DockStyle.Fill;
            panel2.Controls.Add(formToLoad);
            formToLoad.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtcoursename studentForm = new txtcoursename();

            studentForm.CanAdd = false;
            studentForm.CanUpdate = false;
            studentForm.CanDelete = false;
            studentForm.CanClear = false;
            

            LoadFormIntoPanel(studentForm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtTimeslot timetableForm = new txtTimeslot();

            // Make it read-only
            timetableForm.CanAdd = false;
            timetableForm.CanUpdate = false;
            timetableForm.CanDelete = false;

            LoadFormIntoPanel(timetableForm);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var marksForm = new MarksForm();

            // Hide add, update, delete, clear buttons to make it read-only
            marksForm.CanAdd = false;
            marksForm.CanUpdate = false;
            marksForm.CanDelete = false;
            marksForm.CanClear = false;
            LoadFormIntoPanel(marksForm);
        }
    }
}
