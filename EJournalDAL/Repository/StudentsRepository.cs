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
        string connectionString;
        public StudentsRepository()
        {
            connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=EJournalDB; Integrated Security=True;";
        }

        public List<StudentDTO> GetStudents()
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec GetAllStudents";
                students = db.Query<StudentDTO>(connectionQuery).ToList<StudentDTO>();
            }
            return students;
        }

        public StudentDTO Get(int id)
        {
            StudentDTO student = null;

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec GetStudent @Id";
                student = db.Query<StudentDTO>(connectionQuery, new { id }).FirstOrDefault();
            }
            return student;
        }

        public StudentDTO Create(StudentDTO student)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec AddStudent @Name, @Surname, @Email, @Phone, @Git, @City, @Ranking, @AdreementNumber";
                int? userId = db.Query<int>(connectionQuery, student).FirstOrDefault();
                student.Id = userId;
            }
            return student;
        }

        public void Update(StudentDTO student)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = " exec UpdateStudent @Id @Name, @Surname, @Email, @Phone, @Git, @City, @Ranking, @AdreementNumber";
                db.Execute(connectionQuery, student);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec DeleteStudent @id";
                db.Execute(connectionQuery, new { id });
            }
        }
    }
}
