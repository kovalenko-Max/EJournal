CREATE PROCEDURE [dbo].[UpdateProjectGroup]
	@Id INT
	,@Name NVARCHAR(100)
	,@IdStudent INT
	, @IdComment Int
AS

	UPDATE ProjectGroups

SET Name = @Name
,IdStudent= @IdStudent
,IdComments = @IdComment
WHERE Id = @Id
