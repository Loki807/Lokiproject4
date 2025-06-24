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
    internal class SubjectController
    {
        public void AddSubject(Subject sub)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string insertQuery = "INSERT INTO Subjects (SubName, CId) VALUES (@SubName, @CId)";
                    using (var cmd = new SQLiteCommand(insertQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@SubName", sub.SubName);
                        cmd.Parameters.AddWithValue("@CId", sub.CId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding subject: " + ex.Message);
            }
        }

        public void UpdateSubject(Subject sub)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string updateQuery = "UPDATE Subjects SET SubName = @SubName, CId = @CId WHERE SubId = @SubId";
                    using (var cmd = new SQLiteCommand(updateQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@SubName", sub.SubName);
                        cmd.Parameters.AddWithValue("@CId", sub.CId);
                        cmd.Parameters.AddWithValue("@SubId", sub.SubId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating subject: " + ex.Message);
            }
        }

        public void DeleteSubject(int subId)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string deleteQuery = "DELETE FROM Subjects WHERE SubId = @SubId";
                    using (var cmd = new SQLiteCommand(deleteQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@SubId", subId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting subject: " + ex.Message);
            }
        }

        public List<Subject> ViewSubjects()
        {
            List<Subject> subjects = new List<Subject>();
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string viewQuery = @"
                SELECT Subjects.SubId, Subjects.SubName, Courses.CId, Courses.CName
                FROM Subjects
                LEFT JOIN Courses ON Subjects.CId = Courses.CId";

                    using (var cmd = new SQLiteCommand(viewQuery, connect))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjects.Add(new Subject
                            {
                                SubId = reader.GetInt32(0),
                                SubName = reader.GetString(1),
                                CId = reader.GetInt32(2),
                                CName = reader.IsDBNull(3) ? "No Course" : reader.GetString(3)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error viewing subjects: " + ex.Message);
            }
            return subjects;
        }

        public Subject GetSubjectById(int subId)
        {
            Subject subject = null;
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = @"SELECT SubId, SubName, CId FROM Subjects WHERE SubId = @SubId";

                    using (var cmd = new SQLiteCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@SubId", subId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                subject = new Subject
                                {
                                    SubId = reader.GetInt32(0),
                                    SubName = reader.GetString(1),
                                    CId = reader.GetInt32(2)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting subject by ID: " + ex.Message);
            }
            return subject;
        }

        public List<Subject> GetSubjects()
        {
            List<Subject> list = new List<Subject>();
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT SubId, SubName FROM Subjects";
                    using (var cmd = new SQLiteCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Subject
                            {
                                SubId = reader.GetInt32(0),
                                SubName = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting subjects: " + ex.Message);
            }
            return list;
        }



    }
 }