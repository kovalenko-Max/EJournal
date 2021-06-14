using Dapper;
using EJournalDAL.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace EJournalDAL.Repository
{
    public class StudentsRepository : IStudentsRepository
    {
        public string ConnectionString { get; set; }
        public StudentsRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString; ;
        }

        public List<StudentDTO> GetAllStudents()
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = $"[EJournal].[{MethodBase.GetCurrentMethod().Name}]";
                students = db.Query<StudentDTO>(connectionQuery).ToList<StudentDTO>();
            }
            return students;
        }

        public List<StudentDTO> SearchByStudentPhone(string phone)
        {
            List<StudentDTO> students = new List<StudentDTO>();
     
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = $"[EJournal].[{ MethodBase.GetCurrentMethod().Name}] @Phone";
                students = db.Query<StudentDTO>(connectionQuery, new { phone }).ToList<StudentDTO>();
            }
            return students;
        }

        public List<StudentDTO> SearchByStudentEmail(string email)
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = $"[EJournal].[{ MethodBase.GetCurrentMethod().Name}] @Email";
                students = db.Query<StudentDTO>(connectionQuery, new { email }).ToList<StudentDTO>();
            }

            return students;
        }

        public List<StudentDTO> SearchStudentsByFullName(string name)
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = $"[EJournal].[{ MethodBase.GetCurrentMethod().Name}] @Name";
                students = db.Query<StudentDTO>(connectionQuery, new { name }).ToList<StudentDTO>();
            }
            return students;
        }

        public List<StudentDTO> SearchByStudentCity(string city)
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = $"[EJournal].[{ MethodBase.GetCurrentMethod().Name}] @City";
                students = db.Query<StudentDTO>(connectionQuery, new { city }).ToList();
            }
            return students;
        }

        public List<StudentDTO> SearchByStudentGroup(string group)
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = $"[EJournal].[{ MethodBase.GetCurrentMethod().Name}] @Group";
                students = db.Query<StudentDTO>(connectionQuery, new { group }).ToList();
            }
            return students;
        }

        public List<StudentDTO> SearchByStudentCourses(string courses)
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = $"[EJournal].[{ MethodBase.GetCurrentMethod().Name}] @Courses";
                students = db.Query<StudentDTO>(connectionQuery, new { courses }).ToList();
            }
            return students;
        }
        public List<StudentDTO> SearchByStudentAgreementNumbers(string AgreementNumbers)
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = $"[EJournal].[{ MethodBase.GetCurrentMethod().Name}] @AgreementNumbers";
                students = db.Query<StudentDTO>(connectionQuery, new { AgreementNumbers }).ToList();
            }
            return students;
        }
        
        public List<StudentDTO> GetStudentsFromProjectGroup(int idProjectGroup)
        {

            List<StudentDTO> students = new List<StudentDTO>();
            string connectionQuery = $"[EJournal].[{ MethodBase.GetCurrentMethod().Name}] @idProjectGroup";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                students = db.Query<StudentDTO>(connectionQuery, new { idProjectGroup }).ToList();
            }
            return students;

        }

        public List<StudentDTO> GetStudentsNotInProjectGroup(int idProjectGroup)
        {

            List<StudentDTO> students = new List<StudentDTO>();
            string connectionQuery = $"[EJournal].[{ MethodBase.GetCurrentMethod().Name}] @idProjectGroup";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                students = db.Query<StudentDTO>(connectionQuery, new { idProjectGroup }).ToList();
            }
            return students;

        }

        public void AddStudent(StudentDTO student)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = $"[EJournal].[{ MethodBase.GetCurrentMethod().Name}] @Name, @Surname, @Email, @Phone, @Git, @City, @Ranking, @AgreementNumber";
                int? userId = db.Query<int>(connectionQuery, student).FirstOrDefault();
                student.Id = userId;
            }
        }

        public void UpdateStudent(StudentDTO student)
        {

            string command = $"[EJournal].[{ MethodBase.GetCurrentMethod().Name}]";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", student.Id);
            parameters.Add("@Name", student.Name);
            parameters.Add("@Surname", student.Surname);
            parameters.Add("@Email", student.Email);
            parameters.Add("@Phone", student.Phone);
            parameters.Add("@Git", student.Git);
            parameters.Add("@City", student.City);
            parameters.Add("@TeacherAssessment", student.TeacherAssessment);
            parameters.Add("@AgreementNumber", student.AgreementNumber);

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(command, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteStudent(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = $"[EJournal].[{ MethodBase.GetCurrentMethod().Name}] @id";
                db.Execute(connectionQuery, new { id });
            }
        }


        public List<StudentDTO> GetStudentsByGroup(int id)
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = $"[EJournal].[{ MethodBase.GetCurrentMethod().Name}] @id";
                students = db.Query<StudentDTO>(connectionQuery, new { id }).ToList();
            }

            return students;
        }

        public List<StudentDTO> GetStudentsNotAreInGroup(int idGroup)
        {
            List<StudentDTO> students = new List<StudentDTO>();

            string connectionQuery = $"[EJournal].[{ MethodBase.GetCurrentMethod().Name}] @idGroup";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                students = db.Query<StudentDTO>(connectionQuery, new { idGroup }).ToList();
            }

            return students;
        }

        public int UpdateStudentRating(int IdStudent)
        {
            string commant = $"[EJournal].[{ MethodBase.GetCurrentMethod().Name}]";
            var parameters = new DynamicParameters();
            parameters.Add("@IdStudent", IdStudent);
            parameters.Add("@Rating", DbType.Int32, direction: ParameterDirection.ReturnValue);

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(commant, parameters, commandType: CommandType.StoredProcedure);
            }

            return parameters.Get<int>("@Rating"); ;
        }
    }
}
