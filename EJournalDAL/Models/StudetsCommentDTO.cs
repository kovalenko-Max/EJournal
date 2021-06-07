using EJournalDAL.Models.BaseModels;
using System.Collections.Generic;

namespace EJournalDAL.Models
{
    public class StudetsCommentDTO
    {
        public List<CommentDTO> commments { get; set; }
        public List<StudentDTO> students { get; set; }
    }
}
