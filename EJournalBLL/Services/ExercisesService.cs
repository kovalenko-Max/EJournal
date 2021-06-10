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

        public List<Exercise> GetAllExercises()
        {
            List<ExerciseDTO> exerciseDTO = ExercisesRepository.GetExercises();
            List<Exercise> exercises = ObjectMapper.Mapper.Map<List<Exercise>>(exerciseDTO);
            return exercises;
        }
        public int AddExercise(Exercise exerciseInput)
        {

            ExerciseDTO exercise = ObjectMapper.Mapper.Map<ExerciseDTO>(exerciseInput);
            exerciseInput.Id = ExercisesRepository.Create(exercise);
            return exerciseInput.Id;

        }

        public void UpdateExercise(Exercise exerciseInput)
        {

            ExerciseDTO exercise = ObjectMapper.Mapper.Map<ExerciseDTO>(exerciseInput);
            ExercisesRepository.Update(exercise);

        }

        public void DeleteProject(int Id)
        {
            ExercisesRepository.Delete(Id);

        }
    }
}
