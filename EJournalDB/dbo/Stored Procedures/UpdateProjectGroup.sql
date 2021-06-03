CREATE PROCEDURE [dbo].[UpdateProjectGroup]
	@Id INT
	,@Name NVARCHAR(100)
	, @IdProject Int
AS

	UPDATE [dbo].[ProjectGroups]
	SET Name = @Name
	,IdProject = @IdProject
	WHERE Id = @Id
