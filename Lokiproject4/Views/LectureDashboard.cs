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
    public partial class LectureDashboard : Form
    {
        public LectureDashboard()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtTimeslot timetableForm = new txtTimeslot();

            // Make it read-only
            timetableForm.CanAdd = false;
            timetableForm.CanUpdate = false;
            timetableForm.CanDelete = false;

            LoadFormIntoPanel(timetableForm);
        }

        private void LectureDashboard_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            
            LoadFormIntoPanel(new MarksForm());
        }
    }
}
