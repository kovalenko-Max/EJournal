using System;
using System.Collections.Generic;
using System.Text;

namespace EJournalDAL.Models.BaseModels
{
    public class StudentDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Git { get; set; }
        public string City { get; set; }
        public int TeacherAssessment { get; set; }
        public int Ranking { get; set; }
        public string AgreementNumber { get; set; }
        public bool IsDelete { get; set; }
        public List<CommentDTO> comments { get; set; }



        public override bool Equals(object obj)
        {
            StudentDTO student = obj as StudentDTO;
            if(student!= null  && Id==student.Id && Name==student.Name && Surname==student.Surname 
                && Email==student.Email && Phone==student.Phone && Git ==student.Git && City==student.City 
                 && Ranking ==student.Ranking && AgreementNumber == student.AgreementNumber)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {Surname} {Email} {Phone} {Git} {AgreementNumber}";
        }
    }
}
