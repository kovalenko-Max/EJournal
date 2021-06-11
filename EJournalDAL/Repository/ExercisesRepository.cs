using Dapper;
using EJournalDAL.Models;
using EJournalDAL.Models.BaseModels;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace EJournalDAL.Repository
{
    public class ExercisesRepository
    {
        string connectionString;
        public ExercisesRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ToString();
        }

        public int AddEStudentExercise(ExerciseDTO exerciseDTO, DataTable dt)
        {
            string command = "[EJournal].[AddExerciseToStudent]";

            var parameters = new DynamicParameters();
            parameters.Add("@IdGroup", exerciseDTO.IdGroup);
            parameters.Add("@Description", exerciseDTO.Description);
            parameters.Add("@ExerciseType", exerciseDTO.ExerciseType);
            parameters.Add("@Deadline", exerciseDTO.Deadline);
            parameters.Add("@StudentExerciseVariable", dt.AsTableValuedParameter("[EJournal].[StudentExercise]"));
            parameters.Add("@IdExercise", DbType.Int32, direction: ParameterDirection.ReturnValue);

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(command, parameters, commandType: CommandType.StoredProcedure);
            }

            return parameters.Get<int>("@IdExercise");
        }

        public void UpdateStudentExercise(ExerciseDTO exerciseDTO, DataTable dt)
        {
            string command = "[EJournal].[UpdateStudentExercise]";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", exerciseDTO.Id);
            parameters.Add("@IdGroup", exerciseDTO.IdGroup);
            parameters.Add("@Description", exerciseDTO.Description);
            parameters.Add("@ExerciseType", exerciseDTO.ExerciseType);
            parameters.Add("@Deadline", exerciseDTO.Deadline);
            parameters.Add("@StudentExercise", dt.AsTableValuedParameter("[EJournal].[StudentExercise]"));

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(command, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public List<ExerciseDTO> GetStudentExercise (int IdGroup)
        {
            string command = "exec [EJournal].[GetExercisesByGroup] @IdGroup";
            List<ExerciseDTO> exercisesDTO = new List<ExerciseDTO>();

            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Query<ExerciseDTO, StudentExerciseDTO, ExerciseDTO>(command,

                    (exercise, student) =>
                    {
                        ExerciseDTO currentExercise = null;
                        
                        foreach (var exerciseDTO in exercisesDTO)
                        {
                            if (exerciseDTO.Id == exercise.Id)
                            {
                                currentExercise = exerciseDTO;
                                break;
                            }
                        }

                        if (currentExercise is null)
                        {
                            currentExercise = exercise;
                            exercisesDTO.Add(exercise);
                            currentExercise.StudentsExercisesDTO = new List<StudentExerciseDTO>();
                        }

                        if (student != null)
                        {
                            currentExercise.StudentsExercisesDTO.Add(student);
                        }

                        return currentExercise;
                    },
                    splitOn: "Id, IdStudent"
                    , param: new { IdGroup });
            }

            return exercisesDTO;
        }

        public void DeleteExercise(int id)
        {
            string command = "exec [EJournal].[DeleteStudentExercise] @Id";

            using(IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(command, new { id });
            }
        }
    }
}

