using Lokiproject4.DataConnect;
using Lokiproject4.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lokiproject4.Controllers
{
    public class AttendanceController
    {
        public void AddAttendance(Attendance attendance)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = @"
        INSERT INTO Attendance (SId, SubId, Date, Status) 
        VALUES (@SId, @SubId, @Date, @Status)";
                    using (var cmd = new SQLiteCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@SId", attendance.SId);
                        cmd.Parameters.AddWithValue("@SubId", attendance.SubId);
                        cmd.Parameters.AddWithValue("@Date", attendance.Date.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@Status", attendance.Status);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding attendance: " + ex.Message);
            }
        }

        public List<Attendance> ViewAttendance()
        {
            List<Attendance> list = new List<Attendance>();
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = @"SELECT AttendanceId, SId, SubId, Date, Status FROM Attendance";

                    using (var cmd = new SQLiteCommand(query, connect))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Attendance
                            {
                                AttendanceId = reader.GetInt32(0),
                                SId = reader.GetInt32(1),
                                SubId = reader.GetInt32(2),
                                Date = DateTime.Parse(reader.GetString(3)),
                                Status = reader.GetString(4)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while viewing attendance: " + ex.Message);
            }
            return list;
        }

        public void UpdateAttendance(Attendance attendance)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string updateQuery = @"
        UPDATE Attendance 
        SET SId = @SId, SubId = @SubId, Date = @Date, Status = @Status
        WHERE AttendanceId = @AttendanceId";
                    using (var cmd = new SQLiteCommand(updateQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@SId", attendance.SId);
                        cmd.Parameters.AddWithValue("@SubId", attendance.SubId);
                        cmd.Parameters.AddWithValue("@Date", attendance.Date.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@Status", attendance.Status);
                        cmd.Parameters.AddWithValue("@AttendanceId", attendance.AttendanceId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating attendance: " + ex.Message);
            }
        }

        public void DeleteAttendance(int attendanceId)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = "DELETE FROM Attendance WHERE AttendanceId = @AttendanceId";
                    using (var cmd = new SQLiteCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@AttendanceId", attendanceId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting attendance: " + ex.Message);
            }
        }

        public List<Attendance> ViewAttendanceByStudentAndSubject(int sId, int subId)
        {
            List<Attendance> list = new List<Attendance>();
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = @"SELECT AttendanceId, SId, SubId, Date, Status FROM Attendance 
                     WHERE SId = @SId AND SubId = @SubId";

                    using (var cmd = new SQLiteCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@SId", sId);
                        cmd.Parameters.AddWithValue("@SubId", subId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Attendance
                                {
                                    AttendanceId = reader.GetInt32(0),
                                    SId = reader.GetInt32(1),
                                    SubId = reader.GetInt32(2),
                                    Date = DateTime.Parse(reader.GetString(3)),
                                    Status = reader.GetString(4)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while viewing filtered attendance: " + ex.Message);
            }
            return list;
        }
    }
}

