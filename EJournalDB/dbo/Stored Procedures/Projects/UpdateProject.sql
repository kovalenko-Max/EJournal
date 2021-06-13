CREATE PROCEDURE [EJournal].[UpdateProject] @Id INT
	,@Name NVARCHAR(50)
	,@Description NVARCHAR(255)
AS
UPDATE [EJournal].[Projectes]
SET Name = @Name
	,Description = @Description
WHERE Id = @Id