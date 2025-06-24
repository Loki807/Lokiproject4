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
    public class StaffController
    {
        public void AddStaff(Staff s)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = "INSERT INTO Staffs (StaffName, RoleType) VALUES (@StaffName, @RoleType)";
                    using (var cmd = new SQLiteCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@StaffName", s.StaffName);
                        cmd.Parameters.AddWithValue("@RoleType", s.RoleType);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding staff: " + ex.Message);
            }
        }

        public int AddStaffAndGetId(Staff s)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = @"INSERT INTO Staffs (StaffName, RoleType) 
                              VALUES (@StaffName, @RoleType); 
                              SELECT last_insert_rowid();";
                    using (var cmd = new SQLiteCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@StaffName", s.StaffName);
                        cmd.Parameters.AddWithValue("@RoleType", s.RoleType);
                        return Convert.ToInt32((long)cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding staff and getting ID: " + ex.Message);
                return -1;
            }
        }

        public List<Staff> ViewStaffs()
        {
            List<Staff> list = new List<Staff>();
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = "SELECT * FROM Staffs";
                    using (var cmd = new SQLiteCommand(query, connect))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Staff
                            {
                                StaffId = reader.GetInt32(0),
                                StaffName = reader.GetString(1),
                                RoleType = reader.GetString(2)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error viewing staffs: " + ex.Message);
            }
            return list;
        }

        public void UpdateStaff(Staff s)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = @"UPDATE Staffs 
                              SET StaffName = @StaffName, RoleType = @RoleType 
                              WHERE StaffId = @StaffId";
                    using (var cmd = new SQLiteCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@StaffName", s.StaffName);
                        cmd.Parameters.AddWithValue("@RoleType", s.RoleType);
                        cmd.Parameters.AddWithValue("@StaffId", s.StaffId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating staff: " + ex.Message);
            }
        }

        public void DeleteStaff(int staffId)
        {
            try
            {
                using (var connect = Connection.GetConnection())
                {
                    connect.Open();
                    string query = "DELETE FROM Staffs WHERE StaffId = @StaffId";
                    using (var cmd = new SQLiteCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@StaffId", staffId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting staff: " + ex.Message);
            }
        }
    }

}
