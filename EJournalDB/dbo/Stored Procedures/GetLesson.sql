CREATE PROCEDURE [dbo].[GetLesson] @Id INT
AS
SELECT [Id]
	,[Topic]
	,[DateLesson]
	,[IdGroup]
FROM [EJournal].[Lessons]
WHERE Id = @Id
