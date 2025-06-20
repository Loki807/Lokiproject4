using Lokiproject4.DataConnect;
using Lokiproject4.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokiproject4.Controllers
{
    public class StaffController
    {
        public void AddStaff(Staff s)
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

        public int AddStaffAndGetId(Staff s)
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

        public List<Staff> ViewStaffs()
        {
            List<Staff> list = new List<Staff>();
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
            return list;
        }

        public void UpdateStaff(Staff s)
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

        public void DeleteStaff(int staffId)
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
    }

}
