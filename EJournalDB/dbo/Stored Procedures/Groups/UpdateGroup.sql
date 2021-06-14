CREATE PROCEDURE [EJournal].[UpdateGroup] @Id INT
	,@Name NVARCHAR(100)
	,@IdCourse INT
AS
UPDATE [EJournal].[Groups]
SET Name = @Name
	,IdCourse = @IdCourse
WHERE Id = @Id
