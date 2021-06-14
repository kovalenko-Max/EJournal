using System;
using System.Collections.Generic;

namespace EJournalDAL.Models.BaseModels
{
    public class LessonDTO
    {
        public int Id;
        public string Topic { get; set; }
        public DateTime DateLesson { get; set; }
        public List <StudentAttendanceDTO> StudentAttendanceDTO { get; set; }
        public int IdGroup { get; set; }
        public bool IsDelete { get; set; }

        public override bool Equals(object obj)
        {
            bool isEquals = obj is LessonDTO lesson &&
                   Id == lesson.Id &&
                   Topic == lesson.Topic &&
                   DateLesson == lesson.DateLesson &&
                   IdGroup == lesson.IdGroup; ;

            return isEquals;
        }
    }
}
