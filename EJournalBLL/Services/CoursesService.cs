using System.Collections.Generic;
using EJournalDAL.Repository;
using EJournalBLL.Models;
using EJournalDAL.Models.BaseModels;

namespace EJournalBLL.Services
{
    public class CoursesService
    {
        ICoursesRepository _coursesRepository;
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
            _coursesRepository = new CoursesRepository();
        }

        public List<Course> GetAllCourses()
        {
            CoursesRepository coursesRepository = new CoursesRepository();
            
            return ObjectMapper.Mapper.Map<List<Course>>(coursesRepository.GetAllCourses());
        }

        public void AddCourse(Course course)
        {
            course.Id = (_coursesRepository.AddCourse(ObjectMapper.Mapper.Map<CourseDTO>(course))).Id;
        }

        public void UpdateCourse(Course course)
        {
            _coursesRepository.UpdateCourse(ObjectMapper.Mapper.Map<CourseDTO>(course));
        }

        public void DeleteCourse(Course course)
        {
            _coursesRepository.DeleteCourse(course.Id);
        }

        public bool check(Course course)
        {
            return (_coursesRepository.CountGroupsByCourse(course.Id) > 0);
        }
    }
}
