using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using EJournalDAL.Models.BaseModels;
using System.Configuration;

namespace EJournalDAL.Repository
{
    public class CoursesRepository : ICoursesRepository
    {
        private string _connectionString;

        public CoursesRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString;
        }

        public CourseDTO AddCourse(CourseDTO courseDTO)
        {
            string command = "exec AddCourse @Name";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                courseDTO.Id = db.Query<int>(command, new { courseDTO.Name }).FirstOrDefault();
            }

            return courseDTO;
        }

        public void DeleteCourse(int Id)
        {
            string command = "exec DeleteCourse @Id";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(command, new { Id });
            }
        }

        public List<CourseDTO> GetAllCourses()
        {
            string command = "exec GetAllCourses";
            List<CourseDTO> courseDTO = new List<CourseDTO>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                courseDTO = db.Query<CourseDTO>(command).ToList();
            }

            return courseDTO;
        }

        public CourseDTO GetCourse(int id)
        {
            string command = "exec GetCourse @Id";
            CourseDTO courseDTO = null;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                courseDTO = db.Query<CourseDTO>(command, new { id }).FirstOrDefault();
            }

            return courseDTO;
        }

        public void UpdateCourse(CourseDTO courseDTO)
        {
            string command = "exec UpdateCourse @Id, @Name";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(command, new { courseDTO.Id, courseDTO.Name });
            }
        }

        public int CountGroupsByCourse(int Id)
        {
            int count = 0;
            string command = "exec CountGroupsByCourse @Id";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                count = db.Query<int>(command, new { Id }).FirstOrDefault();
            }

            return count;
        }
    }
}
