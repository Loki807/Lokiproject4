using Lokiproject4.Controllers;
using Lokiproject4.Models;
using Lokiproject4.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lokiproject4
{
    public partial class txtcoursename : Form
    {
        private StudentController controller;
        private int studentId;
        public txtcoursename()
        {
            InitializeComponent();
            Loadview();
           // LoadUsers();



        }
        public void Loadview()
        {
            controller = new StudentController();
            var totalview=controller.ViewStudent();
            Dataviewstudents.DataSource = totalview;
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            string studentName = txtstudentname.Text.Trim();
            string courseName = txtcoursename2.Text.Trim();
            string Address=txtAddress.Text.Trim();
            string passwords= STUPASSWORD.Text.Trim();  
            if (string.IsNullOrWhiteSpace(studentName) || string.IsNullOrWhiteSpace(courseName))
            {
                MessageBox.Show("Please enter both student name and course name.");
                return;
            }

            //try
            {
                // 1. Get or add course
                CourseController courseController = new CourseController();
                int courseId = courseController.GetCourseIdByName(courseName);
                string address = txtAddress.Text.Trim();
                // 2. Create student object
                Student student = new Student()
                {
                    SName = studentName,
                    Address = address,
                    CId = courseId,
                    
                };

                // 3. Add student and get new SId
                StudentController std = new StudentController();
                int newSId = std.AddStudentAndGetId(student); // this must return last inserted ID

                // 4. Create user for student
                Users user = new Users
                {
                    Username = studentName,

                    Password = passwords, // default password or add textbox later
                    Role = "Student",
                    SId = newSId,
                    
                    
                };

                UserController userCtrl = new UserController();
                userCtrl.AddUser(user);

                MessageBox.Show("Student and user added successfully.");
                txtstudentname.Clear();
                txtcoursename2.Clear();
            }
            /*catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }*/



        }

        private void StudentForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            if (Dataviewstudents.SelectedRows.Count > -1)
            {

                var selectedRow = Dataviewstudents.SelectedRows[0];
                
                studentId = Convert.ToInt32(selectedRow.Cells["SId"].Value);
                
                StudentController controller = new StudentController();
                controller.DeleteStudent(studentId);

                
                Loadview();
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (Dataviewstudents.SelectedRows.Count > 0)
            {
                int studentId = Convert.ToInt32(Dataviewstudents.SelectedRows[0].Cells["SId"].Value);
                string updatedName = txtstudentname.Text;
                string courseName = txtcoursename2.Text.Trim();
                string Address = txtAddress.Text.Trim();
                string passwords = STUPASSWORD.Text.Trim();

                Student updatedStudent = new Student
                {
                    SId = studentId,
                    SName = updatedName,
                    Address = Address,
                   
                    //Address=updateadddress,
                };

                StudentController controller = new StudentController();
                controller.UpdateStudent(updatedStudent);

                Loadview();
                ClearTextBoxes();


            }
            else
            {
                MessageBox.Show("Please select a student to update.");
            }
           
        }
        private void ClearTextBoxes()
        {
            txtstudentname.Text ="";
            //txtstudentaddress.Text = "";
            //txtstudentid.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dashboard board = new Dashboard();
            board.Show();
            this.Hide();
        }
       /* private void LoadUsers()
        {
            UserController userCtrl = new UserController();
            userCtrl.LoadUsersGrid(dataGridView1);
        }*/

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
