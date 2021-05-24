using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.BasicModels
{
    public class ExerciseDTO
    {
        public int? Id;
        public string Description { get; set; }
        public DateTime? Dedline { get; set; }
        public int? IdGroup { get; set; }
        public int? IdExerciseType { get; set; }
        public bool IsDelete { get; set; }
    }
}
