using EJournalBLL.Models;
using EJournalBLL.Services;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using EJournalDAL.Models;
using Moq;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Configuration;

namespace EJournalBLL.Tests
{
    class LessonsServiceTests
    {
        private Mock<ILessonsAttendancesRepository> _mock;
        private LessonsService _lessonService;

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<ILessonsAttendancesRepository>();
            _lessonService = new LessonsService(_mock.Object);
        }

        [TestCaseSource(typeof(LessonsServiceTestsSource))]
        public void GetLessonsAttendancesByGroup_WhenLessonGroup_ShouldReturnLestLessons(
            Group group, List<LessonDTO> GetLessonsAttendancesByGroupReturns, List<Lesson> expectedLessons)
        {
            _mock.Setup(LessonsAttendancesRepository => (
            LessonsAttendancesRepository.GetLessonsAttendancesByGroup(group.Id))).Returns(GetLessonsAttendancesByGroupReturns);

            List<Lesson> actualLessons = _lessonService.GetLessonsAttendancesByGroup(group);

            Assert.AreEqual(expectedLessons, actualLessons);
        }
    }

    public class LessonsServiceTestsSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int iDGroup = 1;
            int startStudentsId = 1;
            int studentsCount = 5;
            int idCourse = 1;

            int startLessonId = 1;
            int LessonsCount = 4;

            Group group = new Group($"Test group {iDGroup}", GetCourseMock(idCourse));
            group.Id = iDGroup;

            List<LessonDTO> lessonsDTO = new List<LessonDTO>();

            for (int i = startLessonId; i <= LessonsCount; ++i)
            {
                lessonsDTO.Add(GetLessonDTOMock(i, iDGroup, startStudentsId, studentsCount));
            }

            List<Lesson> lessons = new List<Lesson>();
            for (int i = startLessonId; i <= LessonsCount; ++i)
            {
                lessons.Add(GetLesson(i, iDGroup, startStudentsId, studentsCount));
            }

            yield return new object[]
            {
                group,
                lessonsDTO,
                lessons
            };
        }

        private LessonDTO GetLessonDTOMock(int iDLesson, int iDGroup, int StartStudentId, int studentsCount)
        {
            const int isPresence = 1;
            const int isNotPresence = 0;
            LessonDTO lessonDTO = new LessonDTO();
            lessonDTO.DateLesson = new DateTime(2021, 05, 21);
            lessonDTO.Id = iDLesson;
            lessonDTO.IdGroup = iDGroup;
            lessonDTO.IsDelete = false;
            lessonDTO.Topic = "Test topic 1";
            lessonDTO.StudentAttendanceDTO = new List<StudentAttendanceDTO>();

            while (StartStudentId <= studentsCount)
            {
                StudentAttendanceDTO studentAttendanceDTO = new StudentAttendanceDTO();

                studentAttendanceDTO.IdLesson = iDLesson;
                studentAttendanceDTO.IdStudent = StartStudentId;
                studentAttendanceDTO.IsPresence = 1;
                studentAttendanceDTO.Name = $"Name {StartStudentId}";
                studentAttendanceDTO.Surname = $"Surname {StartStudentId}";
                lessonDTO.StudentAttendanceDTO.Add(studentAttendanceDTO);
                ++StartStudentId;
            }

            return lessonDTO;
        }

        private Lesson GetLesson(int iDLesson, int iDGroup, int StartStudentId, int studentsCount)
        {
            Lesson lesson = new Lesson();
            lesson.DateLesson = new DateTime(2021, 05, 21);
            lesson.Id = iDLesson;
            lesson.IdGroup = iDGroup;
            lesson.Topic = $"Test topic {iDLesson}";
            lesson.Attendances = new List<Attendances>();

            while (StartStudentId <= studentsCount)
            {
                Attendances attendance = new Attendances(GetStudent(StartStudentId));
                attendance.isPresent = true;
                lesson.Attendances.Add(attendance);
                ++StartStudentId;
            }

            return lesson;
        }

        private Student GetStudent(int idStudent)
        {
            return new Student($"Name {idStudent}", $"Surname {idStudent}");
        }

        private Course GetCourseMock(int iDcourse)
        {
            return new Course($"Course {iDcourse}")
            {
                Id = iDcourse
            };
        }
    }
}
