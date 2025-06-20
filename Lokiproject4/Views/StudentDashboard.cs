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
    public partial class StudentDashboard : Form
    {
        private DataTable studentsTable;
        private StudentController controller;
        public StudentDashboard()
        {
            InitializeComponent();
            Loadview();
        }

        private void StudentDashboard_Load(object sender, EventArgs e)
        {

        }
        public void Loadview()
        {
            controller = new StudentController();
            studentsTable = controller.GetStudentsTable();
            dgv1.DataSource = studentsTable;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (studentsTable == null) return;

            string filterText = txtSearch.Text.Trim();
            studentsTable.DefaultView.RowFilter = $"SName LIKE '%{filterText}%'";

            if (dgv1.Rows.Count > 0)
            {
                dgv1.ClearSelection();
                dgv1.Rows[0].Selected = true;
                dgv1.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
