using Lokiproject4.DataConnect;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokiproject4.Controllers
{
    internal class LectureSubjectController
    {
        public void AddLecturerSubject(int lecturerId, int subId)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO LecturerSubjects (LecturerId, SubId) VALUES (@LecturerId, @SubId)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LecturerId", lecturerId);
                    cmd.Parameters.AddWithValue("@SubId", subId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteLecturerSubject(int lecturerId, int subId)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                string query = @"DELETE FROM LecturerSubjects WHERE LecturerId = @LecturerId AND SubId = @SubId";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LecturerId", lecturerId);
                    cmd.Parameters.AddWithValue("@SubId", subId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<(int LecturerId, string LName, int SubId, string SubName)> ViewLecturerSubjects()
        {
            var list = new List<(int, string, int, string)>();
            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                string query = @"
                SELECT ls.LecturerId, l.LName, ls.SubId, s.SubName
                FROM LecturerSubjects ls
                INNER JOIN Lecturers l ON ls.LecturerId = l.LecturerId
                INNER JOIN Subjects s ON ls.SubId = s.SubId";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add((
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetInt32(2),
                            reader.GetString(3)
                        ));
                    }
                }
            }
            return list;
        }
    }
}

