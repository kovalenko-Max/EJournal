using EJournalBLL.Models;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using Moq;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace EJournalBLL.Tests
{
    class ProjectServiceTests
    {

        private Mock<IProjectRepository> _mock;
        private ProjectService _projectService;

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<IProjectRepository>();
            _projectService = new ProjectService(_mock.Object);
        }

        [TestCaseSource(typeof(GetAlProjectSource))]
        public void GetAllProject_WhenProjectService_ShouldReturnAllProjects(List<ProjectDTO> RepositoryReturns, List<Project> expectedProject)
        {
            _mock.Setup(СoursesRepository => (
            СoursesRepository.GetProjects())).Returns(RepositoryReturns);

            List<Project> actualProject = _projectService.GetAllProjects();

            CollectionAssert.AreEqual(expectedProject, actualProject);
        }

        public class GetAlProjectSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                int startIdCourse = 1;
                int countCourses = 5;

                List<ProjectDTO> projectDTO = new List<ProjectDTO>();

                for (int i = startIdCourse; i <= countCourses; ++i)
                {
                    projectDTO.Add(BLLMock.GetProjectDTOMock(i));
                }

                List<Project> project = new List<Project>();

                for (int i = startIdCourse; i <= countCourses; ++i)
                {
                    project.Add(BLLMock.GetProjectMock(i));
                }
                yield return new object[]
                {
                    projectDTO,
                    project
                };

                 startIdCourse = 0;
                 countCourses = 0;

                 projectDTO = new List<ProjectDTO>();

                for (int i = startIdCourse; i <= countCourses; ++i)
                {
                    projectDTO.Add(BLLMock.GetProjectDTOMock(i));
                }

                 project = new List<Project>();

                for (int i = startIdCourse; i <= countCourses; ++i)
                {
                    project.Add(BLLMock.GetProjectMock(i));
                }

                yield return new object[]
                {
                    projectDTO,
                    project
                };

                projectDTO = null;
                project = new List<Project>();

                yield return new object[]
                {
                    projectDTO,
                    project
                };
            }
        }
    }
}
