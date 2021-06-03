CREATE PROCEDURE [dbo].[UpdateProject]
	@Id INT
	,@Name NVARCHAR(50)
	,@Description NVARCHAR(255)
AS
	UPDATE Projects
	SET Name=@Name
	,Description =@Description
	Where Id = @Id