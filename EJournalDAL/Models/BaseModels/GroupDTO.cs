using System.Collections.Generic;

namespace EJournalDAL.Models.BaseModels
{
    public class GroupDTO
    {
        public int Id;
        public string Name { get; set; }
        public int IdCourse { get; set; }
        public CourseDTO Course { get; set; }
        public int IsFinish { get; set; }
        public int IsDelete { get; set; }
        public int? StudentsCount { get; set; }

        public override bool Equals(object obj)
        {
            bool isEquals = false;
            
            if (obj is GroupDTO)
            {
                GroupDTO groupDTO = (GroupDTO)obj;

                isEquals = Id == groupDTO.Id
                    && Name == groupDTO.Name
                    && IdCourse == groupDTO.IdCourse
                    && IsDelete == groupDTO.IsDelete;
            }

            return isEquals;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {IdCourse} {IsFinish} {IsDelete}";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
