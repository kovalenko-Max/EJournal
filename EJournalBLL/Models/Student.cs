using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalBLL.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Git { get; set; }
        public string City { get; set; }
        public int Ranking { get; set; }
        public string AgreementNumber { get; set; }
        public bool IsDelete { get; set; }
        public List<Comments> Comments { get; set; }

        public override bool Equals(object obj)
        {
            bool equal = false;

            Student student = obj as Student;

            if (student != null && Id == student.Id && Name == student.Name && Surname == student.Surname
                && Email == student.Email && Phone == student.Phone && Git == student.Git
                && City == student.City && Ranking == student.Ranking && AgreementNumber == student.AgreementNumber
                && IsDelete == student.IsDelete )
            {
                equal = Comments.SequenceEqual(student.Comments);
            }
            return equal;
        }
    }
}

        public Student(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }
        public Student(StudentDTO studentDTO)
        {
            Id = (int)studentDTO.Id;
            Name = studentDTO.Name;
            Surname = studentDTO.Surname;
            Email = studentDTO.Email;
            Git = studentDTO.Git;
            City = studentDTO.City;
            AgreementNumber = studentDTO.AgreementNumber;
        }
        public override string ToString()
        {
            return $"{Name} {Surname} {Email} {City} {AgreementNumber}";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }