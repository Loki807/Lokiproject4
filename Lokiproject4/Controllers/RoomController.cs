
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
                string query = "INSERT INTO Rooms (RoomType) VALUES (@RoomType)";
                using (var cmd = new SQLiteCommand(query, connect))
                {
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
                string query = "SELECT RoomId, RoomType FROM Rooms";
                using (var cmd = new SQLiteCommand(query, connect))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rooms.Add(new Room
                        {
                            RoomId = reader.GetInt32(0),
                            RoomType = reader.GetString(1)
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
        public void UpdateRoom(Room room)
        {
            using (var connect = Connection.GetConnection())
            {
                connect.Open();
                string query = "UPDATE Rooms SET RoomType = @RoomType WHERE RoomId = @RoomId";
                using (var cmd = new SQLiteCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@RoomType", room.RoomType);
                    cmd.Parameters.AddWithValue("@RoomId", room.RoomId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
