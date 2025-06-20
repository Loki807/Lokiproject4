﻿using Lokiproject4.DataConnect;
using Lokiproject4.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokiproject4.Controllers
{
    internal class ExamController
    {
        public void AddExam(Exam exam)
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

        public List<Exam> ViewExams()
        {
            List<Exam> exams = new List<Exam>();
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
                    }); // <-- You were missing this closing parenthesis
                }
            }
            return exams;
        }

        public void DeleteExam(int examId)
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

        public void UpdateExam(Exam exam)
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
    }
}
