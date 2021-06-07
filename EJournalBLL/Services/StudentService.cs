using EJournalDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using EJournalDAL.Models.BaseModels;
using System.Threading.Tasks;
using EJournalBLL.Models;

namespace EJournalBLL
{
    public class StudentService
    {
        public List<Student> Students { get; set; }
        string ConnectionString { get; set; }
        public StudentsRepository StudentsRepository { get; set; }

        public StudentService(string connectionString)
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
        public List<Student> GetStudentsFromProjectGroups(int IdProjectGroup)
        {
            List<StudentDTO> StudentsDTO = StudentsRepository.GetStudentsFromOneProjectGroup(IdProjectGroup);
            List<Student> students = ObjectMapper.Mapper.Map<List<Student>>(StudentsDTO);
            return students;
        }
        public List<Student> GetStudentsByGroup(int groupId)
        {
            StudentsRepository studentsRepository = new StudentsRepository(ConnectionString);
            List<StudentDTO> studentsDTO = studentsRepository.GetStudentsByGroup(groupId);

            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentsDTO);
        }

        public List<Student> GetStudentsNotAreInProjectGroups(int IdProjectGroup)
        {
            List<StudentDTO> StudentsDTO = StudentsRepository.GetStudentsNotAreInProjectGroup
                (IdProjectGroup);
            List<Student> students = ObjectMapper.Mapper.Map<List<Student>>(StudentsDTO);
            return students;
        }
    }
}
