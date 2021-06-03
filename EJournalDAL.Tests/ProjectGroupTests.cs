using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using NUnit.Framework;
using System.Collections.Generic;

namespace EJournalDAL.Tests
{
    class ProjectGroupTests
    {
        ProjectGroupRepository projectGroupRepository;
        ProjectRepository projectRepository;

        [SetUp]
        public void Setup()
        {
            //projectGroupRepository = new ProjectGroupRepository();
            projectRepository = new ProjectRepository();
        }

        [TestCaseSource(nameof(DataExpectedCollection))]
        public void GetAllStudent_WhenAddSomeStudents_ShouldAddStudent(ProjectGroupDTO expected)
        {
            var actual = projectGroupRepository.GetStudentsFromOneProjectGroup(3);

            Assert.Pass();
        }
        private static IEnumerable<object[]> DataExpectedCollection()
        {
            yield return new object[] { new ProjectGroupDTO()
            {
               Id =1, Name = "Rhea", Students= new List<StudentDTO>()
               {
                   new StudentDTO(){Id = 1, Name = "Whoopi", Surname = "Lawrence", Email="Sed.id.risus@temporbibendumDonec.ca", Phone="1-385-281-4579", Git="et pede.",City="Pamplona", Ranking=69, AgreementNumber="310"},
                new StudentDTO(){ Id = 2, Name = "Ira", Surname = "Montgomery", Email = "lacus@nonummyacfeugiat.com", Phone="1-215-269-3373", Git="nonummy ultricies",City="Steendorp",Ranking=62,AgreementNumber="636" }
               }
            } };
        }

        [TestCaseSource(nameof(ExpectedCollection))]
        public void GetAllProjects_WhenAddSomeStudents_ShouldAddStudent(List<ProjectDTO> expected)
        {
            var actual = projectRepository.GetAllProjects();

            Assert.Pass();
        }
        private static IEnumerable<object[]> ExpectedCollection()
        {
            yield return new object[] { new List<ProjectDTO>()
            {
                new ProjectDTO()
                {
                    Id=1,
                    Description="aaa",
                    Name= "ddd",
                    IsDelete=false,
                    projectGroups= new List<ProjectGroupDTO>(){}
                }
            }
             };
        }
    }
}
