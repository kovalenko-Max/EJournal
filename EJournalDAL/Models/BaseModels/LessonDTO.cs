using System;
using System.Collections.Generic;
using System.Text;

namespace EJournalDAL.Models.BaseModels
{
    public class LessonDTO
    {
        public int Id;
        public string Topic { get; set; }
        public DateTime DateLesson { get; set; }
        public List <StudentAttendanceDTO> StudentAttendanceDTO { get; set; }
        public int IdGroup { get; set; }
        public int IdTeacher { get; set; }
        public bool IsDelete { get; set; }

        public StudentDTO student;
        public List<StudentDTO> students;
    }
}
