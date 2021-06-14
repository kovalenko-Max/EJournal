namespace EJournalDAL.Models.BaseModels
{
    public class AttendanceDTO
    {
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
