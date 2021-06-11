using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalBLL.Models
{
    public class CommentType
    {
        public int? Id { get; set; }
        public string Type { get; set; }
        public CommentType(string type)
        {
            Type = type;
        }

        public override bool Equals(object obj)
        {
            bool equal = false;
            CommentType commentType = obj as CommentType;

            if(!(commentType is null)&& Id== commentType.Id && Type == commentType.Type)
            {
                equal = true;
            }

            return equal;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
