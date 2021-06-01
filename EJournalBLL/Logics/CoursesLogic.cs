using System.Collections.Generic;
using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using EJournalBLL.Models;

namespace EJournalBLL.Logics
{
    public class CoursesLogic
    {
        public string ConnectionString { get; set; }
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

        public CoursesLogic(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private List<Course> GetAllCourses()
        {
            CoursesRepository coursesRepository = new CoursesRepository(ConnectionString);
            List<CourseDTO> coursesDTO = coursesRepository.GetAllCoursesDTO();

            return ConvertCoursesDTOToCourses(coursesDTO);
        }

        private List<Course> ConvertCoursesDTOToCourses(List<CourseDTO> coursesDTO)
        {
            List<Course> courses = new List<Course>();
            foreach(CourseDTO courseDTO in coursesDTO)
            {
                courses.Add(new Course(courseDTO));
            }

            return courses;
        }
    }
}
