CREATE PROCEDURE [dbo].[GetAllCourses]
AS
SELECT [Id]
	,[Name]
FROM [EJournal].[Courses]
WHERE IsDelete = 0
