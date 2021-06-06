using System.Collections.Generic;
using EJournalBLL.Models;
using EJournalDAL.Repository;
using EJournalDAL.Models.BaseModels;
using System.Data;

namespace EJournalBLL.Services
{
    public class LessonsService
    {
        private DataTable _studentAttendanceModel;
        public List<Lesson> Lessons { get; set; }

        public LessonsService(string connectionString)
        {
            ConnectionString = connectionString;
            Lessons = new List<Lesson>();
            _studentAttendanceModel = new DataTable();
            _studentAttendanceModel.Columns.Add("LessonsIds");
            _studentAttendanceModel.Columns.Add("StudentId");
            _studentAttendanceModel.Columns.Add("isPresense");
        }

        public void AddLesson(Lesson lesson)
        {
            LessonsAttendancesRepository lessonsRepository = new LessonsAttendancesRepository();
            _studentAttendanceModel.Clear();
            foreach (var a in lesson.Attendances)
            {
                _studentAttendanceModel.Rows.Add(new object[] { null, a.Student.Id, a.isPresent ? 1 : 0 });
            }

            lesson.Id = lessonsRepository.AddLessonAttendances(ObjectMapper.Mapper.Map<LessonDTO>(lesson), _studentAttendanceModel);
        }

        public List<Lesson> GetLessonsAttendancesByGroup(Group group)
        {
            LessonsAttendancesRepository lessonsRepository = new LessonsRepository(ConnectionString);
            List<LessonDTO> lessonsDTO = lessonsRepository.GetLessonsAttendancesByGroup(group.Id);

            Lessons = ConvertLessonsDTOToLessons(lessonsDTO);
            group.Lessons = Lessons;

            return Lessons;
        }

        public void UpdateLessonAttendances(Lesson lesson)
        {
            LessonsAttendancesRepository lessonsRepository = new LessonsRepository(ConnectionString);
            _studentAttendanceModel.Clear();
            foreach (var a in lesson.Attendances)
            {
                _studentAttendanceModel.Rows.Add(new object[] { lesson.Id, a.Student.Id, a.isPresent });
            }

            lessonsRepository.UpdateLessonsAttendances(ObjectMapper.Mapper.Map<LessonDTO>(lesson), _studentAttendanceModel);
        }

        public void DeleteLesson(Lesson lesson)
        {
            LessonsAttendancesRepository lessonsRepository = new LessonsAttendancesRepository();
            lessonsRepository.DeleteLessonAndAttendances(lesson.Id);
        }

        private List<Lesson> ConvertLessonsDTOToLessons(List<LessonDTO> lessonsDTO)
        {
            List<Lesson> lessons = new List<Lesson>();

            foreach (LessonDTO lessonDTO in lessonsDTO)
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
