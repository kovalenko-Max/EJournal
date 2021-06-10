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

	Merge [EJournal].StudentsExercises as SE
	using @StudentExercise as S
	on S.IdStudent = SE.IdStudents and S.ExerciseId = SE.IdExercise
	when matched then
	update set SE.Points = S.Points, SE.IsChecked = S.IsChecked;