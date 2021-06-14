namespace EJournalBLL.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Project(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public override bool Equals(object obj)
        {
            bool equal = false;
            Project project = obj as Project;

            if (project != null && Id == project.Id && Name == project.Name
                && Description == project.Description)
            {
                equal = true;
            }
            return equal;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
