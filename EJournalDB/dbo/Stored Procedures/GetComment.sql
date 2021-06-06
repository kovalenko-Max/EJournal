CREATE PROCEDURE [dbo].[GetComment] @Id INT
AS
SELECT Id
	,Comment
	,CommentType
FROM [dbo].[Comments]
WHERE IsDelete = 0
	AND Id = @Id
