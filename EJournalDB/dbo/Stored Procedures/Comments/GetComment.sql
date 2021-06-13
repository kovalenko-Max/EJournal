CREATE PROCEDURE [EJournal].[GetComment] @Id INT
AS
SELECT Id
	,Comment
	,CommentType
FROM [EJournal].[Comments]
WHERE Id = @Id
