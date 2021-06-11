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
        public List<StudentMark> StudentMarks { get; set; }

        public Exercise (Group group)
        {
            Description = string.Empty;

            IdGroup = group.Id;
            ExerciseType = "Soft";
            StudentMarks = new List<StudentMark>();
        }
        public Exercise(ExerciseDTO exercise)
        {
            Id = exercise.Id;
            Description = exercise.Description;
            Deadline = exercise.Deadline;
        }

        public override bool Equals(object obj)
        {
            return obj is Exercise exercise &&
                   Id == exercise.Id &&
                   Description == exercise.Description &&
                   Deadline == exercise.Deadline &&
                   IdGroup == exercise.IdGroup &&
                   ExerciseType == exercise.ExerciseType &&
                   EqualityComparer<List<StudentMark>>.Default.Equals(StudentMarks, exercise.StudentMarks);
        }
    }
}
