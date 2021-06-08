CREATE PROCEDURE [EJournal].[GetAllComments]
AS
SELECT Id
	,Comment
	,IdCommentType
FROM [EJournal].[Comments]
WHERE IsDelete = 0
