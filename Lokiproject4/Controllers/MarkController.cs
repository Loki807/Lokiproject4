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
    internal class MarkController
    {
        public void AddOrUpdateMark(Mark mark)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();

                    string insert = "INSERT INTO Marks (SId, SubId, ExamId, Score) VALUES (@SId, @SubId, @ExamId, @Score)";
                    using (var cmdInsert = new SQLiteCommand(insert, connect))
                    {
                        cmdInsert.Parameters.AddWithValue("@SId", mark.SId);
                        cmdInsert.Parameters.AddWithValue("@SubId", mark.SubId);
                        cmdInsert.Parameters.AddWithValue("@ExamId", mark.ExamId);
                        cmdInsert.Parameters.AddWithValue("@Score", mark.Score);
                        cmdInsert.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding or updating mark: " + ex.Message);
            }
        }

        public List<Mark> ViewMarks()
        {
            List<Mark> marks = new List<Mark>();
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = @"
            SELECT m.MarkId, st.SId, st.SName, ex.ExamId, ex.ExamName, m.Score, sub.SubId, sub.SubName
            FROM Marks m
            JOIN Students st ON m.SId = st.SId
            JOIN Exams ex ON m.ExamId = ex.ExamId
            JOIN Subjects sub ON m.SubId = sub.SubId";

                    using (var cmd = new SQLiteCommand(query, connect))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            marks.Add(new Mark
                            {
                                MarkId = reader.GetInt32(0),
                                SId = reader.GetInt32(1),
                                SName = reader.GetString(2),
                                ExamId = reader.GetInt32(3),
                                ExamName = reader.GetString(4),
                                Score = reader.GetInt32(5),
                                SubId = reader.GetInt32(6),
                                SubName = reader.GetString(7)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error viewing marks: " + ex.Message);
            }
            return marks;
        }

        public List<Mark> ViewMarksForStudent(int studentId)
        {
            try
            {
                return ViewMarks().Where(m => m.SId == studentId).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error viewing marks for student: " + ex.Message);
                return new List<Mark>();
            }
        }

        public void DeleteMark(int markId)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string delete = "DELETE FROM Marks WHERE MarkId = @MarkId";
                    using (var cmd = new SQLiteCommand(delete, connect))
                    {
                        cmd.Parameters.AddWithValue("@MarkId", markId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting mark: " + ex.Message);
            }
        }

        public void UpdateMark(Mark mark)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string update = "UPDATE Marks SET SId = @SId, SubId = @SubId, ExamId = @ExamId, Score = @Score WHERE MarkId = @MarkId";
                    using (var cmd = new SQLiteCommand(update, connect))
                    {
                        cmd.Parameters.AddWithValue("@SId", mark.SId);
                        cmd.Parameters.AddWithValue("@SubId", mark.SubId);
                        cmd.Parameters.AddWithValue("@ExamId", mark.ExamId);
                        cmd.Parameters.AddWithValue("@Score", mark.Score);
                        cmd.Parameters.AddWithValue("@MarkId", mark.MarkId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating mark: " + ex.Message);
            }
        }

        public void LoadMarksGrid(DataGridView dgv)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = @"
                SELECT 
                    m.MarkId, 
                    st.SId, 
                    st.SName, 
                    ex.ExamId, 
                    ex.ExamName, 
                    m.Score, 
                    sub.SubId, 
                    sub.SubName
                FROM Marks m
                JOIN Students st ON m.SId = st.SId
                JOIN Exams ex ON m.ExamId = ex.ExamId
                JOIN Subjects sub ON m.SubId = sub.SubId";

                    using (var cmd = new SQLiteCommand(query, connect))
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        var dt = new System.Data.DataTable();
                        adapter.Fill(dt);
                        dgv.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading marks grid: " + ex.Message);
            }
        }

    }
}
