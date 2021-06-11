using EJournalDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalBLL.Models
{
    public class StudentMark
    {
        public Student Student { get; set; }
        public int Point { get; set; }

        public StudentMark(Student student, int point)
        {
            Student = student;
            Point = point;
        }

        public StudentMark(Student student)
        {
            Student = student;
        }

        public StudentMark(StudentExerciseDTO studentExerciseDTO)
        {
            Student = new Student(studentExerciseDTO.Name, studentExerciseDTO.Surname);
            Student.Id = studentExerciseDTO.IdStudent;
            Point = studentExerciseDTO.Point;
        }

        public static List<StudentMark> GetStudentMarksFromStudentExerciseDTO(List<StudentExerciseDTO> studentExerciseDTO)
        {
            List<StudentMark> studentMarks = new List<StudentMark>();

            foreach (var mark in studentExerciseDTO)
            {
                studentMarks.Add(new StudentMark(mark));
            }

            return studentMarks;
        }

        public override bool Equals(object obj)
        {
            return obj is StudentMark mark &&
                   EqualityComparer<Student>.Default.Equals(Student, mark.Student) &&
                   Point == mark.Point;
        }
    }
}
