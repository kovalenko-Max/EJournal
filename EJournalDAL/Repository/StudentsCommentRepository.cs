using Dapper;
using EJournalDAL.Models;
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
    public class StudentsCommentRepository
    {
        private string _connectionString;

        public StudentsCommentRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString;
        }

        public void AddCommentsToStudents(CommentDTO commentDTO, DataTable dt)
        {
            string command = "[EJournal].[CreateStudentComments]";

            var parameters = new DynamicParameters();
            parameters.Add("@IdCommentType", commentDTO.IdCommentType);
            parameters.Add("@Comment", commentDTO.Comment);
            parameters.Add("@StudentCommentVarible", dt.AsTableValuedParameter("[EJournal].[StudentsComment]"));

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(command, parameters, commandType: CommandType.StoredProcedure);
            }

            
        }
    }
}
