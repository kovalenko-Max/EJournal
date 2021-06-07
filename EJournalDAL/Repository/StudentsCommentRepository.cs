using Dapper;
using EJournalDAL.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Repository
{
    class StudentsCommentRepository
    {
        private string _connectionString;

        public StudentsCommentRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString;
        }

        //public int AddLessonAttendances(StudentDTO studentDTO, DataTable dt)
        //{
        //    //string command = "CreateStudentComments";

        //    //var parameters = new DynamicParameters();
        //    //parameters.Add("@Topic", studentDTO.Topic);
        //    //parameters.Add("@DateLesson", lessonDTO.DateLesson);
        //    //parameters.Add("@IdGroup", lessonDTO.IdGroup);
        //    //parameters.Add("@StudentAttendanceVariable", dt.AsTableValuedParameter("[dbo].[StudentAttendance]"));
        //    //parameters.Add("@IdLesson", DbType.Int32, direction: ParameterDirection.ReturnValue);

        //    //using (IDbConnection db = new SqlConnection(_connectionString))
        //    //{
        //    //    db.Execute(command, parameters, commandType: CommandType.StoredProcedure);
        //    //}

        //    //return parameters.Get<int>("@IdLesson");
        //}
    }
}
