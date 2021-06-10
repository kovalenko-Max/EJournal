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

        public List<StudentDTO> SearchStudentPhone(string phone)
        {
            List<StudentDTO> students = new List<StudentDTO>();
     
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec SearchStudentsPhone @Phone";
                students = db.Query<StudentDTO>(connectionQuery, new { phone }).ToList<StudentDTO>();
            }
            return students;
        }

        public List<StudentDTO> SearchStudentEmail(string email)
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec SearchStudentsEmail @Email";
                students = db.Query<StudentDTO>(connectionQuery, new { email }).ToList<StudentDTO>();
            }
            return students;
        }

        public List<StudentDTO> SearchStudentName(string name)
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec SearchStydentsNameSername @Name";
                students = db.Query<StudentDTO>(connectionQuery, new { name }).ToList<StudentDTO>();
            }
            return students;
        }

        public List<StudentDTO> SearchStudentSurname(string surname)
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec SearchStydentsSername @Surname";
                students = db.Query<StudentDTO>(connectionQuery, new { surname }).ToList<StudentDTO>();
            }
            return students;
        }

        public List<StudentDTO> SearchStudentCity(string city)
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec SearchStudentCity @City";
                students = db.Query<StudentDTO>(connectionQuery, new { city }).ToList();
            }
            return students;
        }

        public List<StudentDTO> SearchStudentGroup(string group)
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec SearcStudentsGroup @Group";
                students = db.Query<StudentDTO>(connectionQuery, new { group }).ToList();
            }
            return students;
        }

        public List<StudentDTO> SearchStudentCourses(string courses)
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec SearchStudentCours @Courses";
                students = db.Query<StudentDTO>(connectionQuery, new { courses }).ToList();
            }
            return students;
        }

        public List<StudentDTO> SearchStudentAllStudents()
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec SearchStudentAll";
                students = db.Query<StudentDTO>(connectionQuery).ToList();
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

        public List<StudentDTO> SearchStudentAgreementNumbers(string AgreementNumbers)
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec SearchStudentAgreementNumber @AgreementNumbers";
                students = db.Query<StudentDTO>(connectionQuery, new { AgreementNumbers }).ToList();
            }
            return students;
        }

        public List<StudentDTO> GetStudentsNotAreInProjectGroup(int idProjectGroup)
        {

            List<StudentDTO> students = new List<StudentDTO>();
            string connectionQuery = $"exec [EJournal].[GetListStudentsNotInTheConcreeteProjectGroup] @idProjectGroup";

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
