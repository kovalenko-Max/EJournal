using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalBLL.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string CommentType { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Comments comments &&
                   Id == comments.Id &&
                   Comment == comments.Comment &&
                   CommentType == comments.CommentType;
        }
    }
}
