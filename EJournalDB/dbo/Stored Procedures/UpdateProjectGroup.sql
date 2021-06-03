CREATE PROCEDURE [dbo].[UpdateProjectGroup]
	@Id INT
	,@Name NVARCHAR(100)
	, @IdProject Int
AS

	UPDATE ProjectGroups

SET Name = @Name
,IdProject = @IdProject
WHERE Id = @Id