using System.Collections.Generic;
using EJournalBLL.Models;
using EJournalDAL.Repository;
using EJournalDAL.Models.BaseModels;

namespace EJournalBLL.Services
{
    public class ExercisesService
    {
        public ExercisesRepository ExercisesRepository { get; set; }

        

        public ExercisesService()
        {
            ExercisesRepository = new ExercisesRepository();
        }

        //public List<Exercise> GetAllExercises()
        //{
            
        //}
        public int AddExercise(Exercise exerciseInput)
        {
            return 0;
            
        }

        public void UpdateExercise(Exercise exerciseInput)
        {

            

        }

        public void DeleteProject(int Id)
        {

        }
    }
}
