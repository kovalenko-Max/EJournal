using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.BasicModels
{
    public class ProjectGroupDTO
    {
        public int? Id;
        public string Name { get; set; }
        public int? IdStudent { get; set; }
        public int? IdComments { get; set; }
        public bool IsDelete { get; set; }
    }
}
