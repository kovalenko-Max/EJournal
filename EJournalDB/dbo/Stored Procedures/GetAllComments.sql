CREATE PROCEDURE [dbo].[GetAllComments]
AS
SELECT Id
	,Comment
	,CommentType
FROM [dbo].[Comments]
WHERE IsDelete = 0
