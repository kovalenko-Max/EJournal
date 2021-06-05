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
        public bool IsDelete { get; set; }
    }
}
