using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalBLL.Models
{
    public class Exercise
    {
        public int? Id;
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public int? IdGroup { get; set; }
        public List<Student> GroupStudents { get; set; }
        public string ExerciseType { get; set; }
        public int Mark { get; set; }

        public Exercise (Group group)
        {
            GroupStudents = group.Students;
        }
    }
}
