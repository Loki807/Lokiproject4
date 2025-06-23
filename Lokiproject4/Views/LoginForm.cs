using Lokiproject4.DataConnect;
using Lokiproject4.Models;
using Lokiproject4.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lokiproject4.Controllers
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            dgv2.SelectionChanged += dgv2_SelectionChanged;
            LoadUsers();


        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            UserController userCtrl = new UserController();
            Users user = userCtrl.Login(username, password);

            if (user != null)
            {
                MessageBox.Show("Login successful!");

              
                if (user.Role == "Student")
                {
                    MainStudentDashboard dashboard = new MainStudentDashboard();
                    dashboard.Show();
                }
                else if (user.Role == "Lecturer")
                {
                    LectureDashboard LectureDashboard1 = new LectureDashboard();
                    LectureDashboard1.Show();
                }
                else if (user.Role == "Staff")
                {
                    StaffDashboard dashboard1 = new StaffDashboard();
                    dashboard1.Show();
                }

                this.Hide(); // hide login form
            }
            else
            {
                MessageBox.Show("Login failed. User not found.");
            }
            



        }


        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadUsers()
        {
            UserController y = new UserController();
            y.LoadUsersGrid(dgv2);

        }
        private void dgv2_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv2.SelectedRows.Count > 0)
            {
                var selectedRow = dgv2.SelectedRows[0];

                txtUsername.Text = selectedRow.Cells["Username"].Value.ToString();
                txtPassword.Text = selectedRow.Cells["Password"] != null ? selectedRow.Cells["Password"].Value.ToString() : "";
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearLoginText();
        }
        public void ClearLoginText()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Hardcoded admin credentials
            const string adminUser = "admin";
            const string adminPass = "password123";

            if (username == adminUser && password == adminPass)
            {
                MessageBox.Show("Login successful! Welcome Admin.");
                Dashboard dashboard = new Dashboard();
                dashboard.Show();

            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}
