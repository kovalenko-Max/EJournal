CREATE PROCEDURE [dbo].[UpdateProject]
	@Id INT
	,@Name NVARCHAR(50)
	,@Description NVARCHAR(255)
	,@ChekUpdate BIT OUTPUT
AS
	UPDATE Projectes
	SET Name=@Name
	,Description =@Description
	Where Id = @Id
	SELECT @ChekUpdate = @@ROWCOUNT