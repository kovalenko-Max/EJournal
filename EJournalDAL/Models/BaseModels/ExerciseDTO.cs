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

        public ExerciseDTO()
        {
            Description = string.Empty;
            StudentsExercisesDTO = new List<StudentExerciseDTO>();
        }
    }
}
