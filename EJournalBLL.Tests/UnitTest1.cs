using EJournalDAL.Repository;
using EJournalDAL.Models.BaseModels;
using NUnit.Framework;
using System.Collections.Generic;
using EJournalBLL.Models;

namespace EJournalBLL.Tests
{
    public class Tests
    {
        StudentsRepository studentsRepository;
        
        [SetUp]
        public void Setup()
        {
            studentsRepository = new StudentsRepository();
        }

        [Test]
        public void StudentDTO_WhenMapToStudent_ShouldMapCorrectly()
        {
            var studentDTO = new StudentDTO
            {
                Name = "A",
                AgreementNumber = "S",
                City = "Q",
                Email = "A@com",
                Git = "git",
                Id = 1,
                Phone = "1111",
                Ranking = 99,
                Surname = "aa",
                IsDelete = true,
                comments = new List<CommentDTO>
                {
                    new CommentDTO
                    {
                        Id = 1,
                        Comment = "comment",
                        IdCommentType = 1,
                        IdTeacher = 2,
                        IsDelete = false
                    }
                }
            };

            var result = ObjectMapper.Mapper.Map<Student>(studentDTO);

            Assert.AreEqual(studentDTO.Git, result.Git);
            Assert.AreEqual(studentDTO.Id, result.Id);
            Assert.AreEqual(studentDTO.Name, result.Name);
            Assert.AreEqual(studentDTO.Surname, result.Surname);
            Assert.AreEqual(studentDTO.Phone, result.Phone);
            Assert.AreEqual(studentDTO.Email, result.Email);
            Assert.AreEqual(studentDTO.City, result.City);
            Assert.AreEqual(studentDTO.AgreementNumber, result.AgreementNumber);
            Assert.AreEqual(studentDTO.IsDelete, result.IsDelete);
            Assert.AreEqual(studentDTO.comments.Count, result.comments.Count);
        }

        [TestCaseSource(nameof(DataExpectedCollection))]
        public void GetAllStudent_WhenAddSomeStudents_ShouldAddStudent(List<StudentDTO> expected)
        {
            var allStudents = studentsRepository.GetStudents();

            CollectionAssert.AreEqual(expected, allStudents);
        }
        private static IEnumerable<object[]> DataExpectedCollection()
        {
            yield return new object[] { new List<StudentDTO>()
            {
                {new StudentDTO(){Id=1, Name="Orla",  Surname="Randolph" , Email="dui.Fusce.diam@eu.com", Phone="1-429-359-0007", Git="hendrerit neque.", City="San Diego", Ranking=12, AgreementNumber="79525", IsDelete=false} },
                {new StudentDTO(){Id=2, Name="Sade",  Surname="Logan" , Email="Mauris.vestibulum@odiotristiquepharetra.org", Phone="1-844-138-6471", Git="vitae sodales", City="Szczecin", Ranking=79, AgreementNumber="93545", IsDelete=true} },
                {new StudentDTO(){Id=3, Name="Orson",  Surname="Wall" , Email="Cras.vulputate@egestasSedpharetra.org", Phone="1-522-559-4984", Git="eu, accumsan", City="Calais", Ranking=20, AgreementNumber="76734", IsDelete=true} }

            }
            };
        }
    }
}