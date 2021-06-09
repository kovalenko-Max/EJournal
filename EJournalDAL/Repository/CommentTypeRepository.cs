using Dapper;
using EJournalDAL.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Repository
{
    public class CommentTypeRepository
    {
        string connectionString;
        public CommentTypeRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ToString();
        }

        public List<CommentTypeDTO> GetAllCommentsType()
        {
            List<CommentTypeDTO> commentsType = new List<CommentTypeDTO>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec GetAllCommentTypes";
                commentsType = db.Query<CommentTypeDTO>(connectionQuery).ToList();
            }
            return commentsType;
        }

        public CommentTypeDTO GetCommentType(int id)
        {
            CommentTypeDTO commentType = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec GetCommentType @Id";
                commentType = db.Query<CommentTypeDTO>(connectionQuery, new { id }).FirstOrDefault();
            }
            return commentType;
        }

        public CommentTypeDTO CreateComment(CommentTypeDTO comment)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec AddCommentType @Type";
                int? commentId = db.Query<int>(connectionQuery, comment).FirstOrDefault();
                comment.Id = commentId;
            }
            return comment;
        }

        public void UpdateComment(CommentTypeDTO comment)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec UpdateCommentType @Id, @Type";
                db.Execute(connectionQuery, comment);
            }
        }

        public void DeleteComment(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = " exec DeleteCommentType @Id";
                db.Execute(connectionQuery, new { id });
            }
        }
      
    }
}
