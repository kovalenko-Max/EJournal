CREATE PROCEDURE [dbo].[AddCommentToEachStudentFromProjectGroup] @Comment NVARCHAR(255)
	,@IdStudent INT
AS
DECLARE @IdComment INT

INSERT INTO [dbo].Comments (
	Comment
	,CommentType
	)
VALUES (
	@Comment
	,'Work in project'
	)

SET @IdComment = @@IDENTITY

INSERT INTO [dbo].StudentsComments (
	IdStudent
	,IdComment
	)
VALUES (
	@IdStudent
	,@IdComment
	)
