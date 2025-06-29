﻿using Lokiproject4.DataConnect;
using Lokiproject4.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lokiproject4.Controllers
{
    internal class TimetableController
    {



        public void AddTimetable(Timetables tt)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = @"INSERT INTO Timetables (SubId, LecturerId, TimeSlot, RoomId, DateTimeSlot)
                             VALUES (@SubId, @LecturerId, @TimeSlot, @RoomId, @DateTimeSlot)";
                    using (var cmd = new SQLiteCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@SubId", tt.SubId);
                        cmd.Parameters.AddWithValue("@LecturerId", tt.LecturerId);
                        cmd.Parameters.AddWithValue("@TimeSlot", tt.TimeSlot);
                        cmd.Parameters.AddWithValue("@RoomId", tt.RoomId);
                        cmd.Parameters.AddWithValue("@DateTimeSlot", tt.DateTimeSlot.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding timetable: " + ex.Message);
            }
        }

        public List<Timetables> ViewTimetables()
        {
            List<Timetables> list = new List<Timetables>();
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = @"
                SELECT t.TimetableId, s.SubName, l.LName, t.TimeSlot, r.RoomType, t.DateTimeSlot, t.SubId, t.LecturerId, t.RoomId
                FROM Timetables t
                JOIN Subjects s ON t.SubId = s.SubId
                JOIN Lecturers l ON t.LecturerId = l.LecturerId
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
                                LecturerName = reader.GetString(2),
                                TimeSlot = reader.GetString(3),
                                RoomType = reader.GetString(4),
                                DateTimeSlot = DateTime.Parse(reader.GetString(5)),
                                SubId = reader.GetInt32(6),
                                LecturerId = reader.GetInt32(7),
                                RoomId = reader.GetInt32(8)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error viewing timetables: " + ex.Message);
            }
            return list;
        }

        public void UpdateTimetable(Timetables tt)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string updateQuery = @"
                UPDATE Timetables 
                SET SubId = @SubId, LecturerId = @LecturerId, TimeSlot = @TimeSlot, RoomId = @RoomId, DateTimeSlot = @DateTimeSlot
                WHERE TimetableId = @TimetableId";
                    using (var cmd = new SQLiteCommand(updateQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@SubId", tt.SubId);
                        cmd.Parameters.AddWithValue("@LecturerId", tt.LecturerId);
                        cmd.Parameters.AddWithValue("@TimeSlot", tt.TimeSlot);
                        cmd.Parameters.AddWithValue("@RoomId", tt.RoomId);
                        cmd.Parameters.AddWithValue("@DateTimeSlot", tt.DateTimeSlot.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@TimetableId", tt.TimetableId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating timetable: " + ex.Message);
            }
        }

        public void DeleteTimetable(int timetableId)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = "DELETE FROM Timetables WHERE TimetableId = @TimetableId";
                    using (var cmd = new SQLiteCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@TimetableId", timetableId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting timetable: " + ex.Message);
            }
        }

        public void LoadTimetableGrid(DataGridView dgv)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = @"
                SELECT t.TimetableId, s.SubName AS SubjectName, l.LName AS LecturerName, t.TimeSlot, r.RoomType, t.DateTimeSlot
                FROM Timetables t
                JOIN Subjects s ON t.SubId = s.SubId
                JOIN Lecturers l ON t.LecturerId = l.LecturerId
                JOIN Rooms r ON t.RoomId = r.RoomId";

                    using (var cmd = new SQLiteCommand(query, connect))
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading timetable grid: " + ex.Message);
            }

        }
    }
}



        
 
