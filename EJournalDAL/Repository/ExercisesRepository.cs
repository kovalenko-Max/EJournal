using Dapper;
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

        public List<ExerciseDTO> GetExercises()
        {

        }

        public ExerciseDTO GetExercise(int id)
        {
  
        }


        public int Create(ExerciseDTO exercise)
        {
            return exercise;
        }

        public void Update(ExerciseDTO exercise)
        {

        }

        public void Delete(int Id)
        {
            
        }
    }
}

