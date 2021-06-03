using EJournalDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using EJournalDAL.Models.BaseModels;
using System.Threading.Tasks;
using EJournalBLL.Models;

namespace EJournalBLL
{
    public class StudentServices
    {
        StudentsRepository projectRepository;
        string connectionString;
        public StudentServices(string connectionString)
        {
            this.connectionString = connectionString;
            projectRepository = new StudentsRepository(connectionString);
        }

        public List<Student> GetAllStudent()
        {
            List<StudentDTO> studentDTO = projectRepository.GetAll();
            List<Student> student = ObjectMapper.Mapper.Map<List<Student>>(studentDTO);
            return student;
        }
        public void AddProject(Student studentInput)
        {

            StudentDTO student = ObjectMapper.Mapper.Map<StudentDTO>(studentInput);
            projectRepository.Create(student);

        }
        public void Update(Student studentInput)
        {
            StudentDTO student = ObjectMapper.Mapper.Map<StudentDTO>(studentInput);
            projectRepository.Update(student);
        }

        public void Delete(int Id)
        {
            projectRepository.DeleteSoft(Id);
        }
    }
}


