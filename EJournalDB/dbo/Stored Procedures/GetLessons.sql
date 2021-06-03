CREATE PROCEDURE [dbo].[GetLessons]
AS
SELECT [Id]
	,[Topic]
	,[DateLesson]
	,[IdGroup]
	,[IdTeacher]
FROM [dbo].[Lessons]
WHERE IsDelete = 0
