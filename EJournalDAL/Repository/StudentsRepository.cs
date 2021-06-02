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
                string connectionQuery = "exec GetStudent @Id";
                student = db.Query<StudentDTO>(connectionQuery, new { id }).FirstOrDefault();
            }
            return student;
        }

        public StudentDTO AddStudent(StudentDTO student)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec AddStudent @Name, @Surname, @Email, @Phone, @Git, @City, @Ranking, @AgreementNumber";
                int? userId = db.Query<int>(connectionQuery, student).FirstOrDefault();
                student.Id = userId;
            }
            return student;
        }

        public void Update(StudentDTO student)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec UpdateStudent @Id @Name, @Surname, @Email, @Phone, @Git, @City, @Ranking, @AgreementNumber";
                db.Execute(connectionQuery, student);
            }
        }

        public void DeleteSoft(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec DeleteStudent @id";
                db.Execute(connectionQuery, new { id });
            }
        }

        public void HardDeleteAll()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec HardDeleteAllStudents";
                db.Execute(connectionQuery);
            }
        }

        public void HardDelete(StudentDTO studentDTO)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string connectionQuery = "exec HardDeleteStudent @Id";
                db.Execute(connectionQuery, new { studentDTO.Id});
            }
        }
    }
}
