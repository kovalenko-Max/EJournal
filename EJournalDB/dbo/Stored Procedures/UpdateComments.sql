CREATE PROCEDURE [dbo].[UpdateComments]
	@Id int,
	@Comments NVARCHAR(255) ,
	@IdStudent int,
	@IdTeacher int,
	@IdCommentType int
AS
	UPDATE Comments

   SET Comment= @Comments
   , IdStudent= @IdStudent
   , IdTeacher= @IdTeacher
   , IdCommentType = @IdCommentType
   Where Id=@Id