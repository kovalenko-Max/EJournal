CREATE PROCEDURE [EJournal].[GetComment] @Id INT
AS
SELECT Id
	,Comment
	,CommentType
	,CommentDate
FROM [EJournal].[Comments]
WHERE Id = @Id
