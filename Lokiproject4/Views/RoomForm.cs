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
            dgvRooms.DataSource = new RoomController().ViewRooms();
        }

        private void LoadRoomTypes()
        {
            cmbRoomType.Items.Clear();
            cmbRoomType.Items.Add("Lab");
            cmbRoomType.Items.Add("Hall");
            cmbRoomType.SelectedIndex = 0;
        }

        private void ClearFields()
        {
            cmbRoomType.SelectedIndex = -1;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string roomType = cmbRoomType.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(roomType))
            {
                MessageBox.Show("Please select Room Type.");
                return;
            }

            Room room = new Room
            {
                RoomType = roomType
            };

            RoomController ctrl = new RoomController();
            ctrl.AddRoom(room);

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

                MessageBox.Show("Room deleted.");
                LoadRooms();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Please select a room to delete.");
            }
        }
       

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count > 0)
            {
                int roomId = Convert.ToInt32(dgvRooms.SelectedRows[0].Cells["RoomId"].Value);
                string roomType = cmbRoomType.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(roomType))
                {
                    MessageBox.Show("Select room type.");
                    return;
                }

                Room room = new Room
                {
                    RoomId = roomId,
                    RoomType = roomType
                };

                new RoomController().UpdateRoom(room);
                MessageBox.Show("Room updated successfully.");
                LoadRooms();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Select a row to update.");
            }
        }
    }
}
