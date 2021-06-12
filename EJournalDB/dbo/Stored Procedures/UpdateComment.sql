CREATE PROCEDURE [dbo].[UpdateComment] @Id INT
	,@Comment NVARCHAR(255)
	,@IdCommentType INT
AS
UPDATE [dbo].[Comments]
SET Comment = @Comment
	,IdCommentType = @IdCommentType
WHERE Id = @Id
