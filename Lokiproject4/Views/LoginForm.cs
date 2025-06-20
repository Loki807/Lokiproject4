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

                if (user.Role == "Admin")
                {
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                }
                else if (user.Role == "Student")
                {
                    MainStudentDashboard dashboard = new MainStudentDashboard();
                    dashboard.Show();
                }
                else if (user.Role == "Lecturer")
                {
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                }
                else if (user.Role == "Staff")
                {
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                }

                this.Hide(); // hide login form
            }
            else
            {
                MessageBox.Show("Login failed. User not found.");
            }
            /*  string uname = textBox1.Text;
              string pass = textBox2.Text;

              UserController userController = new UserController();
              Users user = userController.Login(uname, pass);

              if (user != null)
              {
                  MessageBox.Show("Login Success");

                  if (user.Role == "Admin")
                  {
                      new Dashboard().Show();
                  }
                  else if (user.Role == "Lecturer")
                  {
                      new LecturerDashboard(user.LecturerId.Value).Show();
                  }
                  else if (user.Role == "Student")
                  {
                      new StudentDashboard(user.StudentId.Value).Show();
                  }
                  else if (user.Role == "Staff")
                  {
                      new StaffDashboard(user.StaffId.Value).Show();
                  }

                  this.Hide();
              }
              else 
              {
                  MessageBox.Show("Invalid Credentials or Invalid username or password");
              }

              this.Hide();*/





        }


        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadUsers()
        {
            UserController y = new UserController();
            y.LoadUsersGrid(dgv2);

        }


    }
}
