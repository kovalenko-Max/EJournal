using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Models.BaseModels
{
   public class CommentTypeDTO
    {
        public int? Id { get; set; }
        public string Type { get; set; }

        public override bool Equals(object obj)
        {
            bool equal = false;
            CommentTypeDTO commentType = obj as CommentTypeDTO;

            if (!(commentType is null) && Id == commentType.Id && Type == commentType.Type)
            {
                equal = true;
            }

            return equal;
        }
    }
}
