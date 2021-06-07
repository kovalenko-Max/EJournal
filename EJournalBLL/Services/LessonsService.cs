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

        public ILessonsAttendancesRepository LessonsAttendancesRepository { get; set; }
        public List<Lesson> Lessons { get; set; }

        public LessonsService(ILessonsAttendancesRepository lessonsAttendancesRepository)
        {
            LessonsAttendancesRepository = lessonsAttendancesRepository;
            Lessons = new List<Lesson>();

            _studentAttendanceModel = new DataTable();
            _studentAttendanceModel.Columns.Add("LessonsIds");
            _studentAttendanceModel.Columns.Add("StudentId");
            _studentAttendanceModel.Columns.Add("isPresense");
        }

        public void AddLesson(Lesson lesson)
        {
            _studentAttendanceModel.Clear();
            foreach (var a in lesson.Attendances)
            {
                _studentAttendanceModel.Rows.Add(new object[] { null, a.Student.Id, a.isPresent ? 1 : 0 });
            }

            lesson.Id = LessonsAttendancesRepository.AddLessonAttendances(ObjectMapper.Mapper.Map<LessonDTO>(lesson), _studentAttendanceModel);
        }

        public List<Lesson> GetLessonsAttendancesByGroup(Group group)
        {
            List<LessonDTO> lessonsDTO = LessonsAttendancesRepository.GetLessonsAttendancesByGroup(group.Id);

            Lessons = ConvertLessonsDTOToLessons(lessonsDTO);
            group.Lessons = Lessons;

            return Lessons;
        }

        public void UpdateLessonAttendances(Lesson lesson)
        {
            _studentAttendanceModel.Clear();

            foreach (var a in lesson.Attendances)
            {
                _studentAttendanceModel.Rows.Add(new object[] { lesson.Id, a.Student.Id, a.isPresent });
            }

            LessonsAttendancesRepository.UpdateLessonsAttendances(ObjectMapper.Mapper.Map<LessonDTO>(lesson), _studentAttendanceModel);
        }

        public void DeleteLesson(Lesson lesson)
        {
            LessonsAttendancesRepository.DeleteLessonAndAttendances(lesson.Id);
        }

        private List<Lesson> ConvertLessonsDTOToLessons(List<LessonDTO> lessonsDTO)
        {
            List<Lesson> lessons = new List<Lesson>();

            foreach (LessonDTO lessonDTO in lessonsDTO)
            {
                lessons.Add(new Lesson(lessonDTO)
                {
                    Id = lessonDTO.Id,
                    IdGroup = lessonDTO.IdGroup,
                    Attendances = Attendances.GetAttendancesFromStudentAttendanceDTO(lessonDTO.StudentAttendanceDTO)
                });
            }

            return lessons;
        }
    }
}
