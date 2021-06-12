﻿using EJournalDAL.Repository;
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

        private StudentsRepository _studentsRepository { get; set; }

        public StudentService()
        {
            _studentsRepository = new StudentsRepository();
        }

        public List<Student> GetAllStudent()
        {
            List<StudentDTO> studentDTO = _studentsRepository.GetAll();
            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentDTO);
        }
        public void AddStudent(Student studentInput)
        {
            StudentDTO student = ObjectMapper.Mapper.Map<StudentDTO>(studentInput);
            _studentsRepository.Create(student);
        }
        public void Update(Student studentInput)
        {
            StudentDTO student = ObjectMapper.Mapper.Map<StudentDTO>(studentInput);
            _studentsRepository.Update(student);
        }

        public void Delete(int Id)
        {
            _studentsRepository.DeleteSoft(Id);
        }

        public List<Student> GetStudentsFromProjectGroups(int IdProjectGroup)
        {
            List<StudentDTO> StudentsDTO = _studentsRepository.GetStudentsFromOneProjectGroup(IdProjectGroup);
            List<Student> students = ObjectMapper.Mapper.Map<List<Student>>(StudentsDTO);
            return students;
        }
        public List<Student> GetStudentsByGroup(int groupId)
        {
            StudentsRepository studentsRepository = new StudentsRepository();
            List<StudentDTO> studentsDTO = studentsRepository.GetStudentsByGroup(groupId);

            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentsDTO);
        }

        public List<Student> GetStudentsNotAreInProjectGroups(int IdProjectGroup)
        {
            List<StudentDTO> StudentsDTO = _studentsRepository.GetStudentsNotAreInProjectGroup
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

        public List<Student> SearchStudentsByPhone(string phone)
        {
            StudentsRepository studentsRepository = new StudentsRepository(ConnectionString);
            List<StudentDTO> studentsDTO = studentsRepository.SearchStudentPhone(phone);

            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentsDTO);
        }

        public List<Student> SearchStudentsByEmail(string email)
        {
            StudentsRepository studentsRepository = new StudentsRepository(ConnectionString);
            List<StudentDTO> studentsDTO = studentsRepository.SearchStudentEmail(email);

            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentsDTO);
        }

        public List<Student> SearchStudentsByName(string name)
        {
            StudentsRepository studentsRepository = new StudentsRepository(ConnectionString);
            List<StudentDTO> studentsDTO = studentsRepository.SearchStudentName(name);

            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentsDTO);
        }

        public List<Student> SearchStudentsBySurname(string surname)
        {
            StudentsRepository studentsRepository = new StudentsRepository(ConnectionString);
            List<StudentDTO> studentsDTO = studentsRepository.SearchStudentSurname(surname);

            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentsDTO);
        }

        public List<Student> SearchStudentsByCity(string city)
        {
            StudentsRepository studentsRepository = new StudentsRepository(ConnectionString);
            List<StudentDTO> studentsDTO = studentsRepository.SearchStudentCity(city);

            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentsDTO);
        }

        public List<Student> SearchStudentsGroup(string group)
        {
            StudentsRepository studentsRepository = new StudentsRepository(ConnectionString);
            List<StudentDTO> studentsDTO = studentsRepository.SearchStudentGroup(group);

            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentsDTO);
        }

        public List<Student> SearchStudentsCourses(string course)
        {
            StudentsRepository studentsRepository = new StudentsRepository(ConnectionString);
            List<StudentDTO> studentsDTO = studentsRepository.SearchStudentCourses(course);

            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentsDTO);
        }
        public List<Student> SearchStudentsAllStudents()
        {
            StudentsRepository studentsRepository = new StudentsRepository(ConnectionString);
            List<StudentDTO> studentsDTO = studentsRepository.SearchStudentAllStudents();

            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentsDTO);
        }

        public List<Student> SearchStudentsAgreementNumbers(string AgreementNumbers)
        {
            StudentsRepository studentsRepository = new StudentsRepository(ConnectionString);
            List<StudentDTO> studentsDTO = studentsRepository.SearchStudentAgreementNumbers(AgreementNumbers);

            return Students = ObjectMapper.Mapper.Map<List<Student>>(studentsDTO);
        }
    }
}
