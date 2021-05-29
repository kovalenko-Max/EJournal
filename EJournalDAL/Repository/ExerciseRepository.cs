using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EJournalDAL.Models.BaseModels;

namespace EJournalDAL.Repository
{
    class ExerciseRepository
    {
        public string ConnectionString;

        public ExerciseRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public ExerciseDTO AddExercisesDTO(ExerciseDTO exerciseDTO)
        {
            string command = "exec AddExercises @Description, @Deadline, @IdGroup, @IdExerciseType";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                exerciseDTO.Id = db.Query<int>(command, new { exerciseDTO.Description, exerciseDTO.Dedline, exerciseDTO.IdGroup, exerciseDTO.IdExerciseType }).FirstOrDefault();
            }

            return exerciseDTO;
        }

        public void DeleteExercisesDTO(ExerciseDTO exerciseDTO)
        {
            string command = "exec DeleteExercises @IdGroup";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(command, new { exerciseDTO.Id });
            }
        }

        public List<ExerciseDTO> GetAllExercisesDTO()
        {
            string command = "exec GetAllExercises";
            List<ExerciseDTO> exerciseDTO = new List<ExerciseDTO>();
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                exerciseDTO = db.Query<ExerciseDTO>(command).ToList();
            }

            return exerciseDTO;
        }

        public ExerciseDTO GetExerciseDTO(int id)
        {
            string command = "exec GetExercise @Id";
            ExerciseDTO exerciseDTO = null;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                exerciseDTO = db.Query<ExerciseDTO>(command, new { id }).FirstOrDefault();
            }

            return exerciseDTO;
        }

        public void UpdateExerciseDTO(ExerciseDTO exerciseDTO)
        {
            string command = "exec UpdateExercise  @Description, @Deadline, @IdGroup, @IdExerciseType";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(command, new { exerciseDTO.Description, exerciseDTO.Dedline, exerciseDTO.IdGroup, exerciseDTO.IdExerciseType });
            }
        }
    }
}
