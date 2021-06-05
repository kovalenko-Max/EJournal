CREATE PROCEDURE [dbo].[AddProjectGroup] @Name NVARCHAR(100)
	,@IdProject INT
AS
INSERT INTO [dbo].[ProjectGroups] (
	Name
	,IdProject
	)
VALUES (
	@Name
	,@IdProject
	)

SELECT CAST(SCOPE_IDENTITY() AS INT)
