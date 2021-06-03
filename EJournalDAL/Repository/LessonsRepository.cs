using Dapper;
using EJournalDAL.Models;
using EJournalDAL.Models.BaseModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EJournalDAL.Repository
{
    public class LessonsRepository
    {
        public string ConnectionString;

        public LessonsRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<LessonDTO> GetLessonsAttendancesByGroup(int groupId)
        {
            string qr = "exec GetLessonsAttendancesByGroup @GroupId";

            List<LessonDTO> lessonsDTO = new List<LessonDTO>();

            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
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

        public void UpdateLessonAttendances(DataTable dt)
        {
            string command = "exec UpdateLessonAttendances @LessonsIds";
            List<LessonDTO> lessonDTO;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(command, new { LessonsIds = dt.AsTableValuedParameter("[dbo].[LessonsIds]") });
            }
        }
    }
}
