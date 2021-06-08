CREATE PROCEDURE [dbo].[AddComment] @Comments NVARCHAR(255)
	,@IdCommentType INT
AS
INSERT INTO [EJournal].[Comments] (
	Comment
	,IdCommentType
	)
VALUES (
	@Comments
	,@IdCommentType
	)
