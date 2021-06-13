CREATE PROCEDURE [EJournal].[UpdateComment] @Id INT
	,@Comments NVARCHAR(255)
	,@CommentType nvarchar(100)
AS
UPDATE [EJournal].[Comments]
SET Comment = @Comments
	,CommentType = @CommentType
WHERE Id = @Id
