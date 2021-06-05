CREATE PROCEDURE [dbo].[AddComment] @Comments NVARCHAR(255)
	,@CommentType NVARCHAR(255)
AS
INSERT INTO [dbo].[Comments] (
	Comment
	,CommentType
	)
VALUES (
	@Comments
	,@CommentType
	)
