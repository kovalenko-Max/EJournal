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

        public override bool Equals(object obj)
        {
            bool isEquals = false;

            if (obj is Group)
            {
                Group group = (Group)obj;
                isEquals = Id == group.Id && Name == group.Name;

                if(Course != null && group.Course != null)
                {
                    isEquals = isEquals && Course.Equals(group.Course);
                }
            }

            return isEquals;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
