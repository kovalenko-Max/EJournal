CREATE PROCEDURE DeleteExercises
@Id int
   AS
   update Exercises
   set IsDelete = 1
  where Id = @Id