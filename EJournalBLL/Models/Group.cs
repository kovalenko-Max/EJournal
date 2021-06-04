using System.Collections.Generic;

namespace EJournalBLL.Models
{
    public class Group
    {
        public int Id;
        public string Name;
        public Course Course;
        public bool IsFinish;
        public int StudentsCount { get; set; }

        public List<Student> Students { get; set; }
        public List<Lesson> Lessons { get; set; }

        public Group(string name, Course course)
        {
            Name = name;
            Course = course;
            IsFinish = false;
            Students = new List<Student>();
        }
    }
}
