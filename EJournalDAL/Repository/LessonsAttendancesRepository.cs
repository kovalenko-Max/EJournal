using Dapper;
using EJournalDAL.Models;
using EJournalDAL.Models.BaseModels;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EJournalDAL.Repository
{
    public class LessonsAttendancesRepository : ILessonsAttendancesRepository
    {
        private string _connectionString;

        public LessonsAttendancesRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ConnectionString;
        }

        public int AddLessonAttendances(LessonDTO lessonDTO, DataTable dt)
        {
            string command = "[EJournal].[AddStudentsAttendance]";

            var parameters = new DynamicParameters();
            parameters.Add("@Topic", lessonDTO.Topic);
            parameters.Add("@DateLesson", lessonDTO.DateLesson);
            parameters.Add("@IdGroup", lessonDTO.IdGroup);
            parameters.Add("@StudentAttendanceVariable", dt.AsTableValuedParameter("[EJournal].[StudentAttendance]"));
            parameters.Add("@IdLesson", DbType.Int32, direction: ParameterDirection.ReturnValue);

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(command, parameters, commandType: CommandType.StoredProcedure);
            }

            return parameters.Get<int>("@IdLesson");
        }

        public List<LessonDTO> GetLessonsAttendancesByGroup(int groupId)
        {
            string qr = "exec [EJournal].[GetLessonsAttendancesByGroup] @GroupId";

            List<LessonDTO> lessonsDTO = new List<LessonDTO>();

            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Query<LessonDTO, StudentAttendanceDTO, LessonDTO>(qr,

                    (lesson, student) =>
                    {
                        LessonDTO currentLesson = null;
                        foreach (var lessonDTO in lessonsDTO)
                        {
                            if (lessonDTO.Id == lesson.Id)
                            {
                                currentLesson = lessonDTO;
                                break;
                            }
                        }
                        if (currentLesson is null)
                        {
                            currentLesson = lesson;
                            lessonsDTO.Add(lesson);
                            currentLesson.StudentAttendanceDTO = new List<StudentAttendanceDTO>();
                        }

                        if (student != null)
                        {
                            currentLesson.StudentAttendanceDTO.Add(student);
                        }

                        return currentLesson;
                    },
                    splitOn: "Id, IdStudent"
                    , param: new { groupId });
            }

            return lessonsDTO;
        }

        public void UpdateLessonsAttendances(LessonDTO lessonDTO, DataTable dt)
        {
            string command = "[EJournal].[UpdateLessonAttendances]";

            var parameters = new DynamicParameters();
            parameters.Add("@StudentAttendance", dt.AsTableValuedParameter("[EJournal].[StudentAttendance]"));
            parameters.Add("@Id", lessonDTO.Id);
            parameters.Add("@Topic", lessonDTO.Topic);
            parameters.Add("@DateLesson", lessonDTO.DateLesson);

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(command, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteLessonAndAttendances(int id)
        {
            string command = "exec [EJournal].[DeleteLessonAndAttendances] @Id";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(command, new { id });
            }
        }
    }
}