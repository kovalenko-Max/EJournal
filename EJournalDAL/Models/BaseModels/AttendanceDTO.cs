using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Models.BaseModels
{
    public class AttendanceDTO
    {
        public int IdLesson { get; set; }
        public string Topic { get; set; }
        public DateTime DateLesson { get; set; }
        public bool IsPresence { get; set; }
        public int IdStudent { get; set; }
        public string Name { get; set; }

        public List<LessonDTO> lesson { get; set; }
        public List<StudentDTO> students { get; set; }
    }
}
