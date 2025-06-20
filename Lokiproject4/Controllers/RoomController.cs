
using Lokiproject4.DataConnect;
using Lokiproject4.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokiproject4.Controllers
{
    internal class RoomController
    {
        public void AddRoom(Room room)
        {
            using (var connect = Connection.GetConnection())
            {
                connect.Open();
                string query = "INSERT INTO Rooms (RoomName, RoomType) VALUES (@RoomName, @RoomType)";
                using (var cmd = new SQLiteCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@RoomName", room.RoomName);
                    cmd.Parameters.AddWithValue("@RoomType", room.RoomType);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Room> ViewRooms()
        {
            List<Room> rooms = new List<Room>();
            using (var connect = Connection.GetConnection())
            {
                connect.Open();
                string query = "SELECT * FROM Rooms";
                using (var cmd = new SQLiteCommand(query, connect))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rooms.Add(new Room
                        {
                            RoomId = reader.GetInt32(0),
                            RoomName = reader.GetString(1),
                            RoomType = reader.GetString(2)
                        });
                    }
                }
            }
            return rooms;
        }
        public void DeleteRoom(int roomId)
        {
            using (var connect = Connection.GetConnection())
            {
                connect.Open();
                string query = "DELETE FROM Rooms WHERE RoomId = @RoomId";
                using (var cmd = new SQLiteCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@RoomId", roomId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
