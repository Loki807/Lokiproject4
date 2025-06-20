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
    internal class TimetableController
    {
       
        
            public void AddTimetable(Timetables tt)
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = "INSERT INTO Timetables (SubId, TimeSlot, RoomId) VALUES (@SubId, @TimeSlot, @RoomId)";
                    using (var cmd = new SQLiteCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@SubId", tt.SubId);
                        cmd.Parameters.AddWithValue("@TimeSlot", tt.TimeSlot);
                        cmd.Parameters.AddWithValue("@RoomId", tt.RoomId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public List<Timetables> ViewTimetables()
            {
                List<Timetables> list = new List<Timetables>();
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = @"
                SELECT t.TimetableId, s.SubName, t.TimeSlot, r.RoomName
                FROM Timetables t
                JOIN Subjects s ON t.SubId = s.SubId
                JOIN Rooms r ON t.RoomId = r.RoomId";

                    using (var cmd = new SQLiteCommand(query, connect))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Timetables
                            {
                                TimetableId = reader.GetInt32(0),
                                SubjectName = reader.GetString(1),
                                TimeSlot = reader.GetString(2),
                                RoomName = reader.GetString(3)
                            });
                        }
                    }
                }
                return list;
            }
        }
    
}
