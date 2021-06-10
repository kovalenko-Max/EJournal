CREATE PROCEDURE [dbo].[AddExerciseToStudent]
	@IdGroup int,
	@Description nvarchar(250),
	@ExerciseType nvarchar(250),
	@Deadline datetime,
	@StudentExerciseVariable as [EJournal].[StudentExercise] Readonly
AS
	declare @IdExercise int
	declare @StudentExercise as [EJournal].[StudentExercise]

	insert into @StudentExercise
	select *
	from @StudentExerciseVariable

	insert into [EJournal].Exercises(Description, Deadline, IdGroup, ExerciseType)
	values(@Description, @Deadline, @IdGroup, @ExerciseType)
	set @IdExercise = SCOPE_IDENTITY()

	update @StudentExercise
	set ExerciseId = @IdExercise

	insert into [EJournal].[StudentsExercises](IdExercise, IdStudents, Points, IsChecked)
	select ExerciseId, IdStudent, Points, IsChecked
	from @StudentExercise

RETURN @IdExercise
