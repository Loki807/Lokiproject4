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
    public partial class RoomForm : Form
    {
        public RoomForm()
        {
            InitializeComponent();
            LoadRooms();
            LoadRoomTypes();
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadRooms()
        {
            RoomController roomCtrl = new RoomController();
            dgvRooms.DataSource = roomCtrl.ViewRooms();
        }

        private void ClearFields()
        {
            txtRoomName.Text = "";
            cmbRoomType.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string roomName = txtRoomName.Text.Trim();
            string roomType = cmbRoomType.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(roomName) || string.IsNullOrEmpty(roomType))
            {
                MessageBox.Show("Please enter both Room Name and Room Type.");
                return;
            }

            Room room = new Room
            {
                RoomName = roomName,
                RoomType = roomType
            };

            RoomController roomCtrl = new RoomController();
            roomCtrl.AddRoom(room);
            MessageBox.Show("Room added successfully.");
            LoadRooms();
            ClearFields();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count > 0)
            {
                int roomId = Convert.ToInt32(dgvRooms.SelectedRows[0].Cells["RoomId"].Value);
                RoomController ctrl = new RoomController();
                ctrl.DeleteRoom(roomId);
                LoadRooms();
                ClearFields();
                MessageBox.Show("Room deleted.");
            }
            else
            {
                MessageBox.Show("Please select a room to delete.");
            }
        }
        private void LoadRoomTypes()
        {
            cmbRoomType.Items.Clear();
            cmbRoomType.Items.Add("Lab");
            cmbRoomType.Items.Add("Hall");
            cmbRoomType.SelectedIndex = 0; // Set default selection
        }
    }
}
