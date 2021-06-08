CREATE PROCEDURE [dbo].[UpdateProjectGroup] @Id INT
	,@Name NVARCHAR(100)
	,@IdProject INT
AS
UPDATE [EJournal].[ProjectGroups]
SET Name = @Name
	,IdProject = @IdProject
WHERE Id = @Id