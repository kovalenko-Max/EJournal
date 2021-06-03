CREATE PROCEDURE [dbo].[UpdateProjectGroup]
	@Id INT
	,@Name NVARCHAR(100)
	, @IdComment Int
AS

	UPDATE ProjectGroups

SET Name = @Name
,IdComments = @IdComment
WHERE Id = @Id
