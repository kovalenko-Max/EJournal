using EJournalBLL.Models;
using EJournalBLL.Services;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalBLL.Tests
{
    public class GroupServiceTests
    {

        private Mock<IGroupRepository> _mock;
        private GroupsService _groupService;

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<IGroupRepository>();
            _groupService = new GroupsService(_mock.Object);
        }

        [TestCaseSource(typeof(GetAllGroups))]
        public void GetAllProject_WhenProjectService_ShouldReturnAllProjects(List<GroupDTO> RepositoryReturns, List<Group> expectedGroups)
        {
            _mock.Setup(СoursesRepository => (
            СoursesRepository.GetAllGroups())).Returns(RepositoryReturns);

            List<Group> actualProject = _groupService.GetAllGroups();

            CollectionAssert.AreEqual(expectedGroups, actualProject);
        }

        public class GetAllGroups : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                int startIdCourse = 1;
                int countCourses = 5;

                List<GroupDTO> grouptDTO = new List<GroupDTO>();

                for (int i = startIdCourse; i <= countCourses; ++i)
                {
                    grouptDTO.Add(BLLMock.GetGroupDTOMock(i));
                }

                List<Group> group = new List<Group>();

                for (int i = startIdCourse; i <= countCourses; ++i)
                {
                    group.Add(BLLMock.GetGroupMock(i));
                }
                yield return new object[]
                {
                    grouptDTO,
                    group
                };

                startIdCourse = 0;
                countCourses = 0;

                grouptDTO = new List<GroupDTO>();

                for (int i = startIdCourse; i <= countCourses; ++i)
                {
                    grouptDTO.Add(BLLMock.GetGroupDTOMock(i));
                }

                group = new List<Group>();

                for (int i = startIdCourse; i <= countCourses; ++i)
                {
                    group.Add(BLLMock.GetGroupMock(i));
                }

                yield return new object[]
                {
                    grouptDTO,
                    group
                };

                grouptDTO = null;
                group = new List<Group>();

                yield return new object[]
                {
                    grouptDTO,
                    group
                };
            }
        }
    }
}
