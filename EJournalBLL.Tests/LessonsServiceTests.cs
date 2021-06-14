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
            LessonsAttendancesRepository.GetStudentsAttendancesByGroup(group.Id))).Returns(GetLessonsAttendancesByGroupReturns);

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

            Group group = new Group($"Test group {iDGroup}", BLLMock.GetCourseMock(idCourse));
            group.Id = iDGroup;

            List<LessonDTO> lessonsDTO = new List<LessonDTO>();

            for (int i = startLessonId; i <= LessonsCount; ++i)
            {
                lessonsDTO.Add(BLLMock.GetLessonDTOMock(i, iDGroup, startStudentsId, studentsCount));
            }

            List<Lesson> lessons = new List<Lesson>();
            for (int i = startLessonId; i <= LessonsCount; ++i)
            {
                lessons.Add(BLLMock.GetLesson(i, iDGroup, startStudentsId, studentsCount));
            }

            yield return new object[]
            {
                group,
                lessonsDTO,
                lessons
            };

            iDGroup = 9;
            startStudentsId = 25;
            studentsCount = 1;
            idCourse = 4;

            startLessonId = 1;
            LessonsCount = 4;

            group = new Group($"Test group {iDGroup}", BLLMock.GetCourseMock(idCourse));
            group.Id = iDGroup;

            lessonsDTO = new List<LessonDTO>();

            for (int i = startLessonId; i <= LessonsCount; ++i)
            {
                lessonsDTO.Add(BLLMock.GetLessonDTOMock(i, iDGroup, startStudentsId, studentsCount));
            }

            lessons = new List<Lesson>();
            for (int i = startLessonId; i <= LessonsCount; ++i)
            {
                lessons.Add(BLLMock.GetLesson(i, iDGroup, startStudentsId, studentsCount));
            }

            yield return new object[]
            {
                group,
                lessonsDTO,
                lessons
            };

            iDGroup = 99;
            idCourse = 2;

            group = new Group($"Test group {iDGroup}", BLLMock.GetCourseMock(idCourse));
            group.Id = iDGroup;

            lessonsDTO = new List<LessonDTO>();

            lessons = new List<Lesson>();

            yield return new object[]
            {
                group,
                lessonsDTO,
                lessons
            };
        }
    }
}
