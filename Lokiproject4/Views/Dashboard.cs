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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new txtcoursename());
            /*txtcoursename studentf1= new txtcoursename();
            studentf1.Show();
            this.Hide();*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new CourseAddForm());
           
            

            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new ExamForm());
            /*ExamForm exam1= new ExamForm(); 
            exam1.Show();
            this.Hide();*/
        }

        private void Marks_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new MarksForm());
           /* MarksForm marksForm = new MarksForm();
            marksForm.Show();
            this.Hide();*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new txtTimeslot());
           /* txtTimeslot txtTimeslot = new txtTimeslot();
            txtTimeslot.Show();
            this.Hide();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new SubjectForm());
           /* SubjectForm sub1 = new SubjectForm();
            sub1.Show();

            this.Hide();*/
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new LecturerForm());
           /* LecturerForm lecturerForm = new LecturerForm(); 
            lecturerForm.Show();
            this.Hide();*/
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new StaffForm());
           /* StaffForm staffForm = new StaffForm();  
            staffForm.Show();   
            this.Hide();*/
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new RoomForm());
            /*RoomForm roomForm = new RoomForm();
            roomForm.Show();
            this.Hide();*/
        }
        private void LoadFormIntoPanel(Form formToLoad)
        {
            panelRight.Controls.Clear();
            formToLoad.TopLevel = false;
            formToLoad.FormBorderStyle = FormBorderStyle.None;
            formToLoad.Dock = DockStyle.Fill;
            panelRight.Controls.Add(formToLoad);
            formToLoad.Show();
        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new CourseAddForm());

        }

        private void button9_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new UsersForm());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new AttendanceForm());
        }
    }
}
