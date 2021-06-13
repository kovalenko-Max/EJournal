using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EJournalBLL;

namespace EJournalBLL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public CommentType CommentTypeValue { get; set; }
        public DateTime CommentDate { get; set; }

        public Comment()
        {
            Comments = string.Empty;
            CommentTypeValue = ((CommentType)0);
        }

        public override bool Equals(object obj)
        {
            return obj is Comment comments &&
                   Id == comments.Id &&
                   Comments == comments.Comments &&
                   CommentTypeValue == comments.CommentTypeValue;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Comments, CommentTypeValue);
        }
    }
}
