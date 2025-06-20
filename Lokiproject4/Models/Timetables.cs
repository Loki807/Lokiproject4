using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokiproject4.Models
{
    internal class Timetables
    {
        public int TimetableId { get; set; }
        public int SubId { get; set; }
        public string SubjectName { get; set; }
        public string TimeSlot { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
    }
}
