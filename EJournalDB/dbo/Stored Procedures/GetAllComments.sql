CREATE PROCEDURE [EJournal].[GetAllComments]
AS
SELECT Id
	,Comment
	,CommentType
FROM [EJournal].[Comments]
WHERE IsDelete = 0
