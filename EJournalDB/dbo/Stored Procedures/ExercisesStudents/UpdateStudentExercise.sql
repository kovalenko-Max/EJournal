CREATE PROCEDURE [EJournal].[UpdateStudentExercise]
	@Id int,
	@IdGroup int,
	@Description nvarchar(250),
	@ExerciseType nvarchar(250),
	@Deadline datetime,
	@StudentExercise as [EJournal].[StudentExercise] Readonly
AS
	update [EJournal].[Exercises]
	set Description = @Description, Deadline = @Deadline, ExerciseType = @ExerciseType
	where Exercises.Id = @Id

	MERGE [EJournal].[StudentsExercises] as SE
	using @StudentExercise as SEV
	on SEV.IdStudent = SE.IdStudent and SEV.IdExercise=SE.IdExercise
	WHEN MATCHED THEN
       UPDATE SET SE.Point = SEV.Points;