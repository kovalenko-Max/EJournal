CREATE PROCEDURE UpdateExercise
@Id int,
@Description nvarchar (255),
@Deadline datetime,
@IdGroup int,
@IdExerciseType int
   AS
   update Exercises
   set Description = @Description, Deadline = @Deadline, IdGroup = @IdGroup, IdExerciseType = @IdExerciseType
   where Id = @Id