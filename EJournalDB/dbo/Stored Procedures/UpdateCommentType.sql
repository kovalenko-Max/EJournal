CREATE PROCEDURE [dbo].[UpdateCommentType] @Id INT
	,@Type NVARCHAR(255)
AS
UPDATE dbo.CommentTypes
SET Type = @Type
WHERE Id = @Id
