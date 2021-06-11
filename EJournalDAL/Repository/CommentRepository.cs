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
        string _connectionString;
        public CommentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List <CommentDTO> GetAllComments()
        {
            List<CommentDTO> comments = new List<CommentDTO>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string connectionQuery = "exec GetAllComments";
                comments = db.Query<CommentDTO>(connectionQuery).ToList();
            }
            return comments;
        }

        public CommentDTO GetComment(int id)
        {
            CommentDTO comment = null;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string connectionQuery = "exec GetComment @Id";
                comment = db.Query<CommentDTO>(connectionQuery, new { id }).FirstOrDefault();
            }
            return comment;
        }

        public CommentDTO CreateComment(CommentDTO comment)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string connectionQuery = "exec AddComment @Comments, @CommentType";
                int commentId = db.Query<int>(connectionQuery, comment).FirstOrDefault();
                comment.Id = commentId;
            }
            return comment;
        }

        public void UpdateComment(CommentDTO comment)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string connectionQuery = "exec UpdateComment @Id, @Comments, @CommentType";
                db.Execute(connectionQuery, comment);
            }    
        }

        public void DeleteComment(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string connectionQuery = " exec DeleteComments @Id";
                db.Execute(connectionQuery, new { id });
            }
        }

        public List<CommentDTO> GetCommentsByStudent(int IdStudent)
        {
            List<CommentDTO> comments = new List<CommentDTO>();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string connectionQuery = "exec GetCommentsByStudent @IdStudent";
                List<CommentDTO> commentDTOs = new List<CommentDTO>();

                comments = db.Query<CommentDTO, CommentTypeDTO, CommentDTO>(connectionQuery,
                    (comment, commentType) =>
                    {
                        comment.CommentType = commentType.Type;

                        return comment;
                    }, 
                    new { IdStudent },
                    splitOn: "Id").ToList();
            }

            return comments;
        }
    }
}
