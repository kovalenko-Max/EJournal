using System;
using System.Collections.Generic;
using System.Linq;

namespace EJournalDAL.Models.BaseModels
{
    public class ProjectGroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdProject { get; set; }
        public int Mark { get; set; }

        public List<StudentDTO> Students { get; set; }

        public override bool Equals(object obj)
        {
            bool equal = false;
            ProjectGroupDTO projectGroupDTO = obj as ProjectGroupDTO;
            if(!(projectGroupDTO is null) && Id == projectGroupDTO.Id
                && Name ==projectGroupDTO.Name && Mark==projectGroupDTO.Mark)
            {
                equal = Students.SequenceEqual(projectGroupDTO.Students);
            }
            return equal;
        }
    }
}
