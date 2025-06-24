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
    public partial class StudentvideoForm : Form
    {
        public StudentvideoForm()
        {
            InitializeComponent();
            cmbSubjects.Items.AddRange(new string[] { "Math", "Science", "ICT", "English" });
        }

        private void btnLoadVideo_Click(object sender, EventArgs e)
        {
            string subject = cmbSubjects.Text;

            switch (subject)
            {
                case "Math":
                    webVideo.Navigate("https://youtu.be/NybHckSEQBI?si=rquxKpR7SB2ahvY6"); // Example math video
                    rtbNotes.Text = "📘 Math Notes:\n- Learn basic algebra\n- Understand fractions\n- Practice word problems";
                    break;

                case "Science":
                    webVideo.Navigate("https://youtu.be/PkX6gazrJlM?si=kXveQSJknHl8YPLi"); // Photosynthesis
                    rtbNotes.Text = "🔬 Science Notes:\n- Photosynthesis = process in plants\n- Needs sunlight + water\n- Makes oxygen";
                    break;

                case "ICT":
                    webVideo.Navigate("https://youtu.be/xND0t1pr3KY?si=7FAM8CaDAfC4opDE"); // What is ICT
                    rtbNotes.Text = "💻 ICT Notes:\n- ICT = Information & Communication Tech\n- Includes internet, computers, AI\n- Used in schools and offices";
                    break;

                case "English":
                    webVideo.Navigate("https://youtu.be/aOsILFNgtIo?si=Jnh1wLiYRz3TM6LE"); // Essay writing
                    rtbNotes.Text = "📗 English Notes:\n- Start with introduction\n- Use good grammar\n- Write conclusion";
                    break;

                default:
                    MessageBox.Show("Please select a subject.", "Info");
                    break;
            }
        }

        private void cmbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StudentvideoForm_Load(object sender, EventArgs e)
        {

        }

        private void webVideo_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
    
}
