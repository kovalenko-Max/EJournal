using EJournalDAL.Models.BaseModels;
using System.Collections.Generic;

namespace EJournalBLL.Models
{
    public class Group
    {
        public int Id;
        public string Name;
        public Course Course;
        public bool IsFinish;
        public int StudentsCount { get; }


        public List<Student> Students;

        public Group(string name, Course course)
        {
            Name = name;
            Course = course;
            IsFinish = false;
            Students = new List<Student>();
        }

        public Group(GroupDTO groupDTO, Course course)
        {
            Id = groupDTO.Id;
            Name = groupDTO.Name;
            Course = course;
            IsFinish = groupDTO.IsFinish == 1;
            StudentsCount = (int)groupDTO.StudentsCount;
            Students = new List<Student>();
        }
    }
}
