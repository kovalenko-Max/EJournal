CREATE PROCEDURE [dbo].[UpdateCourse] @Id INT
	,@Name NVARCHAR(100)
AS
UPDATE [dbo].[Courses]
SET Name = @Name
WHERE Id = @Id
