CREATE PROCEDURE [dbo].[AddTeacher] @Name NVARCHAR(100)
	,@Surname NVARCHAR(100)
AS
INSERT INTO [dbo].[Teachers] (
	Name
	,Surname
	)
VALUES (
	@Name
	,@Surname
	)
