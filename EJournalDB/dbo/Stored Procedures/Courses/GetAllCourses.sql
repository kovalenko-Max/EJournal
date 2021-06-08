CREATE PROCEDURE [EJournal].[GetAllCourses]
AS
SELECT [Id]
	,[Name]
FROM [EJournal].[Courses]
WHERE IsDelete = 0
