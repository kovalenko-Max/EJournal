CREATE PROCEDURE [EJournal].[UpdateCourse] @Id INT
	,@Name NVARCHAR(100)
AS
UPDATE [EJournal].[Courses]
SET Name = @Name
WHERE Id = @Id
