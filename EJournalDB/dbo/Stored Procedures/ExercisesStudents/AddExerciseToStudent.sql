CREATE PROCEDURE [EJournal].[AddExerciseToStudent]
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

	insert into [EJournal].[Exercises] (IdGroup, Description, Deadline)
	values(@IdGroup, @Description, @Deadline)
	set @IdExercise = SCOPE_IDENTITY()
	
	update @StudentExercise
	set IdExercise = @IdExercise

	insert into [EJournal].[StudentsExercises]
	select * from @StudentExercise

	RETURN @IdExercise
