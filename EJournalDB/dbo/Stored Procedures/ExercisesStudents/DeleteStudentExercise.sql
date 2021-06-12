CREATE PROCEDURE [EJournal].[DeleteStudentExercise]
@Id int
AS
	delete [EJournal].StudentsExercises
	where IdExercise = @Id
	delete [EJournal].Exercises
	where Id = @Id
