using EJournalDAL.Repository;
using EJournalBLL.Models;
using EJournalDAL.Models.BaseModels;
using System.Data;

namespace EJournalBLL.Services
{
    public class CommentService
    {
        private DataTable _studentsComment;
        public StudentsCommentRepository CommentRepository { get; set; }

        public CommentService()
        {
            CommentRepository = new StudentsCommentRepository();
            _studentsComment = new DataTable();
            _studentsComment.Columns.Add("IdStudent");
            _studentsComment.Columns.Add("IdComment");
        }
        public void AddCommentsToStudent(Comments comments)
        {
            _studentsComment.Clear();
            foreach (var a in comments.Students)
            {
                _studentsComment.Rows.Add(new object[] { a.Id, null });
            }
            CommentDTO commentDTO = ObjectMapper.Mapper.Map<CommentDTO>(comments);
            CommentRepository.AddCommentsToStudents(commentDTO, _studentsComment);
          ;
        }
    }
}
