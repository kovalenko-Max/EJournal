using System.Collections.Generic;
using EJournalDAL.Repository;
using EJournalBLL.Models;
using EJournalDAL.Models.BaseModels;

namespace EJournalBLL.Services
{
    public class CoursesService
    {
        public List<Course> Courses
        {
            get
            {
                return Courses = GetAllCourses();
            }
            set
            {

            }
        }

        public CoursesService()
        {
        }

        public List<Course> GetAllCourses()
        {
            CoursesRepository coursesRepository = new CoursesRepository();
            
            return ObjectMapper.Mapper.Map<List<Course>>(coursesRepository.GetAllCourses());
        }

        public void AddCourse(Course course)
        {
            CoursesRepository coursesRepository = new CoursesRepository();
            course.Id = (coursesRepository.AddCourse(ObjectMapper.Mapper.Map<CourseDTO>(course))).Id;
        }

        public void UpdateCourse(Course course)
        {
            CoursesRepository coursesRepository = new CoursesRepository();
            coursesRepository.UpdateCourse(ObjectMapper.Mapper.Map<CourseDTO>(course));
        }
    }
}
