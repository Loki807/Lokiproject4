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
    internal class SubjectController
    {
        public void AddSubject(Subject sub)
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

        public void UpdateSubject(Subject sub)
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

        public void DeleteSubject(int subId)
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

        public List<Subject> ViewSubjects()
        {
            List<Subject> subjects = new List<Subject>();

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

            return subjects;
        }
    }
}

