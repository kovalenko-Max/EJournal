CREATE PROCEDURE [EJournal].[AddProject] 
	 @Name NVARCHAR(50)
	,@Description NVARCHAR(255)
AS
INSERT INTO [EJournal].[Projectes] (
	Name
	,Description
	)
VALUES (@Name,@Description
	)
	SELECT CAST(SCOPE_IDENTITY() AS INT)
