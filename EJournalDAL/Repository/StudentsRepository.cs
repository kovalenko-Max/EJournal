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

        public List<StudentDTO> GetAllStudents()
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec GetAllStudents";
                students = db.Query<StudentDTO>(connectionQuery).ToList<StudentDTO>();
            }
            return students;
        }

        public List<StudentDTO> GetStudentsByGroup(int id)
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec GetStudentByGroup @id";
                students = db.Query<StudentDTO>(connectionQuery, new { id }).ToList<StudentDTO>();
            }

            return students;
        }

        public StudentDTO GetStudent(int id)
        {
            StudentDTO student = null;

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "GetStudent @Id";
                student = db.Query<StudentDTO>(connectionQuery, new { id }).FirstOrDefault();
            }
            return student;
        }

        public StudentDTO Create(StudentDTO student)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "AddStudent @Name, @Surname, @Email, @Phone, @Git, @City, @Ranking, @AdreementNumber";
                int? userId = db.Query<int>(connectionQuery, student).FirstOrDefault();
                student.Id = userId;
            }
            return student;
        }

        public void Update(StudentDTO student)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "UpdateStudent @Id @Name, @Surname, @Email, @Phone, @Git, @City, @Ranking, @AdreementNumber";
                db.Execute(connectionQuery, student);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "DeleteStudent @id";
                db.Execute(connectionQuery, new { id });
            }
        }
    }
}
