using System.Collections.Generic;
using EJournalBLL.Models;
using EJournalDAL.Repository;
using EJournalDAL.Models.BaseModels;
using System.Data;

namespace EJournalBLL.Services
{
    public class LessonsService
    {
        public string ConnectionString { get; set; }
        public List<Lesson> Lessons { get; set; }

        public LessonsService(string connectionString)
        {
            ConnectionString = connectionString;
            Lessons = new List<Lesson>();
        }

        public void AddLesson(Lesson lesson)
        {
            LessonsRepository lessonsRepository = new LessonsRepository(ConnectionString);

            DataTable dt = new DataTable();
            dt.Columns.Add("LessonsIds");
            dt.Columns.Add("StudentId");
            dt.Columns.Add("isPresense");

            foreach (var a in lesson.Attendances)
            {
                dt.Rows.Add(new object[] {null, a.Student.Id, a.isPresent ? 1 : 0 });
            }


            lessonsRepository.AddLesson(ObjectMapper.Mapper.Map<LessonDTO>(lesson), dt);
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
