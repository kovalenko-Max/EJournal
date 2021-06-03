using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalBLL.Models
{
    public class Attendance
    {
        public int IdLesson { get; set; }
        public string Topic { get; set; }
        public DateTime DateLesson { get; set; }
        public bool IsPresence { get; set; }
        public int IdStudent { get; set; }
        public string Name { get; set; }
    }
}
