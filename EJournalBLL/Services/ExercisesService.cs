using System.Collections.Generic;
using EJournalBLL.Models;
using EJournalDAL.Repository;
using EJournalDAL.Models.BaseModels;
using System.Data;

namespace EJournalBLL.Services
{
    public class ExercisesService
    {
        private DataTable exerciseModel;
        public ExercisesRepository ExercisesRepository { get; set; }
        public List<Exercise> Exercises { get; set; }
        

        public ExercisesService()
        {
            ExercisesRepository = new ExercisesRepository();
            Exercises = new List<Exercise>();

            exerciseModel = new DataTable();
            exerciseModel.Columns.Add("IdStudent");
            exerciseModel.Columns.Add("IdExercise");
            exerciseModel.Columns.Add("Points");
        }

        public void AddExercise(Exercise exercise)
        {
            exerciseModel.Clear();
            foreach (var student in exercise.StudentMarks)
            {
                exerciseModel.Rows.Add(new object[] { student.Student.Id, null, student.Point});
            }

            exercise.Id = ExercisesRepository.AddEStudentExercise(ObjectMapper.Mapper.Map<ExerciseDTO>(exercise), exerciseModel);
        }

        public void UpdateExercise(Exercise exercise)
        {
            exerciseModel.Clear();
            foreach (var student in exercise.StudentMarks)
            {
                exerciseModel.Rows.Add(new object[] { student.Student.Id, null, student.Point });
            }

            exercise.Id = ExercisesRepository.AddEStudentExercise(ObjectMapper.Mapper.Map<ExerciseDTO>(exercise), exerciseModel);
        }

        public void DeleteProject(int Id)
        {

        }

        private List<Exercise> ConvertExerciseDTOToExercise(List<ExerciseDTO> exercisesDTO)
        {
            List<Exercise> exercises = new List<Exercise>();

            foreach (ExerciseDTO exerciseDTO in exercisesDTO)
            {
                exercises.Add(new Exercise(exerciseDTO)
                    {
                        Id = exerciseDTO.Id,
                        IdGroup = exerciseDTO.IdGroup,
                        
                    }); 
            }
            
            return exercises;
        }
    }
}
