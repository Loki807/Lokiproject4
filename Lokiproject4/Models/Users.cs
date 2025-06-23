using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokiproject4.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int? SId { get; set; }          // Student ID (nullable)
        public int? LecturerId { get; set; }   // Lecturer ID (nullable)
        public int? StaffId { get; set; }
        public int AdminId { get; set; }
    }  
}