using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalBLL.Models
{
    class ProjectGroup
    {
        public int Id;
        public string Name { get; set; }
      
        public bool IsDelete { get; set; }

        public List<Student> Students { get; set; }
    }
}
