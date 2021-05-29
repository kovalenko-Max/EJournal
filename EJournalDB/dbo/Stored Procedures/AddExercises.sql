CREATE PROCEDURE AddExercises
@Description nvarchar (255),
@Deadline datetime,
@IdGroup int,
@IdExerciseType int
   AS
   insert into Exercises (Description, Deadline, IdGroup, IdExerciseType)
   values(@Description, @Deadline, @IdGroup, @IdExerciseType)