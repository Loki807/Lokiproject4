using Lokiproject4.DataConnect;
using Lokiproject4.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lokiproject4.Controllers
{
    public class StudentController
    {
        public void AddStuden(Student student)
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

        public List<Student> ViewStudent()
        {
            List<Student> studentsTotal = new List<Student>();

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

            return studentsTotal;
        }

         
        public void DeleteStudent(int studentId)
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

        public void UpdateStudent(Student student)
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

        public int AddStudentAndGetId(Student student)
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

        public DataTable GetStudentsTable()
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
    }
}
