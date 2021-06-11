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
            parameters.Add("@StudentExerciseVariable", dt.AsTableValuedParameter("[EJournal].[AddExerciseToStudent]"));
            parameters.Add("@IdExercise", DbType.Int32, direction: ParameterDirection.ReturnValue);

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(command, parameters, commandType: CommandType.StoredProcedure);
            }

            return parameters.Get<int>("@IdExercise");
        }

        public List<ExerciseDTO> GetStudentExercise (int groupId)
        {
            string qr = "exec [EJournal].[GetStudentExercise] @GroupId";
            List<ExerciseDTO> exerciseDTO = new List<ExerciseDTO>();

            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Query<ExerciseDTO, StudentExerciseDTO, ExerciseDTO>(qr,

                    (exercise, student) =>
                    {
                        ExerciseDTO currentExercise = null;
                        foreach (var exerciseDTO in exerciseDTO)
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
                            exerciseDTO.Add(exercise);
                            currentExercise.GroupStudents = new List<StudentExerciseDTO>();
                        }

                        if (student != null)
                        {
                            currentExercise.GroupStudents.Add(student);
                        }

                        return currentExercise;
                    },
                    splitOn: "Id, IdStudent"
                    , param: new { groupId });
            }

            return exerciseDTO;
        }

        public void UpdateStudentExercise(ExerciseDTO exerciseDTO, DataTable dt)
        {
            string command = "[EJournal].[UpdateStudentExercise]";

            var parameters = new DynamicParameters();
            parameters.Add("@IdGroup", exerciseDTO.IdGroup);
            parameters.Add("@Id", exerciseDTO.Id);
            parameters.Add("@Description", exerciseDTO.Description);
            parameters.Add("@ExerciseType", exerciseDTO.ExerciseType);
            parameters.Add("@Deadline", exerciseDTO.Deadline);
            parameters.Add("@StudentExercise", dt.AsTableValuedParameter("[EJourbal].[StudentExercise]"));

            using(IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(command, parameters, commandType: CommandType.StoredProcedure);
            }
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

