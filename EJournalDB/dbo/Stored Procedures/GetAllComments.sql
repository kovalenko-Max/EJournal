CREATE PROCEDURE [dbo].[GetAllComments]
AS
SELECT Id
	,Comment
	,IdCommentType
FROM [dbo].[Comments]
WHERE IsDelete = 0
