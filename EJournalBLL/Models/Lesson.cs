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

        public List<Attendances> Attendances;

        public Lesson()
        {
            DateLesson = DateTime.Now;
        }

        public Lesson(LessonDTO lessonDTO)
        {
            Id = lessonDTO.Id;
            Topic = lessonDTO.Topic;
            DateLesson = lessonDTO.DateLesson;
        }
    }
}
