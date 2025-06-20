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
        

        public void UpdateCourse(Courses C1)
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

        public void DeleteCourse(int courseId)
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
        public List<Courses> ViewCourse()
        {
            List<Courses> courseList = new List<Courses>();

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

            return courseList;
        }
        public int GetCourseIdByName(string courseName)
        {
            using (var connect = Connection.GetConnection())
            {
                connect.Open();

                // Check if course already exists
                string checkQuery = "SELECT CId FROM Courses WHERE CName = @CName";
                using (var cmd = new SQLiteCommand(checkQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@CName", courseName);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        return Convert.ToInt32(result); // Course exists
                    }
                }

                // If not found, insert new course
                string insertQuery = "INSERT INTO Courses(CName) VALUES(@CName); SELECT last_insert_rowid();";
                using (var cmd = new SQLiteCommand(insertQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@CName", courseName);
                    long newId = (long)cmd.ExecuteScalar(); // Get newly inserted course ID
                    return (int)newId;
                }
            }
        }

    }
}