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

        public List<Student> GetStudentsByGroup(int groupId)
        {
            StudentsRepository studentsRepository = new StudentsRepository(ConnectionString);
            List<StudentDTO> studentsDTO = studentsRepository.GetStudentsByGroup(groupId);

            return Students = ConvertStudentsDTOToStudents(studentsDTO);
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
