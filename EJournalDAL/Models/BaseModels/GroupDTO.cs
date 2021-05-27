using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.BasicModels
{
    public class GroupDTO
    {
        public int Id;
        public string Name { get; set; }
        public int? IdCourse { get; set; }
        public int? IdFinish { get; set; }
        public bool IsDelete { get; set; }

    }
}
