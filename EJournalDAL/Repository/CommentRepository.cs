using EJournalDAL.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Dapper;
using System.Configuration;

namespace EJournalDAL.Repository
{
    public class CommentRepository
    {
        string connectionString;
        public CommentRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ToString();
        }

        public List <CommentDTO> GetAllComments()
        {
            List<CommentDTO> comments = new List<CommentDTO>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec GetAllComments";
                comments = db.Query<CommentDTO>(connectionQuery).ToList();
            }
            return comments;
        }

        public CommentDTO GetComment(int id)
        {
            CommentDTO comment = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec GetComment @Id";
                comment = db.Query<CommentDTO>(connectionQuery, new { id }).FirstOrDefault();
            }
            return comment;
        }

        public CommentDTO CreateComment(CommentDTO comment)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec AddComment @Comments, @CommentType";
                int? commentId = db.Query<int>(connectionQuery, comment).FirstOrDefault();
                comment.Id = commentId;
            }
            return comment;
        }

        public void UpdateComment(CommentDTO comment)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec UpdateComment @Id, @Comments, @CommentType";
                db.Execute(connectionQuery, comment);
            }    
        }

        public void DeleteComment(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = " exec DeleteComments @Id";
                db.Execute(connectionQuery, new { id });
            }
        }
    }
}
