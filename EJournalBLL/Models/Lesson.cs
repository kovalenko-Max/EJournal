using EJournalDAL.Models.BaseModels;
using System;
using System.Collections.Generic;

namespace EJournalBLL.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public DateTime DateLesson { get; set; }
        public int IdGroup { get; set; }

        public List<Attendances> Attendances;

        public Lesson()
        {
            Topic = string.Empty;
            DateLesson = DateTime.Now;
            Attendances = new List<Attendances>();
        }

        public Lesson(LessonDTO lessonDTO)
        {
            Id = lessonDTO.Id;
            Topic = lessonDTO.Topic;
            DateLesson = lessonDTO.DateLesson;
        }
    }
}
