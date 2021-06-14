using EJournalDAL.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Repository
{
    public interface ICommentRepository
    {
        public int AddComment(CommentDTO commentDTO, int IdStudent);
        public void UpdateComment(CommentDTO comment);
        public void DeleteComment(int id);
        public List<CommentDTO> GetCommentsByStudent(int IdStudent);
        public void AddCommentToStudent(CommentDTO commentDTO, DataTable dt);


    }
}
