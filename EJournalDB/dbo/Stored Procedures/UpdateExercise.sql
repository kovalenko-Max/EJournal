CREATE PROCEDURE UpdateExercise
@Id int,
@Description nvarchar (255),
@Deadline datetime,
@IdGroup int
   AS
   update Exercises
   set Description = @Description, Deadline = @Deadline, IdGroup = @IdGroup
   where Id = @Id