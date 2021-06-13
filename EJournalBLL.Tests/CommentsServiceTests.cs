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
    class CommentsServiceTests
    {
        private Mock<ICommentRepository> _mock;
        private CommentsService _commentsService;

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<ICommentRepository>();
            _commentsService = new CommentsService(_mock.Object);
        }

        [TestCaseSource(typeof(GetAlProjectSource))]
        public void GetAllCommentsByStudents_WhenCommentsService_ShouldReturnAllStudentComments(int idStudent, List<CommentDTO> RepositoryReturns, List<Comment> expectedProject)
        {
            _mock.Setup(CommentsRepository => (
            CommentsRepository.GetCommentsByStudent(idStudent))).Returns(RepositoryReturns);

            List<Comment> actualProject = _commentsService.GetCommentsByStudent(idStudent);

            CollectionAssert.AreEqual(expectedProject, actualProject);
        }

        public class GetAlProjectSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                int startIdComment = 1;
                int countComments = 5;

                List<CommentDTO> commentDTO = new List<CommentDTO>();

                for (int i = startIdComment; i <= countComments; ++i)
                {
                    commentDTO.Add(BLLMock.GetCommentDTOMock(i));
                }

                List<Comment> comment = new List<Comment>();

                for (int i = startIdComment; i <= countComments; ++i)
                {
                    comment.Add(BLLMock.GetCommenMock(i));
                }
                yield return new object[]
                {
                    2,
                    commentDTO,
                    comment
                };

                startIdComment = 0;
                countComments = 0;

                commentDTO = new List<CommentDTO>();

                for (int i = startIdComment; i <= countComments; ++i)
                {
                    commentDTO.Add(BLLMock.GetCommentDTOMock(i));
                }

                comment = new List<Comment>();

                for (int i = startIdComment; i <= countComments; ++i)
                {
                    comment.Add(BLLMock.GetCommenMock(i));
                }

                yield return new object[]
                {
                    5,
                    commentDTO,
                    comment
                };

                commentDTO = null;
                comment = new List<Comment>();

                yield return new object[]
                {
                    0,
                    commentDTO,
                    comment
                };
            }
        }
    }
}
