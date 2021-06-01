﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace EJournalDAL.Models.BaseModels
{
    public class ProjectGroupDTO
    {
        public int? Id;
        public string Name { get; set; }
        public int? IdProject { get; set; }
        public bool IsDelete { get; set; }

        public List<StudentDTO> Students { get; set; }

        public override bool Equals(object obj)
        {
            bool equal = false;
            ProjectGroupDTO projectGroupDTO = obj as ProjectGroupDTO;
            if(!(projectGroupDTO is null) && Id == projectGroupDTO.Id
                && Name ==projectGroupDTO.Name)
            {
                equal = Students.SequenceEqual(projectGroupDTO.Students);
            }
            return equal;
        }
    }
}
