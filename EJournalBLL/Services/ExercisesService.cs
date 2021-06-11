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
                exerciseModel.Rows.Add(new object[] { student.Student.Id, null, student.Point });
            }

            exercise.Id = ExercisesRepository.AddExerciseToStudent(ObjectMapper.Mapper.Map<ExerciseDTO>(exercise), exerciseModel);
        }

        public void UpdateExercise(Exercise exercise)
        {
            exerciseModel.Clear();
            foreach (var student in exercise.StudentMarks)
            {
                exerciseModel.Rows.Add(new object[] { student.Student.Id, exercise.Id, student.Point });
            }

            ExercisesRepository.UpdateStudentExercise(ObjectMapper.Mapper.Map<ExerciseDTO>(exercise), exerciseModel);
        }

        public List<Exercise> GetExercisesByGroup(Group group)
        {
            List<ExerciseDTO> exerciseDTO = ExercisesRepository.GetExercisesByGroup(group.Id);

            List<Exercise> exercises = ConvertLessonsDTOToLessons(exerciseDTO);

            return exercises;
        }

        public void DeleteStudentExercise(int id)
        {
            ExercisesRepository.DeleteStudentExercise(id);
        }

        private List<Exercise> ConvertLessonsDTOToLessons(List<ExerciseDTO> exercisesDTO)
        {
            List<Exercise> exercise = new List<Exercise>();

            foreach (ExerciseDTO exerciseDTO in exercisesDTO)
            {
                exercise.Add(new Exercise(exerciseDTO)
                {
                    StudentMarks = StudentMark.GetStudentMarksFromStudentExerciseDTO(exerciseDTO.StudentsExercisesDTO)
                });
            }

            return exercise;
        }
    }
}
