CREATE PROCEDURE [EJournal].[GetExercisesByGroup]
	@IdGroup int
AS
	SELECT 
		E.Id
	,E.Description
	,E.Deadline
    ,E.IdGroup
    ,E.ExerciseType

	,S.Id IdStudent
	,S.Name
	,S.Surname
	,SE.Point
    ,SE.IdExercise

	From [EJournal].Exercises E
	inner join [EJournal].[Groups] G on G.Id = E.IdGroup
	left join [EJournal].StudentsExercises SE on E.Id = SE.IdExercise
	left join [EJournal].Students S on SE.IdStudent = S.Id
	where G.Id = @IdGroup
	order by E.Deadline