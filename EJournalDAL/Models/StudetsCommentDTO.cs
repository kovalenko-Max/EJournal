using EJournalDAL.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Models
{
    public class StudetsCommentDTO
    {public int? StudentId { get; set; }
        public List<CommentDTO> comments { get; set; }
    }
}
