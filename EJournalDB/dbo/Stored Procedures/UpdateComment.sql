CREATE PROCEDURE [dbo].[UpdateComment]
	@Id int,
	@Comments NVARCHAR(255) ,
	@IdTeacher int,
	@IdCommentType int
AS
	UPDATE [dbo].[Comments]

   SET Comment= @Comments
   , IdTeacher= @IdTeacher
   , IdCommentType = @IdCommentType
   Where Id=@Id