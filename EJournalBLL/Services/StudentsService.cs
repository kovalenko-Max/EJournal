using EJournalDAL.Repository;
using System.Collections.Generic;
using EJournalDAL.Models.BaseModels;
using EJournalBLL.Models;

namespace EJournalBLL.Services
{
    public class StudentsService
    {
        public List<Student> Students { get; set; }
        string ConnectionString { get; set; }
        public StudentsRepository StudentsRepository { get; set; }

        public StudentsService(string connectionString)
        {
            ConnectionString = connectionString;
            StudentsRepository = new StudentsRepository(connectionString);
        }

        public List<Student> GetAllStudent()
        {
            List<StudentDTO> studentDTO = StudentsRepository.GetAll();
            List<Student> student = ObjectMapper.Mapper.Map<List<Student>>(studentDTO);

            return student;
        }

        public List<Student> GetStudentsByGroup(int groupId)
        {
            StudentsRepository studentsRepository = new StudentsRepository(ConnectionString);
            List<StudentDTO> studentsDTO = studentsRepository.GetStudentsByGroup(groupId);

            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentsDTO);
        }

        public void AddStudent(Student studentInput)
        {
            StudentDTO student = ObjectMapper.Mapper.Map<StudentDTO>(studentInput);
            StudentsRepository.Create(student);
        }

        public void Update(Student studentInput)
        {
            StudentDTO student = ObjectMapper.Mapper.Map<StudentDTO>(studentInput);
            StudentsRepository.Update(student);
        }

        public void Delete(int Id)
        {
            StudentsRepository.DeleteSoft(Id);
        }
    }
}
