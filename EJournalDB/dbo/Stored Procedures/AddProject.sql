CREATE PROCEDURE [dbo].[AddProject]
	@Name NVARCHAR(50)
	,@Description NVARCHAR(255)
	,@IdProjectGroup INT
AS
	INSERT INTO Projects (Name, Description, IdProjectCroup)
	VALUES (@Name, @Description, @IdProjectGroup)
