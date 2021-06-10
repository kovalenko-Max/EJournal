CREATE PROCEDURE [dbo].[DeleteCommentType] @Id INT
AS
DELETE dbo.CommentTypes
WHERE Id = @Id
