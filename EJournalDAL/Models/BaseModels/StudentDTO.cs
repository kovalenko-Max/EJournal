using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.BasicModels
{
    public class StudentDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Git { get; set; }
        public string AgreementNumber { get; set; }
        public bool IsDelete { get; set; }
    }
}
