CREATE PROCEDURE [dbo].[UpdateComment] @Id INT
	,@Comments NVARCHAR(255)
	,@IdCommentType INT
AS
UPDATE [dbo].[Comments]
SET Comment = @Comments
	,IdCommentType = @IdCommentType
WHERE Id = @Id
