using System;
using System.Collections.Generic;
using System.Text;

namespace EJournalDAL.Models.BaseModels
{
    public class ProjectDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ProjectGroupDTO> projectGroups { get; set; }

        public override bool Equals(object obj)
        {
            bool equal = false;
            ProjectDTO project = obj as ProjectDTO;

            if (project != null && Id == project.Id && Name == project.Name
                && Description == project.Description)
            {
                equal = true;
            }
            return equal;
        }
    }
}
