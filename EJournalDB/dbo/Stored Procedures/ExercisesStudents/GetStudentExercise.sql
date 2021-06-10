CREATE PROCEDURE [EJournal].[GetStudentExercise]
	@GroupId int
AS
	SELECT 
	E.Id
	,E.Deadline
	,E.Description
	,S.Id IdStudent
	,S.Name
	,S.Surname
	,SE.Points

	From [EJournal].Exercises E
	inner join [EJournal].[Groups] G on G.Id = E.IdGroup
	left join [EJournal].StudentsExercises SE on E.Id = SE.IdExercise
	left join [EJournal].Students S on SE.IdStudents = S.Id
	where G.Id= @GroupId

