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
    public class CourseController
    {
        public void AddCourse(Courses C1)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string InsertQuery = @"INSERT INTO Courses(CName) VALUES(@CName)";
                    SQLiteCommand cmd = new SQLiteCommand(InsertQuery, connect);
                    cmd.Parameters.AddWithValue("@CName", C1.CName);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Course added");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding course: " + ex.Message);
            }
        }

        public void UpdateCourse(Courses C1)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string UpdateQuery = @"UPDATE Courses SET CName = @CName WHERE CId = @CId";
                    SQLiteCommand cmd = new SQLiteCommand(UpdateQuery, connect);
                    cmd.Parameters.AddWithValue("@CName", C1.CName);
                    cmd.Parameters.AddWithValue("@CId", C1.CId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Course updated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating course: " + ex.Message);
            }
        }

        public void DeleteCourse(int courseId)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string DeleteQuery = @"DELETE FROM Courses WHERE CId = @CId";
                    SQLiteCommand cmd = new SQLiteCommand(DeleteQuery, connect);
                    cmd.Parameters.AddWithValue("@CId", courseId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Course deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting course: " + ex.Message);
            }
        }

        public List<Courses> ViewCourse()
        {
            List<Courses> courseList = new List<Courses>();
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string viewQuery = @"SELECT * FROM Courses";
                    using (SQLiteCommand cmd = new SQLiteCommand(viewQuery, connect))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Courses course = new Courses
                            {
                                CId = reader.GetInt32(0),
                                CName = reader.GetString(1)
                            };
                            courseList.Add(course);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error viewing courses: " + ex.Message);
            }

            return courseList;
        }

        public int GetCourseIdByName(string courseName)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();

                    string checkQuery = "SELECT CId FROM Courses WHERE CName = @CName";
                    using (var cmd = new SQLiteCommand(checkQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@CName", courseName);
                        var result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }

                    string insertQuery = "INSERT INTO Courses(CName) VALUES(@CName); SELECT last_insert_rowid();";
                    using (var cmd = new SQLiteCommand(insertQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@CName", courseName);
                        long newId = (long)cmd.ExecuteScalar();
                        return (int)newId;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting course ID by name: " + ex.Message);
                return -1;
            }
        }

        public string GetCourseNameById(int courseId)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = "SELECT CName FROM Courses WHERE CId = @CId";
                    using (var cmd = new SQLiteCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@CId", courseId);
                        object result = cmd.ExecuteScalar();
                        return result != null ? result.ToString() : "Unknown";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting course name by ID: " + ex.Message);
                return "Error";
            }
        }

    }
}