CREATE PROCEDURE [dbo].[GetAllComments]
AS
SELECT Id
	,Comment
	,IdCommentType
FROM [EJournal].[Comments]
WHERE IsDelete = 0
