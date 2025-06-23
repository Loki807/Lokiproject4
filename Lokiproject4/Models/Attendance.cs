using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokiproject4.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int SId { get; set; }
        public int SubId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
