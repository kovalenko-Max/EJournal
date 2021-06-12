using EJournalBLL.Models;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalBLL.Services
{
    public class CommentsService
    {
        public List<Comment> Comments { get; set; }
        string ConnectionString { get; set; }
        public CommentRepository CommentRepository { get; set; }

        public CommentsService(string connectionString)
        {
            ConnectionString = connectionString;
            CommentRepository = new CommentRepository(connectionString);
        }

        public List<Comment> GetCommentsByStudent(int id)
        {
            List<CommentDTO> commentsDTO = CommentRepository.GetCommentsByStudent(id);

            return Comments = ObjectMapper.Mapper.Map<List<Comment>>(commentsDTO);
        }

        public void UpdateComment(Comment comment)
        {
            CommentDTO commentDTO = ObjectMapper.Mapper.Map<CommentDTO>(comment);
            CommentRepository.UpdateComment(commentDTO);
        }
    }
}
