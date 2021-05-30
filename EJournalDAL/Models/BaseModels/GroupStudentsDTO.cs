using System.Collections.Generic;

namespace EJournalDAL.Models.BaseModels
{
    public class GroupStudentsDTO
    {
        public int IdGroup { get; set; }
        public int IdStudent { get; set; }
        public int? IsFinish { get; set; }
        public int NumberOfStudents { get; set; }

        public List<StudentDTO> students;

        public override bool Equals(object obj)
        {
            bool isEquals = false;

            if (obj is GroupStudentsDTO)
            {
                GroupStudentsDTO groupDTO = (GroupStudentsDTO)obj;

                if (groupDTO.IdGroup == IdGroup
                   && groupDTO.IdStudent == IdStudent
                   && groupDTO.IsFinish == IsFinish
                   && groupDTO.NumberOfStudents == NumberOfStudents)
                {
                    isEquals = true;

                    foreach (StudentDTO student in students)
                    {
                        if (groupDTO.students.Contains(student))
                        {
                            isEquals = true;
                        }
                        else
                        {
                            isEquals = false;
                        }
                    }
                }
            }

            return isEquals;
        }

        public override string ToString()
        {
            return $"{IdGroup} {IdStudent} {IsFinish} {IsFinish} {NumberOfStudents} {GetStudentsString()}";
        }

        private string GetStudentsString()
        {
            string result = "";

            foreach (StudentDTO student in students)
            {
                result += student.ToString();
            }

            return result;
        }
    }
}
