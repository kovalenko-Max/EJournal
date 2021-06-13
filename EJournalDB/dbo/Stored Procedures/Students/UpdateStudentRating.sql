CREATE PROCEDURE [EJournal].[UpdateStudentRating]
	 @IdStudent int
AS

	Declare @AttendanceCoef int
	declare @TestCoef int
	declare @HomeWorkCoef int
	declare @TeacherAssessmentCoef INT
	declare @Rating int

	set @AttendanceCoef = (select sum(cast(IsPresence as int)*100) from [EJournal].[Attendances]
	where IdStudent = @IdStudent)/(select COUNT(IsPresence) from [EJournal].[Attendances] where IdStudent = @IdStudent)

	set @TestCoef =
	(select SUM(SE.Point) from [EJournal].StudentsExercises SE
	LEFT JOIN [EJournal].[Exercises] E on E.Id = SE.IdExercise
	where SE.IdStudent = @IdStudent and E.Deadline < GETDATE() and E.ExerciseType = 'Test')/
	(select COUNT(IdExercise) from [EJournal].StudentsExercises SE
	LEFT JOIN [EJournal].[Exercises] E on E.Id = SE.IdExercise
	where SE.IdStudent = @IdStudent and E.Deadline < GETDATE() and E.ExerciseType = 'Test')

	set @HomeWorkCoef =
	(select SUM(SE.Point) from [EJournal].StudentsExercises SE
	LEFT JOIN [EJournal].[Exercises] E on E.Id = SE.IdExercise
	where SE.IdStudent = @IdStudent and E.Deadline < GETDATE() and E.ExerciseType = 'HomeWork')/
	(select COUNT(IdExercise) from [EJournal].StudentsExercises SE
	LEFT JOIN [EJournal].[Exercises] E on E.Id = SE.IdExercise
	where SE.IdStudent = @IdStudent and E.Deadline < GETDATE() and E.ExerciseType = 'HomeWork')

	set @TeacherAssessmentCoef = 
	(SELECT TeacherAssessment from  [EJournal].[Students]
	where id = @IdStudent)

	set @Rating = @AttendanceCoef*0.15 + @TestCoef*0.2 + @HomeWorkCoef*0.25 + @TeacherAssessmentCoef*0.2

	update [EJournal].[Students]
	set Ranking = @Rating

	return @Rating