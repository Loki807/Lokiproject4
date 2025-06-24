using Lokiproject4.DataConnect;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokiproject4.Controllers
{
    public class StudentSubjectController
    {
        public List<(int SId, string SName, int SubId, string SubName)> ViewStudentSubjects()
        {
            var list = new List<(int, string, int, string)>();

            using (var connect = Connection.GetConnection())
            {
                connect.Open();
                string query = @"
                SELECT ss.SId, st.SName, ss.SubId, su.SubName
                FROM StudentSubjects ss
                INNER JOIN Students st ON ss.SId = st.SId
                INNER JOIN Subjects su ON ss.SubId = su.SubId";

                using (var cmd = new SQLiteCommand(query, connect))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add((
                            reader.GetInt32(0),         // SId
                            reader.GetString(1),        // SName
                            reader.GetInt32(2),         // SubId
                            reader.GetString(3)         // SubName
                        ));
                    }
                }
            }

            return list;
        }
        public void AddStudentSubject(int studentId, int subjectId)
        {
            using (var connect = Connection.GetConnection())
            {
                connect.Open();

                string insertQuery = @"INSERT INTO StudentSubjects (SId, SubId) VALUES (@SId, @SubId)";
                using (var cmd = new SQLiteCommand(insertQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@SId", studentId);
                    cmd.Parameters.AddWithValue("@SubId", subjectId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete student-subject link
        public void DeleteStudentSubject(int studentId, int subjectId)
        {
            using (var connect = Connection.GetConnection())
            {
                connect.Open();

                string deleteQuery = @"DELETE FROM StudentSubjects WHERE SId = @SId AND SubId = @SubId";
                using (var cmd = new SQLiteCommand(deleteQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@SId", studentId);
                    cmd.Parameters.AddWithValue("@SubId", subjectId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Update student-subject link (change subject for a student or student for a subject)
        public void UpdateStudentSubject(int oldStudentId, int oldSubjectId, int newStudentId, int newSubjectId)
        {
            using (var connect = Connection.GetConnection())
            {
                connect.Open();

                string updateQuery = @"
                UPDATE StudentSubjects
                SET SId = @NewSId, SubId = @NewSubId
                WHERE SId = @OldSId AND SubId = @OldSubId";

                using (var cmd = new SQLiteCommand(updateQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@NewSId", newStudentId);
                    cmd.Parameters.AddWithValue("@NewSubId", newSubjectId);
                    cmd.Parameters.AddWithValue("@OldSId", oldStudentId);
                    cmd.Parameters.AddWithValue("@OldSubId", oldSubjectId);

                    cmd.ExecuteNonQuery();
                }
            }

        }
    }
}
