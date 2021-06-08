CREATE PROCEDURE [dbo].[GetAllExercises]
AS
SELECT [Id]
	,[Description]
	,[Deadline]
	,[IdGroup]
FROM [EJournal].[Exercises]
WHERE IsDelete = 0
