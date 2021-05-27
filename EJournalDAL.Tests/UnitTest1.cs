using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using NUnit.Framework;
using System.Collections.Generic;

namespace EJournalDAL.Tests
{
    public class Tests
    {
        StudentsRepository studentsRepository;
        [SetUp]
        public void Setup()
        {
            studentsRepository = new StudentsRepository();
        }

        [TestCaseSource(nameof(ExpectedStudentList))]

        public void GetStudents_WhenListNotNull_ShouldShowAllStudents(List<StudentDTO> expected)
        {
            var actual = studentsRepository.GetStudents();
            CollectionAssert.AreEqual(expected, actual);
        }

        private static IEnumerable<object[]> ExpectedStudentList()
        {
            yield return new object[] { new List< StudentDTO>()
            {
                    {new StudentDTO(){ Id=1, Name ="Orla", Surname="Randolph", Email="dui.Fusce.diam@eu.com", Phone="1-429-359-0007", Git= "hendrerit neque.", City="San Diego",Ranking=12, AgreementNumber="79525", IsDelete= true  } },
                    {new StudentDTO(){ Id=2, Name ="Sade", Surname="Logan", Email="Mauris.vestibulum@odiotristiquepharetra.org", Phone="1-844-138-6471", Git= "vitae sodales", City="Szczecin",Ranking=79, AgreementNumber="93545", IsDelete= false  } },
                    {new StudentDTO(){ Id=3, Name ="Orson", Surname="Wall", Email="Cras.vulputate@egestasSedpharetra.org", Phone="1-522-559-4984", Git= "eu, accumsan", City="Calais",Ranking=20, AgreementNumber="93545", IsDelete= false  } }
            }
            };
        }
    }
}