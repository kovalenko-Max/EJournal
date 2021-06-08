CREATE PROCEDURE [EJournal].[GetComment] @Id INT
AS
SELECT Id
	,Comment
	,IdCommentType
FROM [EJournal].[Comments]
WHERE IsDelete = 0
	AND Id = @Id
