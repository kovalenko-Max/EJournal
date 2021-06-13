using System;
using System.Collections.Generic;
using System.Text;

namespace EJournalDAL.Models.BaseModels
{
    public class ExerciseDTO
    {
        public int? Id;
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public int? IdGroup { get; set; }
        public string ExerciseType { get; set; }
        public List<StudentExerciseDTO> StudentsExercisesDTO { get; set; }

        public ExerciseDTO( )
        {
            Description = string.Empty;
            StudentsExercisesDTO = new List<StudentExerciseDTO>();
        }

        public override bool Equals(object obj)
        {
            bool equal = false;
            ExerciseDTO exercise = obj as ExerciseDTO;

            if (!(exercise is null) && Description == exercise.Description && Deadline == exercise.Deadline
                && IdGroup == exercise.IdGroup && ExerciseType == exercise.ExerciseType)
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
