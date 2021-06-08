CREATE PROCEDURE [dbo].[GetExercise] @Id INT
AS
SELECT [Id]
	,[Description]
	,[Deadline]
	,[IdGroup]
FROM [EJournal].[Exercises]
WHERE Id = @Id
	AND IsDelete = 0
