using EJournalBLL.GroupsLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalBLL.ExercisesLogic
{
    public class ExerciseDTO
    {
        public int Id { get; set; }
        public int IdGroup { get; set; }
        public string Description { get; set; }
        public DateTime Dedline { get; set; }
        public int IsDelete{ get; set;}
        public int IdExerciseType { get; set; }
    }
}
