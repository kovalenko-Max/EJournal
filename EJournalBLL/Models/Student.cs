using EJournalDAL.Models.BaseModels;

namespace EJournalBLL.Models
{
    public class Student
    {
        public int Id;
        public string Name;
        public string Surname;
        public string Email;
        public string Git;
        public string City;
        public string AgreementNumber;

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

        public override bool Equals(object obj)
        {
            bool isEquals = false;
            if(obj is Student)
            {
                Student student = (Student)obj;
                isEquals = Id == student.Id &&
                    Name == student.Name &&
                    Surname == student.Surname &&
                    Email == student.Email &&
                    Git == student.Git &&
                    City == student.City &&
                    AgreementNumber == student.AgreementNumber;
            }
            return isEquals;
        }

        public override string ToString()
        {
            return $"{Name} {Surname} {Email} {City} {AgreementNumber}";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
