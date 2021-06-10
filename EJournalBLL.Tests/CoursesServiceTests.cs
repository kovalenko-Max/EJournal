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

namespace EJournalBLL.Tests
{
    class CoursesServiceTests
    {
        private Mock<ICoursesRepository> _mock;
        private CoursesService _courseService;

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<ICoursesRepository>();
            _courseService = new CoursesService(_mock.Object);
        }

        [TestCaseSource(typeof(GetAllCourseSource))]
        public void GetAllCourses_WhenCourseService_ShouldReturnAllCourses(List<CourseDTO> RepositoryReturns, List<Course> expectedCourses)
        {
            _mock.Setup(СoursesRepository => (
            СoursesRepository.GetAllCourses())).Returns(RepositoryReturns);

            List<Course> actualLessons = _courseService.GetAllCourses();

            Assert.AreEqual(expectedCourses, actualLessons);
        }

        [TestCase(1, 5, true)]
        [TestCase(2, 2, true)]
        [TestCase(9, 1, true)]
        [TestCase(3, 0, false)]
        public void IsGroupsContainsThisCourse_WhenCourse_ShouldReturnBool(int IdCourse, int RepositoryReturns, bool expected)
        {
            _mock.Setup(СoursesRepository => (
            СoursesRepository.CountGroupsByCourse(IdCourse))).Returns(RepositoryReturns);
            Course course = BLLMock.GetCourseMock(IdCourse);

            bool actual = _courseService.IsGroupsContainsThisCourse(course);

            Assert.AreEqual(expected, actual);
        }

        public class GetAllCourseSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                int startIdCourse = 1;
                int countCourses = 5;

                List<CourseDTO> coursesDTO = new List<CourseDTO>();

                for (int i = startIdCourse; i <= countCourses; ++i)
                {
                    coursesDTO.Add(BLLMock.GetCourseDTOMock(i));
                }

                List<Course> courses = new List<Course>();

                for(int i = startIdCourse; i<= countCourses; ++i)
                {
                    courses.Add(BLLMock.GetCourseMock(i));
                }

                yield return new object[]
                {
                    coursesDTO,
                    courses
                };

                coursesDTO = new List<CourseDTO>();
                courses = new List<Course>();

                yield return new object[]
                {
                    coursesDTO,
                    courses
                };

                startIdCourse = 1;
                countCourses = 1;

                coursesDTO = new List<CourseDTO>();

                for (int i = startIdCourse; i <= countCourses; ++i)
                {
                    coursesDTO.Add(BLLMock.GetCourseDTOMock(i));
                }

                courses = new List<Course>();

                for (int i = startIdCourse; i <= countCourses; ++i)
                {
                    courses.Add(BLLMock.GetCourseMock(i));
                }

                yield return new object[]
                {
                    coursesDTO,
                    courses
                };
            }
        }
    }
}
