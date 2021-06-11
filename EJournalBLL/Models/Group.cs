using System.Collections.Generic;
using System.Linq;

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

        public Group()
        {

        }
        public Group(string name, Course course)
        {
            Name = name;
            Course = course;
            IsFinish = false;
            Students = new List<Student>();
        }

        public override bool Equals(object obj)
        {
            bool equal = false;
            Group group = obj as Group;

            if(!(group is null) && Id ==group.Id && Name ==group.Name && Course.Equals(group.Course)
                && IsFinish==group.IsFinish && StudentsCount == group.StudentsCount)
            {
                equal = true;
            }

            return equal;
        }
    }
}
