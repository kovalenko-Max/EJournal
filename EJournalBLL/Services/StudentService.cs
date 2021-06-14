using EJournalDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using EJournalDAL.Models.BaseModels;
using System.Threading.Tasks;
using EJournalBLL.Models;

namespace EJournalBLL.Services
{
    public class StudentService
    {
        public List<Student> Students { get; set; }

        private IStudentsRepository _studentsRepository { get; set; }

        public StudentService()
        {
            _studentsRepository = new StudentsRepository();
        }
        public StudentService(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        public List<Student> GetAllStudent()
        {
            List<StudentDTO> studentDTO = _studentsRepository.GetAllStudents();
            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentDTO);
        }
        public void AddStudent(Student studentInput)
        {
            StudentDTO student = ObjectMapper.Mapper.Map<StudentDTO>(studentInput);
            _studentsRepository.AddStudent(student);
        }
        public void Update(Student studentInput)
        {
            StudentDTO student = ObjectMapper.Mapper.Map<StudentDTO>(studentInput);
            _studentsRepository.UpdateStudent(student);
        }

        public void Delete(int Id)
        {
            _studentsRepository.DeleteStudent(Id);
        }

        public List<Student> GetStudentsFromProjectGroups(int IdProjectGroup)
        {
            List<StudentDTO> StudentsDTO = _studentsRepository.GetStudentsFromProjectGroup(IdProjectGroup);
            List<Student> students = ObjectMapper.Mapper.Map<List<Student>>(StudentsDTO);
            return students;
        }
        public List<Student> GetStudentsByGroup(int groupId)
        {
            List<StudentDTO> studentsDTO = _studentsRepository.GetStudentsByGroup(groupId);

            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentsDTO);
        }

        public List<Student> GetStudentsNotAreInProjectGroups(int IdProjectGroup)
        {
            List<StudentDTO> StudentsDTO = _studentsRepository.GetStudentsNotInProjectGroup
                (IdProjectGroup);
            List<Student> students = ObjectMapper.Mapper.Map<List<Student>>(StudentsDTO);
            return students;
        }

        public List<Student> GetStudentsNotAreInGroup(int idGroup)
        {
            List<Student> students = ObjectMapper.Mapper.Map<List<Student>>(
                _studentsRepository.GetStudentsNotAreInGroup(idGroup));

            return students;
        }

        public void UpdateStudentRating(Student student)
        {
            student.Ranking = _studentsRepository.UpdateStudentRating(student.Id);
        }

        public List<Student> SearchStudentsByPhone(string phone)
        {
            StudentsRepository studentsRepository = new StudentsRepository();
            List<StudentDTO> studentsDTO = studentsRepository.SearchByStudentPhone(phone);

            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentsDTO);
        }

        public List<Student> SearchStudentsByEmail(string email)
        {
            StudentsRepository studentsRepository = new StudentsRepository();
            List<StudentDTO> studentsDTO = studentsRepository.SearchByStudentEmail(email);

            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentsDTO);
        }

        public List<Student> SearchStudentsByFullName(string name)
        {
            StudentsRepository studentsRepository = new StudentsRepository();
            List<StudentDTO> studentsDTO = studentsRepository.SearchStudentsByFullName(name);

            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentsDTO);
        }

        public List<Student> SearchStudentsByCity(string city)
        {
            StudentsRepository studentsRepository = new StudentsRepository();
            List<StudentDTO> studentsDTO = studentsRepository.SearchByStudentCity(city);

            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentsDTO);
        }

        public List<Student> SearchStudentsGroup(string group)
        {
            StudentsRepository studentsRepository = new StudentsRepository();
            List<StudentDTO> studentsDTO = studentsRepository.SearchByStudentGroup(group);

            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentsDTO);
        }

        public List<Student> SearchStudentsCourses(string course)
        {
            StudentsRepository studentsRepository = new StudentsRepository();
            List<StudentDTO> studentsDTO = studentsRepository.SearchByStudentCourses(course);

            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentsDTO);
        }

        public List<Student> SearchStudentsAgreementNumbers(string AgreementNumbers)
        {
            StudentsRepository studentsRepository = new StudentsRepository();
            List<StudentDTO> studentsDTO = studentsRepository.SearchByStudentAgreementNumbers(AgreementNumbers);

            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentsDTO);
        }
    }
}
