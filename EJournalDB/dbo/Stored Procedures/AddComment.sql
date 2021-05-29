CREATE PROCEDURE [dbo].[AddComment]
	@Comments NVARCHAR(255) ,
	@IdTeacher int,
	@IdCommentType int
AS
	INSERT INTO Comments (Comment, IdTeacher, IdCommentType)
	VALUES (@Comments, @IdTeacher, @IdCommentType)