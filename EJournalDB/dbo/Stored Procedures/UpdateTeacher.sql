CREATE PROCEDURE [dbo].[UpdateTeacher] @Id INT
	,@Name NVARCHAR(100)
	,@Surname NVARCHAR(100)
AS
UPDATE [dbo].[Teachers]
SET Name = @Name
	,Surname = @Surname
WHERE Id = @Id
