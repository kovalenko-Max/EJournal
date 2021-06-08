CREATE PROCEDURE [EJournal].[AddGroup] @Name NVARCHAR(100)
	,@IdCourse INT
AS
INSERT INTO [EJournal].[Groups] (
	Name
	,IdCourse
	)
VALUES (
	@Name
	,@IdCourse
	)

SELECT CAST(SCOPE_IDENTITY() AS INT)
