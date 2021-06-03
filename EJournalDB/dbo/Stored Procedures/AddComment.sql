CREATE PROCEDURE [dbo].[AddComment] @Comments NVARCHAR(255)
	,@IdTeacher INT
	,@IdCommentType INT
AS
INSERT INTO [dbo].[Comments] (
	Comment
	,IdTeacher
	,IdCommentType
	)
VALUES (
	@Comments
	,@IdTeacher
	,@IdCommentType
	)
