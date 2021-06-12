CREATE PROCEDURE [EJournal].[AddComment] @Comments NVARCHAR(255)
	,@IdCommentType nvarchar(100)
AS
INSERT INTO [EJournal].[Comments] (
	[EJournal].[Comments].[Comment]
	,[EJournal].[Comments].[CommentType]
	)
VALUES (
	 @Comments
	,@IdCommentType
	)
