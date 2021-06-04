CREATE PROCEDURE [dbo].[AddProjectGroup] @Name NVARCHAR(100)
	,@IdProject INT
AS
INSERT INTO [dbo].[ProjectGroups] (
	Name
	,IdProject
	,IdComments
	)
VALUES (
	@Name
	,@IdProject
	,1
	)

SELECT CAST(SCOPE_IDENTITY() AS INT)
