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
        public List<StudentDTO> GetAll();
        public List<StudentDTO> GetStudentsFromOneProjectGroup(int idProjectGroup);
        public List<StudentDTO> GetStudentsNotAreInProjectGroup(int idProjectGroup);
        public void Create(StudentDTO student);
        public void Update(StudentDTO student);
        public List<StudentDTO> GetStudentsByGroup(int id);
        public void DeleteOne(int Id);
        public void DeleteSoft(int id);
        public List<StudentDTO> GetStudentsNotAreInGroup(int idGroup);
        int UpdateStudentRating(int id);
    }
}
