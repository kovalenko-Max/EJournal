using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.BasicModels
{
    public class CourseDTO
    {
        public int? Id;
        public string Name { get; set; }
        public bool IsDelete { get; set; }
    }
}
