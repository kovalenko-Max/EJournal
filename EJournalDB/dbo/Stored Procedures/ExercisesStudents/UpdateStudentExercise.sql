CREATE PROCEDURE [EJournal].[UpdateStudentExercise]
	@IdGroup int,
	@Id int,
	@Description nvarchar(250),
	@ExerciseType nvarchar(250),
	@Deadline datetime,
	@StudentExercise as [EJournal].[StudentExercise] Readonly
AS
	update [EJournal].Exercises
	set Description = @Description, Deadline = @Deadline, ExerciseType = @ExerciseType
	where Exercises.Id = @Id