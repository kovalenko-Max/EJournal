using System.Collections.Generic;
using EJournalBLL.Models;
using EJournalDAL.Repository;
using EJournalDAL.Models;
using EJournalDAL.Models.BaseModels;
using System.ComponentModel;
using System.Data;

namespace EJournalBLL.Logics
{
    public class LessonsLogic
    {
        public string ConnectionString;

        public List<Lesson> Lessons;

        public LessonsLogic(string connectionString)
        {
            ConnectionString = connectionString;
            Lessons = new List<Lesson>();
        }

        public List<Lesson> GetLessonsAttendancesByGroup(Group group)
        {
            LessonsRepository lessonsRepository = new LessonsRepository(ConnectionString);
            List<LessonDTO> lessonsDTO = lessonsRepository.GetLessonsAttendancesByGroup(group.Id);

            Lessons = ConvertLessonsDTOToLessons(lessonsDTO);
            group.Lessons = Lessons;

            return Lessons;
        }

        public void UpdateLessonAttendances(Lesson lesson)
        {
            LessonsRepository lessonsRepository = new LessonsRepository(ConnectionString);
            DataTable dt = new DataTable();
            dt.Columns.Add("LessonsIds");
            dt.Columns.Add("StudentId");
            dt.Columns.Add("isPresense");

            foreach(var a in lesson.Attendances)
            {
                dt.Rows.Add( new object[] {lesson.Id, a.Student.Id, a.isPresent });
            }

            lessonsRepository.UpdateLessonAttendances(dt);
        }

        private List<Lesson> ConvertLessonsDTOToLessons(List<LessonDTO> lessonsDTO)
        {
            List<Lesson> lessons = new List<Lesson>();

            foreach(LessonDTO lessonDTO in lessonsDTO)
            {
                lessons.Add(new Lesson(lessonDTO) 
                {
                    Attendances = Attendances.GetAttendancesFromStudentAttendanceDTO(lessonDTO.StudentAttendanceDTO) 
                });
            }

            return lessons;
        }
    }
}
