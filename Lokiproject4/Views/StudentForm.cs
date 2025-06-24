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
            Dataviewstudents.SelectionChanged += Dataviewstudents_SelectionChanged;
            Loadview();
            string selectedCourseName = comboBox1.Text;
            LoadCourses();




        }
        private void LoadCourses()
        {
            CourseController courseController= new CourseController();  
            var courses = courseController.ViewCourse();
            comboBox1.DataSource = courses;
            comboBox1.DisplayMember = "CName";
            comboBox1.ValueMember = "CId";
        }

        public bool CanAdd
        {
            get => button1.Visible;
            set => button1.Visible = value;
        }

        public bool CanUpdate
        {
            get => btnupdate.Visible;
            set => btnupdate.Visible = value;
        }

        public bool CanDelete
        {
            get => button2.Visible;
            set => button2.Visible = value;
        }

        public bool CanClear
        {
            get => button3.Visible;
            set => button3.Visible = value;
        }
        public void Loadview()
        {
            controller = new StudentController();
            var totalview=controller.ViewStudent();
            Dataviewstudents.DataSource = totalview;
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            string selectedCourseName = comboBox1.Text;
            string studentName = txtstudentname.Text.Trim();
            string courseName = selectedCourseName;
            string Address=txtAddress.Text.Trim();
            string passwords= STUPASSWORD.Text.Trim();  
            if (string.IsNullOrWhiteSpace(studentName) || string.IsNullOrWhiteSpace(courseName))
            {
                MessageBox.Show("Please enter both student name and course name.");
                return;
            }

            
            {
                
                CourseController courseController = new CourseController();
                int courseId = courseController.GetCourseIdByName(courseName);
                string address = txtAddress.Text.Trim();
                
                Student student = new Student()
                {
                    SName = studentName,
                    Address = address,
                    CId = courseId,
                    
                };

                
                StudentController std = new StudentController();
                int newSId = std.AddStudentAndGetId(student); ]

                ]
                Users user = new Users
                {
                    Username = studentName,

                    Password = passwords, 
                    Role = "Student",
                    SId = newSId,
                    
                    
                };
                
                UserController userCtrl = new UserController();
                userCtrl.AddUser(user);

                MessageBox.Show("Student and user added successfully.");
                txtstudentname.Clear();
                

            }
           



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
                string selectedCourseName = comboBox1.Text;

                int studentId = Convert.ToInt32(Dataviewstudents.SelectedRows[0].Cells["SId"].Value);
                string updatedName = txtstudentname.Text;
                string courseName = selectedCourseName;
                string Address = txtAddress.Text.Trim();
                string passwords = STUPASSWORD.Text.Trim();

                Student updatedStudent = new Student
                {
                    SId = studentId,
                    SName = updatedName,
                    Address = Address,
                   
                    
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
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void ClearStudentText()
        {
            txtstudentname.Text = "";
            txtAddress.Text = "";
            
            STUPASSWORD.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearStudentText();
        }
      

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Dataviewstudents_SelectionChanged(object sender, EventArgs e)
        {
            if (Dataviewstudents.SelectedRows.Count > 0)
            {
                var selectedRow = Dataviewstudents.SelectedRows[0];
                string selectedCourseName = comboBox1.Text;

                int studentId = Convert.ToInt32(selectedRow.Cells["SId"].Value);
                txtstudentname.Text = selectedRow.Cells["SName"].Value.ToString();
                txtAddress.Text = selectedRow.Cells["Address"].Value.ToString();

               
                int courseId = Convert.ToInt32(selectedRow.Cells["CId"].Value);
                CourseController courseCtrl = new CourseController();
                string courseName = courseCtrl.GetCourseNameById(courseId);
                selectedCourseName = courseName;

                
                UserController userCtrl = new UserController();
                string password = controller.GetPasswordByStudentId(studentId);
                STUPASSWORD.Text = password;
            }
        }
    }
}
