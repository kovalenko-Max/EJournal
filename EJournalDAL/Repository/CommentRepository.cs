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
    public class CommentRepository: ICommentRepository
    {
        private string _connectionString;

        public CommentRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString;
        }

        public int AddComment(CommentDTO commentDTO, int IdStudent)
        {
            string connectionQuery = $"[EJournal].[{MethodBase.GetCurrentMethod().Name}]";

            var parameters = new DynamicParameters();
            parameters.Add("IdStudent", IdStudent);
            parameters.Add("@Comments", commentDTO.Comment);
            parameters.Add("@CommentType", commentDTO.CommentType);
            parameters.Add("@IdComment", DbType.Int32, direction: ParameterDirection.ReturnValue);

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(connectionQuery, parameters, commandType: CommandType.StoredProcedure);
            }

            return parameters.Get<int>("@IdComment");
        }

        public void UpdateComment(CommentDTO comment)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string connectionQuery = $"[EJournal].[{ MethodBase.GetCurrentMethod().Name}] @Id, @Comment, @CommentType";
                db.Execute(connectionQuery, comment);
            }
        }

        public void DeleteComment(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string connectionQuery = $"[EJournal].[{MethodBase.GetCurrentMethod().Name}] @Id";
                db.Execute(connectionQuery, new { id });
            }
        }
       
        public List<CommentDTO> GetCommentsByStudent(int IdStudent)
        {
            List<CommentDTO> commentsDTO = new List<CommentDTO>();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string connectionQuery = $"[EJournal].[{MethodBase.GetCurrentMethod().Name}] @IdStudent";

                commentsDTO = db.Query<CommentDTO>(connectionQuery, new { IdStudent }).ToList();
            }

            return commentsDTO;
        }

        public void AddCommentToStudent(CommentDTO commentDTO, DataTable dt)
        {
            string command = $"[EJournal].[{MethodBase.GetCurrentMethod().Name}]";

            var parameters = new DynamicParameters();
            parameters.Add("@CommentType", commentDTO.CommentType);
            parameters.Add("@Comment", commentDTO.Comment);
            parameters.Add("@StudentCommentVarible", dt.AsTableValuedParameter("[EJournal].[StudentsComment]"));

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(command, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}