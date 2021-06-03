CREATE PROCEDURE [dbo].[GetLessons]
AS
SELECT [Id]
,[Topic]
,[DateLesson]
,[IdGroup]
,[IdTeacher]
FROM [Lessons]
WHERE IsDelete=0