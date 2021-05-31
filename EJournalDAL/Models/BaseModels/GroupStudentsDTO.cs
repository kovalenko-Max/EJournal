using System.Collections.Generic;

namespace EJournalDAL.Models.BaseModels
{
    public class GroupStudentsDTO
    {
        public string IdGroup { get; set; }
        
        public string IdStudent { get; set; }
        public int? IsFinish { get; set; }
        public int NumberOfStudents { get; set; }

        public List<StudentDTO> students;
    }
}
