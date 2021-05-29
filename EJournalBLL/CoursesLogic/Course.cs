using EJournalDAL.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalBLL
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Course(string name)
        {
            Name = name;
        }

        public Course(CourseDTO courseDTO)
        {
            Id = courseDTO.Id;
            Name = courseDTO.Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
