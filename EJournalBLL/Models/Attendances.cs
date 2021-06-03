using EJournalDAL.Models;
using System.Collections.Generic;

namespace EJournalBLL.Models
{
    public class Attendances
    {
        public Student Student;
        bool isPresent;

        public Attendances(StudentAttendanceDTO studentAttendanceDTO)
        {
            Student = new Student(studentAttendanceDTO.Name, studentAttendanceDTO.Surname, string.Empty);
            Student.Id = studentAttendanceDTO.IdStudent;
            isPresent = studentAttendanceDTO.IsPresence == 1;
        }

        public static List<Attendances> GetAttendancesFromStudentAttendanceDTO(List<StudentAttendanceDTO> studentAttendancesDTO)
        {
            List<Attendances> attendances = new List<Attendances>();
            foreach(var studentAttendanseDTO in studentAttendancesDTO)
            {
                attendances.Add(new Attendances(studentAttendanseDTO));
            }

            return attendances;
        }
    }
}
