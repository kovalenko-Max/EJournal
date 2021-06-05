CREATE PROCEDURE [dbo].[UpdateComment] @Id INT
	,@Comments NVARCHAR(255)
	,@CommentType NVARCHAR(255)
AS
UPDATE [dbo].[Comments]
SET Comment = @Comments
	,CommentType = @CommentType
WHERE Id = @Id
