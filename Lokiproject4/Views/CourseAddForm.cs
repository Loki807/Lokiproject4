using Lokiproject4.Controllers;
using Lokiproject4.Models;
using Lokiproject4.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lokiproject4
{
    public partial class CourseAddForm : Form
    {
        public CourseAddForm()
        {
            InitializeComponent();
            datagridcourse.SelectionChanged += datagridcourse_SelectionChanged;
            LoadCourse();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Courses c1 = new Courses()
            {
                CName = coursenameadd.Text,

            };
            CourseController c2 = new CourseController();
            c2.AddCourse(c1);


            /*txtcoursename studentf1= new txtcoursename();
            studentf1.Show();
            this.Hide();*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadCourse()
        {
            CourseController course1 = new CourseController();
            var showcourse=course1.ViewCourse();
            datagridcourse.DataSource = showcourse;

        

        }

        private void btndeletecourse_Click(object sender, EventArgs e)
        {
            if (datagridcourse.SelectedRows.Count > 0)
            {
                int courseId = Convert.ToInt32(datagridcourse.SelectedRows[0].Cells["CId"].Value);

                CourseController controller = new CourseController();
                controller.DeleteCourse(courseId);

                MessageBox.Show("Course deleted");
                LoadCourse();
            }
            else
            {
                MessageBox.Show("Please select a course to delete.");
            }
        }

        private void btnupdatecourse_Click(object sender, EventArgs e)
        {
            if (datagridcourse.SelectedRows.Count > 0)
            {
                int courseId = Convert.ToInt32(datagridcourse.SelectedRows[0].Cells["CId"].Value);
                string updatedName = coursenameadd.Text;

                Courses updatedCourse = new Courses
                {
                    CId = courseId,
                    CName = updatedName
                };

                CourseController controller = new CourseController();
                controller.UpdateCourse(updatedCourse);

                MessageBox.Show("Course updated");
                LoadCourse();
                ClearCourseText();
            }
        }

        public void ClearCourseText()
        {   
               coursenameadd.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SubjectForm sub1 = new SubjectForm();
            sub1.Show();
             
            this.Hide();
        }

        private void CourseAddForm_Load(object sender, EventArgs e)
        {

        }
        private void datagridcourse_SelectionChanged(object sender, EventArgs e)
        {
            if (datagridcourse.SelectedRows.Count > 0)
            {
                var selectedRow = datagridcourse.SelectedRows[0];

                coursenameadd.Text = selectedRow.Cells["CName"].Value.ToString();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ClearCourseText();
        }
    }
}
