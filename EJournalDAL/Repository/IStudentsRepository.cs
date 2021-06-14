using EJournalDAL.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Repository
{
    public interface IStudentsRepository
    {
        public List<StudentDTO> GetAllStudents();
        public List<StudentDTO> GetStudentsFromProjectGroup(int idProjectGroup);
        public List<StudentDTO> GetStudentsNotInProjectGroup(int idProjectGroup);
        public void AddStudent(StudentDTO student);
        public void UpdateStudent(StudentDTO student);
        public List<StudentDTO> GetStudentsByGroup(int id);
        public void DeleteStudent(int id);
        public List<StudentDTO> GetStudentsNotAreInGroup(int idGroup);
        int UpdateStudentRating(int id);
        public List<StudentDTO> SearchByStudentPhone(string phone);
        public List<StudentDTO> SearchByStudentEmail(string email);
        public List<StudentDTO> SearchStudentsByFullName(string name);
        public List<StudentDTO> SearchByStudentCity(string city);
        public List<StudentDTO> SearchByStudentGroup(string group);
        public List<StudentDTO> SearchByStudentCourses(string courses);
        public List<StudentDTO> SearchByStudentAgreementNumbers(string AgreementNumbers);
    }
}
