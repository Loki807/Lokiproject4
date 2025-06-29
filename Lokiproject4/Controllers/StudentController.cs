﻿using Lokiproject4.DataConnect;
using Lokiproject4.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lokiproject4.Controllers
{
    public class StudentController
    {
        public void AddStuden(Student student)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string InsertQuery = @"INSERT INTO Students(SName,Address,CId) VALUES(@SName,@CId,@Address)";
                    using (var cms = new SQLiteCommand(InsertQuery, connect))
                    {
                        cms.Parameters.AddWithValue("@SName", student.SName);
                        cms.Parameters.AddWithValue("@CId", student.CId);
                        cms.Parameters.AddWithValue("@Address", student.Address);
                        cms.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding student: " + ex.Message);
            }
        }

        public List<Student> ViewStudent()
        {
            List<Student> studentsTotal = new List<Student>();
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string viewQuery = @"SELECT Students.SId, Students.SName, Students.Address, Students.CId 
                         FROM Students
                         LEFT JOIN Courses ON Students.CId = Courses.CId
        ";

                    using (var cms = new SQLiteCommand(viewQuery, connect))
                    using (var getter = cms.ExecuteReader())
                    {
                        while (getter.Read())
                        {
                            studentsTotal.Add(new Student
                            {
                                SId = getter.GetInt32(0),
                                SName = getter.GetString(1),
                                Address = getter.GetString(2),
                                CId = getter.IsDBNull(3) ? 0 : getter.GetInt32(3),
                                //CName = getter.IsDBNull(4) ? "No Course" : getter.GetString(4)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error viewing students: " + ex.Message);
            }
            return studentsTotal;
        }

        public void DeleteStudent(int studentId)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string deleteQuery = @"DELETE FROM Students WHERE SId = @SId";
                    using (var cmd = new SQLiteCommand(deleteQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@SId", studentId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting student: " + ex.Message);
            }
        }

        public void UpdateStudent(Student student)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    const string updateQuery = @"UPDATE Students 
                                     SET SName = @SName, Address = @Address, CId = @CId 
                                     WHERE SId = @SId";
                    using (var cmd = new SQLiteCommand(updateQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@SName", student.SName);
                        cmd.Parameters.AddWithValue("@Address", student.Address);
                        cmd.Parameters.AddWithValue("@CId", student.CId);
                        cmd.Parameters.AddWithValue("@SId", student.SId);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating student: " + ex.Message);
            }
        }

        public int AddStudentAndGetId(Student student)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string insertQuery = @"INSERT INTO Students(SName, Address, CId) 
                               VALUES(@SName, @Address, @CId); 
                               SELECT last_insert_rowid();";
                    using (var cmd = new SQLiteCommand(insertQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@SName", student.SName);
                        cmd.Parameters.AddWithValue("@Address", student.Address);
                        cmd.Parameters.AddWithValue("@CId", student.CId);

                        return Convert.ToInt32((long)cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding student and getting ID: " + ex.Message);
                return -1;
            }
        }

        public DataTable GetStudentsTable()
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = @"SELECT SId, SName, Address, CId FROM Students";
                    using (var cmd = new SQLiteCommand(query, connect))
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting students table: " + ex.Message);
                return new DataTable();
            }
        }

        public string GetPasswordByStudentId(int studentId)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = @"SELECT Password FROM Users WHERE SId = @SId";
                    using (var cmd = new SQLiteCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@SId", studentId);
                        object result = cmd.ExecuteScalar();
                        return result != null ? result.ToString() : "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting password by student ID: " + ex.Message);
                return "";
            }
        }

        public List<Student> GetStudents()
        {
            List<Student> list = new List<Student>();
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = "SELECT SId, SName FROM Students";
                    using (var cmd = new SQLiteCommand(query, connect))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Student
                            {
                                SId = reader.GetInt32(0),
                                SName = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting students: " + ex.Message);
            }
            return list;
        }
    }

}

