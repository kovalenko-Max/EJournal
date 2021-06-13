CREATE PROCEDURE [EJournal].[AddProjectGroup] @Name NVARCHAR(100)
	,@IdProject INT
AS
INSERT INTO [EJournal].[ProjectGroups] (
	Name
	,IdProject
	)
VALUES (
	@Name
	,@IdProject
	)

SELECT CAST(SCOPE_IDENTITY() AS INT)
