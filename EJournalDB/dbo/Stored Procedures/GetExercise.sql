CREATE PROCEDURE [dbo].[GetExercise] @Id INT
AS
SELECT [Id]
	,[Description]
	,[Deadline]
	,[IdGroup]
FROM [dbo].[Exercises]
WHERE Id = @Id
	AND IsDelete = 0
