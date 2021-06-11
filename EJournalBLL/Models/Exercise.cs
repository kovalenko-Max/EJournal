using System;

namespace EJournalBLL.Models
{
    public class Exercise
    {
        public int? Id;
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public int? IdGroup { get; set; }
        public string ExerciseType { get; set; }

        public Exercise()
        {
                
        }
        public override bool Equals(object obj)
        {
            bool equal = false;
            Exercise exercise = obj as Exercise;

            if(!(exercise is null) && Description==exercise.Description && Deadline==exercise.Deadline
                && IdGroup==exercise.IdGroup && ExerciseType==exercise.ExerciseType)
            {
                equal = true;
            }
            return equal;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
