using EJournalDAL.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Configuration;

namespace EJournalDAL.Repository
{
    public class CommentRepository
    {
        private string _connectionString;

        public CommentRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString;
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
                string connectionQuery = "exec [EJournal].[UpdateComment] @Id, @Comment, @CommentType";
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
        public void AddCommentToProjectRepository(string comment, int idStudent)
        {
            string connectionQuery = " exec AddCommentToEachStudentFromProjectGroup @Comment, @IdStudent";
            
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(connectionQuery, new { comment, idStudent });
            }
        }

        public List<CommentDTO> GetCommentsByStudent(int IdStudent)
        {
            List<CommentDTO> commentsDTO = new List<CommentDTO>();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string connectionQuery = "exec [EJournal].[GetCommentsByStudent] @IdStudent";

                commentsDTO = db.Query<CommentDTO>(connectionQuery, new { IdStudent }).ToList();
            }

            return commentsDTO;
        }

        public void AddCommentsToStudents(CommentDTO commentDTO, DataTable dt)
        {
            string command = "[EJournal].[CreateStudentComments]";

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