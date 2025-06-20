using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokiproject4.Models
{
    internal class Exam
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }

        public int SubId { get; set; }
        public string SubName { get; set; }
    }
}
