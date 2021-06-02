using EJournalDAL.Models.BaseModels;

namespace EJournalBLL.Models
{
    public class Student
    {
        public int Id;
        public string Name;
        public string Surname;
        public string Email;
        public string Phone;
        public string Git;
        public string City;
        public int Ranking;
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
            Phone = studentDTO.Phone;
            Git = studentDTO.Git;
            City = studentDTO.City;
            Ranking = studentDTO.Ranking;
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
                    Phone == student.Phone &&
                    Git == student.Git &&
                    City == student.City &&
                    Ranking == student.Ranking &&
                    AgreementNumber == student.AgreementNumber;
            }
            return isEquals;
        }

        public override string ToString()
        {
            return $"{Name} {Surname} {Email} {Phone} {Git} {City} {Ranking} {AgreementNumber}";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
