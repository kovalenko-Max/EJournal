using EJournalBLL.Models;
using EJournalBLL.Services;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using Moq;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace EJournalBLL.Tests
{
    class StudentServiseTests
    {
        private Mock<IStudentsRepository> _mock;
        private StudentService _studentService;

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<IStudentsRepository>();
            _studentService = new StudentService(_mock.Object);
        }

        [TestCaseSource(typeof(GetAllStudents))]
        public void GetAllStudent_WhenStudentService_ShouldReturnAllStudents(List<StudentDTO> RepositoryReturns, List<Student> expectedStudents)
        {
            _mock.Setup(СoursesRepository => (
            СoursesRepository.GetAll())).Returns(RepositoryReturns);

            List<Student> actualStudent = _studentService.GetAllStudent();

            CollectionAssert.AreEqual(expectedStudents, actualStudent);
        }

        [TestCaseSource(typeof(GetStudentsFromGroupOrProjectGroup))]
        public void GetStudentdsFromProjectGroup_WhenStudentService_ShouldReturnAllStudents(int IdProjectGroup, List<StudentDTO> RepositoryReturns, List<Student> expectedStudents)
        {
            _mock.Setup(СoursesRepository => (
            СoursesRepository.GetStudentsFromOneProjectGroup(IdProjectGroup))).Returns(RepositoryReturns);

            List<Student> actualStudent = _studentService.GetStudentsFromProjectGroups(IdProjectGroup);

            CollectionAssert.AreEqual(expectedStudents, actualStudent);
        }

        [TestCaseSource(typeof(GetStudentsFromGroupOrProjectGroup))]
        public void GetStudentdsFromGroup_WhenStudentService_ShouldReturnAllStudents(int IdGroup, List<StudentDTO> RepositoryReturns, List<Student> expectedStudents)
        {
            _mock.Setup(СoursesRepository => (
            СoursesRepository.GetStudentsByGroup(IdGroup))).Returns(RepositoryReturns);

            List<Student> actualStudent = _studentService.GetStudentsByGroup(IdGroup);

            CollectionAssert.AreEqual(expectedStudents, actualStudent);
        }

        [TestCaseSource(typeof(GetStudentsFromGroupOrProjectGroup))]
        public void GetStudentdsWhoAreNotInProjectGroup_WhenStudentService_ShouldReturnAllStudents(int IdProjectGroup, List<StudentDTO> RepositoryReturns, List<Student> expectedStudents)
        {
            _mock.Setup(СoursesRepository => (
            СoursesRepository.GetStudentsNotAreInProjectGroup(IdProjectGroup))).Returns(RepositoryReturns);

            List<Student> actualStudent = _studentService.GetStudentsNotAreInProjectGroups(IdProjectGroup);

            CollectionAssert.AreEqual(expectedStudents, actualStudent);
        }

        [TestCaseSource(typeof(GetStudentsFromGroupOrProjectGroup))]
        public void GetStudentdWhoAreNotInGroup_WhenStudentService_ShouldReturnAllStudents(int IdGroup, List<StudentDTO> RepositoryReturns, List<Student> expectedStudents)
        {
            _mock.Setup(СoursesRepository => (
            СoursesRepository.GetStudentsNotAreInGroup(IdGroup))).Returns(RepositoryReturns);

            List<Student> actualStudent = _studentService.GetStudentsNotAreInGroup(IdGroup);

            CollectionAssert.AreEqual(expectedStudents, actualStudent);
        }

        private class GetAllStudents : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                int startIdStudent = 1;
                int countStudents = 5;

                List<StudentDTO> studentDTO = new List<StudentDTO>();

                for (int i = startIdStudent; i <= countStudents; ++i)
                {
                    studentDTO.Add(BLLMock.GetStudentDTOMock(i));
                }

                List<Student> student = new List<Student>();

                for (int i = startIdStudent; i <= countStudents; ++i)
                {
                    student.Add(BLLMock.GetStudentMock(i));
                }
                yield return new object[]
                {
                    studentDTO,
                    student
                };

                startIdStudent = 6;
                countStudents = 12;

                studentDTO = new List<StudentDTO>();

                for (int i = startIdStudent; i <= countStudents; ++i)
                {
                    studentDTO.Add(BLLMock.GetStudentDTOMock(i));
                }

                student = new List<Student>();

                for (int i = startIdStudent; i <= countStudents; ++i)
                {
                    student.Add(BLLMock.GetStudentMock(i));
                }
                yield return new object[]
                {
                    studentDTO,
                    student
                };

                startIdStudent = 15;
                countStudents = 25;

                studentDTO = new List<StudentDTO>();

                for (int i = startIdStudent; i <= countStudents; ++i)
                {
                    studentDTO.Add(BLLMock.GetStudentDTOMock(i));
                }

                student = new List<Student>();

                for (int i = startIdStudent; i <= countStudents; ++i)
                {
                    student.Add(BLLMock.GetStudentMock(i));
                }
                yield return new object[]
                {
                    studentDTO,
                    student
                };
            }



        }
     
        private class GetStudentsFromGroupOrProjectGroup : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                int startIdStudent = 1;
                int countStudents = 5;

                List<StudentDTO> studentDTO = new List<StudentDTO>();

                for (int i = startIdStudent; i <= countStudents; ++i)
                {
                    studentDTO.Add(BLLMock.GetStudentDTOMock(i));
                }

                List<Student> student = new List<Student>();

                for (int i = startIdStudent; i <= countStudents; ++i)
                {
                    student.Add(BLLMock.GetStudentMock(i));
                }
                yield return new object[]
                {
                    3,
                    studentDTO,
                    student
                };

                startIdStudent = 0;
                countStudents = 0;

                studentDTO = new List<StudentDTO>();

                for (int i = startIdStudent; i <= countStudents; ++i)
                {
                    studentDTO.Add(BLLMock.GetStudentDTOMock(i));
                }

                student = new List<Student>();

                for (int i = startIdStudent; i <= countStudents; ++i)
                {
                    student.Add(BLLMock.GetStudentMock(i));
                }
                yield return new object[]
                {
                    4,
                    studentDTO,
                    student
                };

                studentDTO = null;
                student = new List<Student>();

                yield return new object[]
                {
                    5,
                    studentDTO,
                    student
                };
            }
        }
    }
}
