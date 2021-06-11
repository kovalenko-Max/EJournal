using EJournalDAL.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalBLL.Models
{
    public class Exercise
    {
        public int Id;
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public int? IdGroup { get; set; }
        public string ExerciseType { get; set; }
        public List<Student> GroupStudents { get; set; }
        public int Point { get; set; }
        public List<StudentMark> StudentMarks { get; set; }

        public Exercise (Group group)
        {
            GroupStudents = new List<Student>();
            StudentMarks = new List<StudentMark>();
        }
        public Exercise(ExerciseDTO exercise)
        {
            Id = exercise.Id;
            Description = exercise.Description;
            Deadline = exercise.Deadline;
            Point = exercise.Point;
        }
    }
}
