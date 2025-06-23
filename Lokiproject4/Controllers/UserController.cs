using Lokiproject4.DataConnect;
using Lokiproject4.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lokiproject4.Controllers
{
    internal class UserController
    {
        public void AddUser(Users u)
        {
            using (var connect = Connection.GetConnection())
            {
                connect.Open();
                string query = @"
                INSERT INTO Users (Username, Password, Role, SId, LecturerId, StaffId)
                VALUES (@Username, @Password, @Role, @SId, @LecturerId, @StaffId)";
                using (var cmd = new SQLiteCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@Username", u.Username);
                    cmd.Parameters.AddWithValue("@Password", u.Password);
                    cmd.Parameters.AddWithValue("@Role", u.Role);
                    cmd.Parameters.AddWithValue("@SId", u.SId);
                    cmd.Parameters.AddWithValue("@LecturerId", u.LecturerId);
                    cmd.Parameters.AddWithValue("@StaffId", u.StaffId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        public Users Login(string username, string password)
        {
            using (var connect = Connection.GetConnection())
            {
                connect.Open();
                string query = @"SELECT * FROM Users 
                                 WHERE Username = @Username AND Password = @Password";

                using (var cmd = new SQLiteCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Users
                            {
                                UserId = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Role = reader.GetString(3),
                                SId = reader.IsDBNull(4) ? null : (int?)reader.GetInt32(4),
                                LecturerId = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5),
                                StaffId = reader.IsDBNull(6) ? null : (int?)reader.GetInt32(6)
                            };
                        }
                    }
                }
            }

            return null; // If no matching user
        }
        public List<Users> GetAllUsers()
        {
            List<Users> usersList = new List<Users>();

            using (var connect = Connection.GetConnection())
            {
                connect.Open();
                string query = @"SELECT UserId, Username, Password, Role, SId, LecturerId, StaffId FROM Users";

                using (var cmd = new SQLiteCommand(query, connect))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usersList.Add(new Users
                        {
                            UserId = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Password = reader.GetString(2),
                            Role = reader.GetString(3),
                            SId = reader.IsDBNull(4) ? null : (int?)reader.GetInt32(4),
                            LecturerId = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5),
                            StaffId = reader.IsDBNull(6) ? null : (int?)reader.GetInt32(6)
                        });
                    }
                }
            }

            return usersList;
        }
        public void LoadUsersGrid(DataGridView dgv)
        {
            using (var connect = Connection.GetConnection())
            {
                connect.Open();
                string query = @"SELECT UserId, Username, Password, Role, SId, LecturerId, StaffId FROM Users";

                using (var cmd = new SQLiteCommand(query, connect))
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    var dt = new System.Data.DataTable();
                    adapter.Fill(dt);
                    dgv.DataSource = dt;
                }
            }
        }
    }
}
