CREATE PROCEDURE [EJournal].[GetCourse] @Id INT
AS
SELECT [Id]
	,[Name]
FROM [EJournal].[Courses]
WHERE Id = @Id
	AND isDelete = 0
