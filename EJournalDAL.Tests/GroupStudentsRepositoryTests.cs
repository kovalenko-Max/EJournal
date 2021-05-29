using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace EJournalDAL.Tests
{
    class GroupStudentsRepositoryTests
    {
        public string ConnectionString;
        GroupStudentsRepository GroupStudentsRepository;

        [SetUp]
        public void Setup()
        {
            ConnectionString = @"Data Source=DESKTOP-JJ674ET;Initial Catalog=StudentsFeedback;Integrated Security=True";

            GroupStudentsRepository = new GroupStudentsRepository(ConnectionString);
        }

        [TestCaseSource(typeof(GroupStudentsRepositorySource))]
        public void GetGetGroupDTO_WhenID_ShouldReturnGroupDTO(int id, GroupStudentsDTO expectedGroupStudentsDTO)
        {
            GroupStudentsDTO actualGroupDTO = GroupStudentsRepository.GetGroupAndStudentsInIt(id);
            Assert.AreEqual(expectedGroupStudentsDTO, actualGroupDTO);
        }
    }

    public class GroupStudentsRepositorySource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            GroupStudentsDTO groupDTO = new GroupStudentsDTO();
            groupDTO.IdGroup = 1;
            groupDTO.students = new List<StudentDTO>()
            {
                new StudentDTO(){Id = 1, Name = "Reed", Surname = "Vazquez", Email="venenatis.vel@imperdiet.org", Phone="04 55 78 13 79", Git="https://github.com/Chan", AgreementNumber="P2F 6W2"},
                new StudentDTO(){ Id = 2, Name = "Declan", Surname = "Jarvis", Email = "Suspendisse.aliquet.molestie@auctornonfeugiat.com", Phone="03 78 01 60 46", Git="https://github.com/Lawrence",AgreementNumber="C8S 5C4" },
                new StudentDTO(){ Id = 3, Name = "Calvin", Surname="Webster",Email="est.congue@augue.edu", Phone = "01 48 50 90 57", Git="https://github.com/Brennan", AgreementNumber="W6Y 7K3"},
                new StudentDTO(){ Id = 4, Name = "Shay", Surname="Ferrell", Email="Sed@Nullamsuscipit.com", Phone="03 02 96 39 96", Git="https://github.com/Hale",AgreementNumber="I6X 4O9"},
                new StudentDTO(){ Id = 5, Name = "Rudyard", Surname="Adkins", Email="mattis.velit.justo@idrisusquis.org", Phone = "04 17 03 18 78", Git="https://github.com/Harrell", AgreementNumber="U0V 0Q2"}
            };

            yield return new object[]
            {
                groupDTO.IdGroup,
                groupDTO
            };
        }
    }
}
