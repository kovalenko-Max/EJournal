namespace EJournalBLL.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Course()
        {

        }
        public Course(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Course course &&
                   Id == course.Id &&
                   Name == course.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
