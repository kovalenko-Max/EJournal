CREATE PROCEDURE AddGroup @Name NVARCHAR(100)
	,@IdCourse INT
AS
INSERT INTO Groups (
	Name
	,IdCourse
	)
VALUES (
	@Name
	,@IdCourse
	)

SELECT CAST(SCOPE_IDENTITY() AS INT)
