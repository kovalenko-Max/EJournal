using System;
using System.Collections.Generic;
using System.Linq;

namespace EJournalBLL.Models
{
    public class ProjectGroup
    {
        public int Id;
        public string Name { get; set; }
        public int? IdProject { get; set; }

        public bool IsDelete { get; set; }

        public List<Student> Students { get; set; }

        public ProjectGroup()
        {

        }
        public ProjectGroup(string projectGroupName)
        {
            Name = projectGroupName;
        }

        public ProjectGroup(string projectGroupName, List<Student> students)
        {
            Name = projectGroupName;
            Students = students;
        }

        public override bool Equals(object obj)
        {
            bool equal = false;

            ProjectGroup project = obj as ProjectGroup;

            if (project != null && Id == project.Id && Name == project.Name && IsDelete == project.IsDelete )
            {
                equal = Students.SequenceEqual(project.Students);
            }
            return equal;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, IsDelete, Students);
        }
    }
}
