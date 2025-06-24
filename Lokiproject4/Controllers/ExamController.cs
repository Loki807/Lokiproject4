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
    internal class ExamController
    {
        public void AddExam(Exam exam)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = "INSERT INTO Exams (ExamName, SubId, SId) VALUES (@ExamName, @SubId, @SId)";
                    SQLiteCommand cmd = new SQLiteCommand(query, connect);
                    cmd.Parameters.AddWithValue("@ExamName", exam.ExamName);
                    cmd.Parameters.AddWithValue("@SubId", exam.SubId);
                    cmd.Parameters.AddWithValue("@SId", exam.SId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding exam: " + ex.Message);
            }
        }

        public List<Exam> ViewExams()
        {
            List<Exam> exams = new List<Exam>();
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = @"
        SELECT e.ExamId, e.ExamName, s.SubId, e.SId
        FROM Exams e
        JOIN Subjects s ON e.SubId = s.SubId
        JOIN Students a ON e.SId = a.SId";

                    SQLiteCommand cmd = new SQLiteCommand(query, connect);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        exams.Add(new Exam
                        {
                            ExamId = reader.GetInt32(0),
                            ExamName = reader.GetString(1),
                            SubId = reader.GetInt32(2),
                            SId = reader.GetInt32(3)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error viewing exams: " + ex.Message);
            }
            return exams;
        }

        public void DeleteExam(int examId)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = "DELETE FROM Exams WHERE ExamId = @ExamId";
                    SQLiteCommand cmd = new SQLiteCommand(query, connect);
                    cmd.Parameters.AddWithValue("@ExamId", examId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting exam: " + ex.Message);
            }
        }

        public void UpdateExam(Exam exam)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = "UPDATE Exams SET ExamName = @ExamName, SubId = @SubId, SId = @SId WHERE ExamId = @ExamId";
                    SQLiteCommand cmd = new SQLiteCommand(query, connect);
                    cmd.Parameters.AddWithValue("@ExamName", exam.ExamName);
                    cmd.Parameters.AddWithValue("@SubId", exam.SubId);
                    cmd.Parameters.AddWithValue("@SId", exam.SId);
                    cmd.Parameters.AddWithValue("@ExamId", exam.ExamId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating exam: " + ex.Message);
            }
        }
    }
}
