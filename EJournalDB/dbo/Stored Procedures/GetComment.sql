CREATE PROCEDURE [EJournal].[GetComment] @Id INT
AS
SELECT Id
	,Comment
	,CommentType
FROM [EJournal].[Comments]
WHERE IsDelete = 0
	AND Id = @Id
