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
    public partial class StaffForm : Form
    {
        public StaffForm()
        {
            InitializeComponent();
            LoadStaffs();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string staffName = txtStaffName.Text.Trim();
            string roleType = txtRoleType.Text.Trim();
            string username = staffName;
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(staffName) || string.IsNullOrEmpty(roleType) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            Staff s1 = new Staff
            {
                StaffName = staffName,
                RoleType = roleType
            };

            // Add and get StaffId
            int newStaffId = new StaffController().AddStaffAndGetId(s1);

            // Add to Users table
            Users user = new Users
            {
                Username = username,
                Password = password,
                Role = "Staff",
                StaffId = newStaffId
            };

            new UserController().AddUser(user);

            MessageBox.Show("Staff and user added successfully.");
            LoadStaffs();
        }
        private void LoadStaffs()
        {
            dgvStaffs.DataSource = new StaffController().ViewStaffs();
        }

        private void StaffForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvStaffs.SelectedRows.Count > 0)
            {
                int staffId = Convert.ToInt32(dgvStaffs.SelectedRows[0].Cells["StaffId"].Value);
                string updatedName = txtStaffName.Text.Trim();
                string updatedRoleType = txtRoleType.Text.Trim();

                if (string.IsNullOrEmpty(updatedName) || string.IsNullOrEmpty(updatedRoleType))
                {
                    MessageBox.Show("Please enter both staff name and role type.");
                    return;
                }

                Staff updatedStaff = new Staff
                {
                    StaffId = staffId,
                    StaffName = updatedName,
                    RoleType = updatedRoleType
                };

                new StaffController().UpdateStaff(updatedStaff);
                MessageBox.Show("Staff updated successfully.");
                LoadStaffs();
                ClearStaffFields();
            }
            else
            {
                MessageBox.Show("Please select a staff member to update.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvStaffs.SelectedRows.Count > 0)
            {
                int staffId = Convert.ToInt32(dgvStaffs.SelectedRows[0].Cells["StaffId"].Value);

                var confirm = MessageBox.Show("Are you sure you want to delete this staff?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    new StaffController().DeleteStaff(staffId);
                    MessageBox.Show("Staff deleted successfully.");
                    LoadStaffs();
                    ClearStaffFields();
                }
            }
            else
            {
                MessageBox.Show("Please select a staff member to delete.");
            }

        }
        private void ClearStaffFields()
        {
            txtStaffName.Clear();
            txtRoleType.Clear();
            txtPassword.Clear(); // if you use it for user creation
        }
    }
}
