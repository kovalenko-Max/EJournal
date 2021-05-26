CREATE PROCEDURE [dbo].[AddComment]
	@Comments NVARCHAR(255) ,
	@IdStudent int,
	@IdTeacher int,
	@IdCommentType int
AS
	INSERT INTO Comments (Comment, IdStudent, IdTeacher, IdCommentType)
	VALUES (@Comments, @IdStudent, @IdTeacher, @IdCommentType)