using EJournalDAL.Models;
using System.Collections.Generic;

namespace EJournalBLL.Models
{
    public class Attendances
    {
        public Student Student { get; set; }
        public string StudentName { get; set; }
        public bool isPresent { get; set; }

        public Attendances(StudentAttendanceDTO studentAttendanceDTO)
        {
            Student = new Student(studentAttendanceDTO.Name, studentAttendanceDTO.Surname);
            StudentName = Student.ToString();
            Student.Id = studentAttendanceDTO.IdStudent;
            isPresent = studentAttendanceDTO.IsPresence == 1;
        }

        public static List<Attendances> GetAttendancesFromStudentAttendanceDTO(List<StudentAttendanceDTO> studentAttendancesDTO)
        {
            List<Attendances> attendances = new List<Attendances>();
            foreach (var studentAttendanseDTO in studentAttendancesDTO)
            {
                attendances.Add(new Attendances(studentAttendanseDTO));
            }

            return attendances;
        }
    }
}
