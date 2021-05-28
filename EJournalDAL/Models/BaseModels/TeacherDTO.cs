using System;
using System.Collections.Generic;
using System.Text;

namespace EJournalDAL.Models.BaseModels
{
    public class TeacherDTO
    {
        public int? Id;
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsDelete { get; set; }
    }
}
