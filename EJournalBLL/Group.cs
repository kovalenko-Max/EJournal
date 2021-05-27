using System;

namespace EJournalBLL
{
    public class Group
    {
        public int Id;
        public string Name;
        public Course Course;
        public bool IsFinish;

        public Group(string name, Course course)
        {
            Name = name;
            Course = course;
            IsFinish = false;
        }
    }
}
