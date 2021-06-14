using System;
using System.Collections.Generic;
using System.Text;

namespace EJournalDAL.Models.BaseModels
{
    public class CourseDTO
    {
        public int Id;
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CourseDTO course &&
                   Id == course.Id &&
                   Name == course.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
