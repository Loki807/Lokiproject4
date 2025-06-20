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
    public partial class StudentTometable : Form
    {
        public StudentTometable()
        {
            InitializeComponent();
            LoadTimetables();
        
        }

        private void StudentTometable_Load(object sender, EventArgs e)
        {

        }
        private void LoadTimetables()
        {
            dataGridView1.DataSource = new TimetableController().ViewTimetables();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
