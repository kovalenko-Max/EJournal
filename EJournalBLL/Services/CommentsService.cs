using EJournalBLL.Models;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using System.Collections.Generic;
using System.Data;

namespace EJournalBLL.Services
{
    public class CommentsService
    {
        public List<Comment> Comments { get; set; }

        string ConnectionString { get; set; }

        private DataTable _studentsComment;

        public ICommentRepository CommentRepository { get; set; }

        public CommentsService()
        {
            CommentRepository = new CommentRepository();
            _studentsComment = new DataTable();
            _studentsComment.Columns.Add("IdStudent");
            _studentsComment.Columns.Add("IdComment");
        }
        public CommentsService(ICommentRepository commentRepository)
        {
            CommentRepository = commentRepository;
        }

        public List<Comment> GetCommentsByStudent(int id)
        {
            List<CommentDTO> commentsDTO = CommentRepository.GetCommentsByStudent(id);

            return Comments = ObjectMapper.Mapper.Map<List<Comment>>(commentsDTO);
        }

        public void AddComment(Comment comment, Student student)
        {
            comment.Id = CommentRepository.AddComment(ObjectMapper.Mapper.Map<CommentDTO>(comment), student.Id);
        }

        public void UpdateComment(Comment comment)
        {
            CommentDTO commentDTO = ObjectMapper.Mapper.Map<CommentDTO>(comment);
            CommentRepository.UpdateComment(commentDTO);
        }

        public void AddCommentsToStudent(Comment comments, List<Student> students)
        {
            _studentsComment.Clear();

            foreach (var a in students)
            {
                _studentsComment.Rows.Add(new object[] { a.Id, null });
            }

            CommentDTO commentDTO = ObjectMapper.Mapper.Map<CommentDTO>(comments);

            CommentRepository.AddCommentsToStudents(commentDTO, _studentsComment);
        }

        public void DeleteComment(Comment comment)
        {
            CommentRepository.DeleteComment(comment.Id);
        }
    }
}
