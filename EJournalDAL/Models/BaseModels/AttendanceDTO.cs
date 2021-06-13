namespace EJournalDAL.Models.BaseModels
{
    public class AttendanceDTO
    {
        public int IdLesson { get; set; }
        public int IdStudent { get; set; }
        public bool IsPresence { get; set; }
        public StudentDTO StudentDTO { get; set; }

        public override bool Equals(object obj)
        {
            bool eqaul = false;
            AttendanceDTO attendanceDTO = obj as AttendanceDTO;

            if(!(attendanceDTO is null) && IsPresence==attendanceDTO.IsPresence 
                && StudentDTO.Equals(attendanceDTO.StudentDTO))
            {
                eqaul = true;
            }
            return eqaul;
        }
    }
}
