CREATE PROCEDURE [dbo].[UpdateGroup] @Id INT
	,@Name NVARCHAR(100)
	,@IdCourse INT
AS
UPDATE [dbo].[Groups]
SET Name = @Name
	,IdCourse = @IdCourse
WHERE Id = @Id
