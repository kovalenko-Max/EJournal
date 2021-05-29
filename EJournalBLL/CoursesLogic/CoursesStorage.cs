using EJournalDAL.Models.BaseModels;
using EJournalDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalBLL.CoursesLogic
{
    public class CoursesStorage
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

        public CoursesStorage(string connectionString)
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
