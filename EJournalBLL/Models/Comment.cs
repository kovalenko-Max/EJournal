using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalBLL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public string CommentType { get; set; }
        public bool IsDelete { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Comment comments &&
                   Id == comments.Id &&
                   Comments == comments.Comments &&
                   CommentType == comments.CommentType &&
                   IsDelete == comments.IsDelete;
        }
    }
}
