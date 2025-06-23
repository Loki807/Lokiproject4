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
    public partial class StaffDashboard : Form
    {
        public StaffDashboard()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadFormIntoPanel(Form formToLoad)
        {
            panel4.Controls.Clear();
            formToLoad.TopLevel = false;
            formToLoad.FormBorderStyle = FormBorderStyle.None;
            formToLoad.Dock = DockStyle.Fill;
            panel4.Controls.Add(formToLoad);
            formToLoad.Show();
        }

        private void zzzzzz_Click(object sender, EventArgs e)
        {
            var marksForm = new MarksForm();

            // Hide add, update, delete, clear buttons to make it read-only
            marksForm.CanAdd = false;
            marksForm.CanUpdate = false;
            marksForm.CanDelete = false;
            marksForm.CanClear = false;
            LoadFormIntoPanel(marksForm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new ExamForm());
        }
    }
    
}
