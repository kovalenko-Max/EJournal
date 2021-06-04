using System.Collections.Generic;
using EJournalDAL.Repository;
using EJournalBLL.Models;

namespace EJournalBLL.Services
{
    public class CoursesService
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

        public CoursesService(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private List<Course> GetAllCourses()
        {
            CoursesRepository coursesRepository = new CoursesRepository(ConnectionString);
            
            return ObjectMapper.Mapper.Map<List<Course>>(coursesRepository.GetAllCoursesDTO());
        }
    }
}
