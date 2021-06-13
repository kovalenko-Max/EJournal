using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Models.BaseModels
{
    public class ProjectGroupStudentDTO
    {
        public int? IdStudent { get; set; }
        public int? IdProjectGroup { get; set; }

        public override bool Equals(object obj)
        {
            bool equal = false;
            ProjectGroupStudentDTO projectGroupStudentDTO = obj as ProjectGroupStudentDTO;

            if(!(projectGroupStudentDTO is null) && IdStudent==projectGroupStudentDTO.IdStudent
                && IdProjectGroup == projectGroupStudentDTO.IdProjectGroup)
            {
                equal = true;
            }

            return equal;
        }
    }
}
