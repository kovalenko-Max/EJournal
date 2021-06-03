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
        public int? IdExerciseType { get; set; }
        public bool IsDelete { get; set; }
    }
}
