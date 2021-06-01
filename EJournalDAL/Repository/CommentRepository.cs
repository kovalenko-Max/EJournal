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

namespace EJournalDAL.Repository
{
    public class CommentRepository
    {
        string connectionString;
        public CommentRepository()
        {
            connectionString = @"Data Source=СЕРГЕЙ-ПК\SQLEXPRESS;Initial Catalog=AcademyDB;Integrated Security=True";
        }

        public List<CommentDTO> GetAllComments()
        {
            string connectionQuery = "exec GetAllComments";
            List<CommentDTO> comments = new List<CommentDTO>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                comments = db.Query<CommentDTO>(connectionQuery).ToList();
            }
            return comments;
        }

        public CommentDTO GetComment(int id)
        {
            string connectionQuery = "exec GetComment @Id";
            CommentDTO comment = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                comment = db.Query<CommentDTO>(connectionQuery, new { id }).FirstOrDefault();
            }
            return comment;
        }

        public CommentDTO CreateComment(CommentDTO comment)
        {
            string connectionQuery = "exec AddComment @Comments, @IdTeacher, @IdCommentType";
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                int? commentId = db.Query<int>(connectionQuery, comment).FirstOrDefault();
                comment.Id = commentId;
            }
            return comment;
        }

        public void UpdateComment(CommentDTO comment)
        {
            string connectionQuery = "exec UpdateComment @Id, @Comments, @IdTeacher, @IdCommentType";
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(connectionQuery, comment);
            }
        }

        public void DeleteComment(int id)
        {
            string connectionQuery = "exec DeleteComments @Id";
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(connectionQuery, new { id });
            }
        }

        public void HardDeleteComment(int id)
        {
            string connectionQuery = "exec HadrDeleteComment @Id";
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(connectionQuery, new { id });
            }
        }

        public void HardDeleteAllComments()
        {
            string connectionQuery = "exec HardDeleteAllComments";
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(connectionQuery);
            }
        }
    }
}
