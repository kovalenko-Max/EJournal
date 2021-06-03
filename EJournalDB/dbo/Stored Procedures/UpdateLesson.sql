CREATE PROCEDURE [dbo].[UpdateLesson]
	@Id int,
	@Topic NVARCHAR(250) ,
	@DateLesson datetime,
	@IdGroup int,
	@IdTeacher int
AS
	UPDATE Lessons

   SET Topic= @Topic
   , DateLesson= @DateLesson
   , IdGroup= @IdGroup
   , IdTeacher = @IdTeacher
   Where Id=@Id