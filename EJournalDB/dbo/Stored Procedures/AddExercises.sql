CREATE PROCEDURE AddExercises
@Description nvarchar (255),
@Deadline datetime,
@IdGroup int
   AS
   insert into Exercises (Description, Deadline, IdGroup)
   values(@Description, @Deadline, @IdGroup)