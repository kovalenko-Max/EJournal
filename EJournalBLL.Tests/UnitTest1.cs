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

    }
}