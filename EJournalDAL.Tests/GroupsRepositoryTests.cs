using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace EJournalDAL.Tests
{
    public class GroupsRepositoryTests
    {
    //    public string ConnectionString;
    //    GroupsRepository GroupsRepository;
    //    [SetUp]
    //    public void Setup()
    //    {
    //        ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EJournalDB;"
    //    + "Integrated Security=true;";

    //        GroupsRepository = new GroupsRepository(ConnectionString);
    //    }

    //    [TestCase(1)]
    //    public void GetAllGroupsDTO_ShouldReturnAllGroups(int expectedMockNumb)
    //    {
    //        List<GroupDTO> expectedGroupsDTO = GroupsDTOMock.GetAllGroupsDTOMock(expectedMockNumb);
    //        List<GroupDTO> actualGroupsDTO = GroupsRepository.GetAllGroupsDTO();

    //        for (int i = 0; i < actualGroupsDTO.Count; ++i)
    //        {
    //            if (!actualGroupsDTO[i].Equals(expectedGroupsDTO[i]))
    //            {
    //                Assert.Fail();
    //                break;
    //            }
    //        }

    //        Assert.Pass();
    //    }

    //    [TestCaseSource(typeof(GroupsRepositorySource))]
    //    public void GetGetGroupDTO_WhenID_ShouldReturnGroupDTO(int id, GroupDTO expectedGroupDTO)
    //    {
    //        GroupsRepository groupsRepository = new GroupsRepository(ConnectionString);
    //        GroupDTO actualGroupDTO = GroupsRepository.GetGroupDTO(id);
    //        Assert.AreEqual(expectedGroupDTO, actualGroupDTO);
    //    }
    //}

    //public class GroupsRepositorySource : IEnumerable
    //{
    //    public IEnumerator GetEnumerator()
    //    {
    //        GroupDTO groupDTO = new GroupDTO();
    //        groupDTO.Id = 27;
    //        groupDTO.Name = "C#1";
    //        groupDTO.IdCourse = 8;
    //        groupDTO.IsFinish = 0;
    //        groupDTO.IsDelete = 0;

    //        yield return new object[]
    //        {
    //            groupDTO.Id,
    //            groupDTO
    //        };

    //        groupDTO = new GroupDTO();
    //        groupDTO.Id = 28;
    //        groupDTO.Name = "C#2";
    //        groupDTO.IdCourse = 8;
    //        groupDTO.IsFinish = 0;
    //        groupDTO.IsDelete = 0;

    //        yield return new object[]
    //        {
    //            groupDTO.Id,
    //            groupDTO
    //        };

    //        groupDTO = new GroupDTO();
    //        groupDTO.Id = 31;
    //        groupDTO.Name = "QA2";
    //        groupDTO.IdCourse = 10;
    //        groupDTO.IsFinish = 0;
    //        groupDTO.IsDelete = 0;

    //        yield return new object[]
    //        {
    //            groupDTO.Id,
    //            groupDTO
    //        };

    //        groupDTO = new GroupDTO();
    //        groupDTO.Id = 32;
    //        groupDTO.Name = "JAVA1";
    //        groupDTO.IdCourse = 9;
    //        groupDTO.IsFinish = 0;
    //        groupDTO.IsDelete = 0;

    //        yield return new object[]
    //        {
    //            groupDTO.Id,
    //            groupDTO
    //        };
    //    }
    //}

    //public static class GroupsDTOMock
    //{
    //    public static List<GroupDTO> GetAllGroupsDTOMock(int MockNumb)
    //    {
    //        List<GroupDTO> groupsDTO = new List<GroupDTO>();

    //        GroupDTO groupDTO = new GroupDTO();
    //        groupDTO.Id = 27;
    //        groupDTO.Name = "C#1";
    //        groupDTO.IdCourse = 8;
    //        groupDTO.IsFinish = 0;
    //        groupDTO.IsDelete = 0;
    //        groupsDTO.Add(groupDTO);

    //        groupDTO = new GroupDTO();
    //        groupDTO.Id = 28;
    //        groupDTO.Name = "C#2";
    //        groupDTO.IdCourse = 8;
    //        groupDTO.IsFinish = 0;
    //        groupDTO.IsDelete = 0;
    //        groupsDTO.Add(groupDTO);

    //        groupDTO = new GroupDTO();
    //        groupDTO.Id = 29;
    //        groupDTO.Name = "C#3";
    //        groupDTO.IdCourse = 8;
    //        groupDTO.IsFinish = 0;
    //        groupDTO.IsDelete = 0;
    //        groupsDTO.Add(groupDTO);

    //        groupDTO = new GroupDTO();
    //        groupDTO.Id = 30;
    //        groupDTO.Name = "QA1";
    //        groupDTO.IdCourse = 10;
    //        groupDTO.IsFinish = 0;
    //        groupDTO.IsDelete = 0;
    //        groupsDTO.Add(groupDTO);

    //        groupDTO = new GroupDTO();
    //        groupDTO.Id = 31;
    //        groupDTO.Name = "QA2";
    //        groupDTO.IdCourse = 10;
    //        groupDTO.IsFinish = 0;
    //        groupDTO.IsDelete = 0;
    //        groupsDTO.Add(groupDTO);

    //        groupDTO = new GroupDTO();
    //        groupDTO.Id = 32;
    //        groupDTO.Name = "JAVA1";
    //        groupDTO.IdCourse = 9;
    //        groupDTO.IsFinish = 0;
    //        groupDTO.IsDelete = 0;
    //        groupsDTO.Add(groupDTO);

    //        return groupsDTO;
    //    }
    }
}