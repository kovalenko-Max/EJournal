CREATE PROCEDURE [dbo].[UpdateProject] @Id INT
	,@Name NVARCHAR(50)
	,@Description NVARCHAR(255)
	--,@ChekUpdate BIT OUTPUT
AS
UPDATE [dbo].[Projectes]
SET Name = @Name
	,Description = @Description
WHERE Id = @Id

--SELECT @ChekUpdate = @@ROWCOUNT
