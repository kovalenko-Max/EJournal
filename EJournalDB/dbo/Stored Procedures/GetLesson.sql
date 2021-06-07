CREATE PROCEDURE [dbo].[GetLesson] @Id INT
AS
SELECT [Id]
	,[Topic]
	,[DateLesson]
	,[IdGroup]
FROM [dbo].[Lessons]
WHERE Id = @Id
