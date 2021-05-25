CREATE PROCEDURE [dbo].[UpdateProject]
	@Id INT
	,@Name NVARCHAR(50)
	,@Description NVARCHAR(255)
	,@IdProjectGroup INT
AS
	UPDATE Projects
	SET Name=@Name
	,Description =@Description
	,IdProjectGroup=@IdProjectGroup
	Where Id = @Id