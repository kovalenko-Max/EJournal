using System.Collections.Generic;
using EJournalDAL.Repository;
using EJournalBLL.Models;
using EJournalDAL.Models.BaseModels;

namespace EJournalBLL.Services
{
    public class CoursesService
    {
        private ICoursesRepository _coursesRepository;
        
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

        public CoursesService(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        public List<Course> GetAllCourses()
        {
            return ObjectMapper.Mapper.Map<List<Course>>(_coursesRepository.GetAllCourses());
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

        public bool IsGroupsContainsThisCourse(Course course)
        {
            return (_coursesRepository.CountGroupsByCourse(course.Id) > 0);
        }
    }
}
