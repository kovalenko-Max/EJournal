using Dapper;
using EJournalDAL.Models.BaseModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EJournalDAL.Repository
{
    public class StudentsRepository
    {
        public string ConnectionString { get; set; }
        public StudentsRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<StudentDTO> GetAll()
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec [EJournal].[GetAllStudents]";
                students = db.Query<StudentDTO>(connectionQuery).ToList<StudentDTO>();
            }
            return students;
        }
        public List<StudentDTO> GetStudentsFromOneProjectGroup(int idProjectGroup)
        {

            List<StudentDTO> students = new List<StudentDTO>();
            string connectionQuery = $"exec [EJournal].[GetListStudentsInOneProjectGroup] @idProjectGroup";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                students = db.Query<StudentDTO>(connectionQuery, new { idProjectGroup }).ToList();
            }
            return students;

        }

        public List<StudentDTO> GetStudentsNotAreInProjectGroup(int idProjectGroup)
        {

            List<StudentDTO> students = new List<StudentDTO>();
            string connectionQuery = $"exec GetListStudentsNotInTheConcreeteProjectGroup @idProjectGroup";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                students = db.Query<StudentDTO>(connectionQuery, new { idProjectGroup }).ToList();
            }
            return students;

        }

        public StudentDTO GetOne(int id)
        {
            StudentDTO student = new StudentDTO();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec [EJournal].[GetStudent] @Id";
                student = db.Query<StudentDTO>(connectionQuery, new { id }).FirstOrDefault();
            }

            return student;
        }

        public StudentDTO Create(StudentDTO student)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec [EJournal].[AddStudent] @Name, @Surname, @Email, @Phone, @Git, @City, @Ranking, @AgreementNumber";
                int? userId = db.Query<int>(connectionQuery, student).FirstOrDefault();
                student.Id = userId;
            }
            return student;
        }

        public void Update(StudentDTO student)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = " exec [EJournal].[UpdateStudent] @Id, @Name, @Surname, @Email, @Phone, @Git, @City, @Ranking, @AgreementNumber";
                db.Execute(connectionQuery, student);
            }
        }

        public void DeleteSoft(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec [EJournal].[DeleteStudent] @id";
                db.Execute(connectionQuery, new { id });
            }
        }

        public void DeleteOne(int Id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec ";
                db.Execute(connectionQuery, new { Id });
            }
        }

        public void DeleteAll()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec ";
                db.Execute(connectionQuery);
            }
        }
        public List<StudentDTO> GetStudentsByGroup(int id)
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec [EJournal].[GetStudentByGroup] @id";
                students = db.Query<StudentDTO>(connectionQuery, new { id }).ToList();
            }

            return students;
        }
        

    }
}
