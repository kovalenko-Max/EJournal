CREATE PROCEDURE [dbo].[GetAllCourses]
AS
SELECT [Id]
	,[Name]
FROM [dbo].[Courses]
WHERE IsDelete = 0
