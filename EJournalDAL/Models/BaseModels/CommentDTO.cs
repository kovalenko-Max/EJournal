using System;
using System.Collections.Generic;
using System.Linq;

namespace EJournalDAL.Models.BaseModels
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string CommentType { get; set; }

        public override bool Equals(object obj)
        {
            bool equal = false;
            CommentDTO comments = obj as CommentDTO;

            if (!(comments is null) && Id == comments.Id && Comment == comments.Comment
                && CommentType == comments.CommentType)
            {
                equal = true;
            }
            return equal;
        }

    }
}
