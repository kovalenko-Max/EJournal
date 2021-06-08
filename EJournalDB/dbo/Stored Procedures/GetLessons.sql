CREATE PROCEDURE [EJournal].[GetLessons]
AS
SELECT [Id]
	,[Topic]
	,[DateLesson]
	,[IdGroup]
FROM [EJournal].[Lessons]