using EJournalDAL.Models.BaseModels;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EJournalDAL.Repository
{
    public class AttendanceRepository
    {
        string connectionString;
        public AttendanceRepository()
        {
            connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=EJournalDB; Integrated Security=True;";
        }

        public List<AttendanceDTO> GetAllAttendance()
        {
            List<AttendanceDTO> attendances = new List<AttendanceDTO>();

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec [CreateAttendence]";
                 db.Query<LessonDTO, AttendanceDTO, StudentDTO, AttendanceDTO>(connectionQuery,
                    (lesson, attendance, student) =>
                    {
                        AttendanceDTO crntAttendance = null;
                        foreach (var a in attendances)
                        {
                            if (lesson.Id == a.IdLesson && student.Id == a.IdStudent)
                            {
                                crntAttendance = a;
                                break;
                            }
                        }
                        if (crntAttendance is null)
                        {
                            crntAttendance = attendance;
                            attendances.Add(attendance);
                            crntAttendance.lesson = new List<LessonDTO>();
                            crntAttendance.students = new List<StudentDTO>();
                        }

                        if (lesson != null && student != null)
                        {
                            crntAttendance.lesson.Add(lesson);
                            crntAttendance.students.Add(student);
                        }
                        return crntAttendance;
                    },
                    splitOn: "IdLesson, IsPresence, Name"
                );
            }
            return attendances;
        }
    }
}
