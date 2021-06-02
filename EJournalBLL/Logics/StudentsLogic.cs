using EJournalBLL.Models;
using EJournalDAL.Repository;
using System.Collections.Generic;
using EJournalDAL.Models.BaseModels;

namespace EJournalBLL.Logics
{
    public class StudentsLogic
    {
        public List<Student> Students { get; set; }
        public string ConnectionString;

        public StudentsLogic(string connectionString)
        {
            ConnectionString = connectionString;
            Students = new List<Student>();
        }

        public List<Student> GetAllStudents()
        {
            StudentsRepository studentsRepository = new StudentsRepository(ConnectionString);
            List<StudentDTO> studentsDTO = studentsRepository.GetAllStudents();

            return Students = ConvertStudentsDTOToStudents(studentsDTO);
        }

        public List<Student> GetStudentsByGroup(int groupId)
        {
            StudentsRepository studentsRepository = new StudentsRepository(ConnectionString);
            List<StudentDTO> studentsDTO = studentsRepository.GetStudentsByGroup(groupId);

            return Students = ConvertStudentsDTOToStudents(studentsDTO);
        }

        public void AddStudent(Student student)
        {
            StudentsRepository studentsRepository = new StudentsRepository(ConnectionString);
            StudentDTO studentDTO = new StudentDTO();
            studentDTO.Name = student.Name;
            studentDTO.Surname = student.Surname;
            studentDTO.Email = student.Email;
            studentDTO.Phone = student.Phone;
            studentDTO.Git = student.Git;
            studentDTO.City = student.City;
            studentDTO.Ranking = student.Ranking;
            studentDTO.AgreementNumber = student.AgreementNumber;
            studentDTO = studentsRepository.AddStudent(studentDTO);
            student.Id = studentDTO.Id;
        }

        private List<Student> ConvertStudentsDTOToStudents(List<StudentDTO> studentsDTO)
        {
            List<Student> students = new List<Student>();

            foreach (StudentDTO studentDTO in studentsDTO)
            {
                students.Add(new Student(studentDTO));
            }

            return students;
        }
    }
}
