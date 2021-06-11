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
        public int IdCommentType { get; set; }
        public List<Student> Students { get; set; }
        public Comments()
        {

        }
        public Comments( string comment, int idCommentType )
        {
            Comment = comment;
            IdCommentType = idCommentType;
        }

        public override bool Equals(object obj)
        {
            bool equal = false;
            Comments comments = obj as Comments;

            if(!(comments is null) && Id ==comments.Id && Comment==comments.Comment
                && IdCommentType == comments.IdCommentType)
            {
                equal = Students.SequenceEqual(comments.Students);
            }
            return equal;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
