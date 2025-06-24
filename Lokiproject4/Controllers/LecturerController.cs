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
    public class LecturerController
    {




        public void AddLecturer(Lecturer lec)
        {
            using (var connect = Connection.GetConnection())
            {
                connect.Open();
                string query = @"INSERT INTO Lecturers (LName, CId, SubId) VALUES (@LName, @CId, @SubId)";
                using (var cmd = new SQLiteCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@LName", lec.LName);
                    cmd.Parameters.AddWithValue("@CId", lec.CId);
                    cmd.Parameters.AddWithValue("@SubId", lec.SubId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int AddLecturertogetId(Lecturer lec)
        {
            using (var connect = Connection.GetConnection())
            {
                connect.Open();
                string query = @"INSERT INTO Lecturers (LName, CId, SubId)
                             VALUES (@LName, @CId, @SubId);
                             SELECT last_insert_rowid();";
                using (var cmd = new SQLiteCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@LName", lec.LName);
                    cmd.Parameters.AddWithValue("@CId", lec.CId);
                    cmd.Parameters.AddWithValue("@SubId", lec.SubId);
                    return Convert.ToInt32((long)cmd.ExecuteScalar());
                }
            }
        }

        public List<Lecturer> ViewLecturers()
        {
            List<Lecturer> list = new List<Lecturer>();
            using (var connect = Connection.GetConnection())
            {
                connect.Open();
                string query = "SELECT * FROM Lecturers";
                using (var cmd = new SQLiteCommand(query, connect))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Lecturer
                        {
                            LecturerId = reader.GetInt32(0),
                            LName = reader.GetString(1),
                            CId = reader.GetInt32(2),
                            SubId = reader.GetInt32(3)
                        });
                    }
                }
            }
            return list;
        }

        public void UpdateLecturer(Lecturer lec)
        {
            using (var connect = Connection.GetConnection())
            {
                connect.Open();
                string updateQuery = @"UPDATE Lecturers 
                                   SET LName = @LName, CId = @CId, SubId = @SubId 
                                   WHERE LecturerId = @LecturerId";
                using (var cmd = new SQLiteCommand(updateQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@LName", lec.LName);
                    cmd.Parameters.AddWithValue("@CId", lec.CId);
                    cmd.Parameters.AddWithValue("@SubId", lec.SubId);
                    cmd.Parameters.AddWithValue("@LecturerId", lec.LecturerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteLecturer(int lecturerId)
        {
            using (var connect = Connection.GetConnection())
            {
                connect.Open();
                string deleteQuery = @"DELETE FROM Lecturers WHERE LecturerId = @LecturerId";
                using (var cmd = new SQLiteCommand(deleteQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@LecturerId", lecturerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<Lecturer> GetLecturers()
        {
            List<Lecturer> list = new List<Lecturer>();

            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT LecturerId, LName, CId, SubId FROM Lecturers";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Lecturer
                        {
                            LecturerId = reader.GetInt32(0),
                            LName = reader.GetString(1),
                            CId = reader.GetInt32(2),
                            SubId = reader.GetInt32(3)
                        });
                    }
                }
            }

            return list;
        }

    }
}
