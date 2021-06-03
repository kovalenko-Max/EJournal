using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalBLL.Models
{
    public class Lesson
    {
        public int Id;
        public string Topic { get; set; }
        public DateTime DateLesson { get; set; }
        public int IdGroup { get; set; }
        public int IdTeacher { get; set; }
        public bool IsDelete { get; set; }
    }
}
