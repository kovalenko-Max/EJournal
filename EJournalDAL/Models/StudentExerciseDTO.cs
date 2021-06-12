using System;

namespace EJournalDAL.Models
{
    public class StudentExerciseDTO
    {
        public int IdStudent { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Point { get; set; }
        
        public int IdExercise { get; set; }

        public override bool Equals(object obj)
        {
            return obj is StudentExerciseDTO dTO &&
                   IdStudent == dTO.IdStudent &&
                   IdExercise == dTO.IdExercise &&
                   Point == dTO.Point;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdStudent, IdExercise, Point);
        }

        public override string ToString()
        {
            return $"{IdStudent} {Name} {Surname} {IdExercise} {Point}";
        }
    }
}
