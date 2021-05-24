using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.BasicModels
{
    public class LessonDTO
    {
        public int Id;
        public string Topic { get; set; }
        public DateTime DateLesson { get; set; }
        public int IdGroup { get; set; }
        public int IdTeacher { get; set; }
        public bool IsDelete { get; set; }
    }
}
