CREATE PROCEDURE [dbo].[GetAllExercises]
AS
SELECT [Id]
	,[Description]
	,[Deadline]
	,[IdGroup]
FROM [dbo].[Exercises]
WHERE IsDelete = 0
