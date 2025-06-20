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
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadUsers()
        {
            UserController y = new UserController();
            y.LoadUsersGrid(dgv1);

        }

        private void UsersForm_Load(object sender, EventArgs e)
        {

        }
    }
}
