using EJournalDAL.Models.BaseModels;
using System.Collections.Generic;
using System.Data;

namespace EJournalDAL.Repository
{
    public interface IExercisesRepository
    {
        public int AddExerciseToStudent(ExerciseDTO exerciseDTO, DataTable dt);
        public void UpdateStudentExercise(ExerciseDTO exerciseDTO, DataTable dt);
        public List<ExerciseDTO> GetExercisesByGroup(int IdGroup);
        public void DeleteStudentExercise(int id);
    }
}
