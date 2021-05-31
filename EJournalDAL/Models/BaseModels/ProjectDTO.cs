using System;
using System.Collections.Generic;
using System.Text;

namespace EJournalDAL.Models.BaseModels
{
    public class ProjectDTO
    {
        public int? Id;
        public string Name { get; set; }
        public string Description { get; set; }
        public int? IdProjectGroup { get; set; }
        public bool IsDelete { get; set; }

        public List<ProjectGroupDTO> projectGroups { get; set;
        
        }
    }
}
