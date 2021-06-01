using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalBLL.Models
{
    public class Group
    {
        public int Id;
        public string Name { get; set; }

        public Course Course { get; set; }
        public int IsFinish { get; set; }
        public int IsDelete { get; set; }
    }
}
