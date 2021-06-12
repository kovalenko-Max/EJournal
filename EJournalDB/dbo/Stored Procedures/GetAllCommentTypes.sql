CREATE PROCEDURE [dbo].[GetAllCommentTypes]
AS
SELECT Id
	,Type
FROM dbo.CommentTypes
