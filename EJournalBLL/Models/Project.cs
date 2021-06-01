using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalBLL.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }

        public override bool Equals(object obj)
        {
            bool equal = false;
            Project project = obj as Project;

            if (project != null && Id == project.Id && Name == project.Name
                && Description == project.Description && IsDelete == project.IsDelete)
            {
                equal = true;
            }
            return equal;
        }

    }
}
