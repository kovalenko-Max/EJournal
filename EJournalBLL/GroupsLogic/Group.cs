using EJournalDAL.Models.BaseModels;
using System;

namespace EJournalBLL.GroupsLogic
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

        public Group(GroupDTO groupDTO, Course course)
        {
            Id = groupDTO.Id;
            Name = groupDTO.Name;
            Course = course;
            IsFinish = groupDTO.IsFinish == 1;
        }
    }
}
