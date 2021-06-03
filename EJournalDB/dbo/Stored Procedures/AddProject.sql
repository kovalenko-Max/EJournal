CREATE PROCEDURE [dbo].[AddProject]
	@Name NVARCHAR(50)
	,@Description NVARCHAR(255)
AS
	INSERT INTO Projects (Name, Description)
	VALUES (@Name, @Description)
