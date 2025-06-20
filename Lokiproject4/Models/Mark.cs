using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokiproject4.Models
{
    internal class Mark
    {
        
        public int MarkId { get; set; }
        public int SId { get; set; }
        public string SName { get; set; } // optional
        public int ExamId { get; set; }
        public string ExamName { get; set; } // optional
        public int Score { get; set; }
        public int SubId { get; set; }
        public string SubName { get; set; }
    }
}
