using EJournalDAL.Models.BaseModels;

namespace EJournalBLL.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Course(string name)
        {
            Name = name;
        }

        public Course(CourseDTO courseDTO)
        {
            Id = courseDTO.Id;
            Name = courseDTO.Name;
        }


        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            bool isEquals = false;

            if(obj is Course)
            {
                Course course = (Course)obj;
                isEquals = Id == course.Id && Name == course.Name;
            }

            return isEquals;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
