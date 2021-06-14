using EJournalBLL.Models;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using Moq;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace EJournalBLL.Tests
{
    class ProjectGroupServiceTests
    {

        private Mock<IProjectGroupRepository> _mock;
        private ProjectGroupSevice _projectService;

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<IProjectGroupRepository>();
            _projectService = new ProjectGroupSevice(_mock.Object);
        }

        [TestCaseSource(typeof(GetAlProjectSource))]
        public void GetAllProjectGroup_WhenProjectService_ShouldReturnAllProjects(int IdProject, List<ProjectGroupDTO> RepositoryReturns, List<ProjectGroup> expectedProjectGroup)
        {
            _mock.Setup(СoursesRepository => (
            СoursesRepository.GetAllProjectGroups(IdProject))).Returns(RepositoryReturns);

            List<ProjectGroup> actualProject = _projectService.GetProjectGroups(IdProject);

            CollectionAssert.AreEqual(expectedProjectGroup, actualProject);
        }

        private class GetAlProjectSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                int startIdProjectGroup = 1;
                int countProjectGroup = 5;

                List<ProjectGroupDTO> projectGroupDTO = new List<ProjectGroupDTO>();

                for (int i = startIdProjectGroup; i <= countProjectGroup; ++i)
                {
                    projectGroupDTO.Add(BLLMock.GetProjectGroupDTOMock(i));
                }

                List<ProjectGroup> project = new List<ProjectGroup>();

                for (int i = startIdProjectGroup; i <= countProjectGroup; ++i)
                {
                    project.Add(BLLMock.GetProjectGroupeMock(i));
                }
                yield return new object[]
                {
                    3,
                    projectGroupDTO,
                    project
                };

                startIdProjectGroup = 6;
                countProjectGroup = 12;

                projectGroupDTO = new List<ProjectGroupDTO>();

                for (int i = startIdProjectGroup; i <= countProjectGroup; ++i)
                {
                    projectGroupDTO.Add(BLLMock.GetProjectGroupDTOMock(i));
                }

                project = new List<ProjectGroup>();

                for (int i = startIdProjectGroup; i <= countProjectGroup; ++i)
                {
                    project.Add(BLLMock.GetProjectGroupeMock(i));
                }
                yield return new object[]
                {
                    3,
                    projectGroupDTO,
                    project
                };
            }
        }
    }
}

