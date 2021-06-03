CREATE PROCEDURE [dbo].[GetCourse] @Id INT
AS
SELECT [Id]
	,[Name]
FROM [dbo].[Courses]
WHERE Id = @Id
	AND isDelete = 0
