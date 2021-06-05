CREATE PROCEDURE [dbo].[GetLessons]
AS
SELECT [Id]
	,[Topic]
	,[DateLesson]
	,[IdGroup]
FROM [dbo].[Lessons]
WHERE IsDelete = 0
