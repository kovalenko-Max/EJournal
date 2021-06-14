CREATE PROCEDURE [dbo].[GetCommentType] @Id INT
AS
SELECT Id
	,Type
FROM dbo.CommentTypes
WHERE Id = @Id
