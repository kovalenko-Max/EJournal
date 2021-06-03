CREATE PROCEDURE [dbo].[UpdateProjectGroup] @Id INT
	,@Name NVARCHAR(100)
	,@IdProject INT
AS
UPDATE [dbo].[ProjectGroups]
SET Name = @Name
	,IdProject = @IdProject
WHERE Id = @Id
