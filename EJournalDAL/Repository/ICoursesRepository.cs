using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;

using System.Collections.Generic;


namespace EJournalDAL.Repository
{
    public interface ICoursesRepository
    {
        public List<CourseDTO> GetAllCourses();
        public CourseDTO GetCourse(int id);
        public CourseDTO AddCourse(CourseDTO courseDTO);
        public void UpdateCourse(CourseDTO courseDTO);
        public void DeleteCourse(int Id);
        public int CountGroupsByCourse(int Id);
    }
}
