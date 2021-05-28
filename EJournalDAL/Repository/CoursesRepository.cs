using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using EJournalDAL.Models.BaseModels;

namespace EJournalDAL.Repository
{
    public class CoursesRepository
    {
        public string ConnectionString;

        public CoursesRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public CourseDTO AddCourseDTO(CourseDTO courseDTO)
        {
            string command = "exec AddCourse @Name";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                courseDTO = db.Query<CourseDTO>(command, new { courseDTO.Name}).FirstOrDefault();
            }

            return courseDTO;
        }

        public void DeleteCourseDTO(CourseDTO courseDTO)
        {
            string command = "exec DeleteCourse @Id";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(command, new { courseDTO.Id });
            }
        }

        public List<CourseDTO> GetAllCoursesDTO()
        {
            string command = "exec GetAllCourses";
            List<CourseDTO> courseDTO = new List<CourseDTO>();
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                courseDTO = db.Query<CourseDTO>(command).ToList();
            }

            return courseDTO;
        }

        public CourseDTO GetCourseDTO(int id)
        {
            string command = "exec GetCourse @Id";
            CourseDTO courseDTO = null;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                courseDTO = db.Query<CourseDTO>(command, new { id }).FirstOrDefault();
            }

            return courseDTO;
        }

        public void UpdateCourseDTO(CourseDTO courseDTO)
        {
            string command = "exec UpdateGroup @Id, @Name";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(command, new { courseDTO.Id, courseDTO.Name });
            }
        }
    }
}
