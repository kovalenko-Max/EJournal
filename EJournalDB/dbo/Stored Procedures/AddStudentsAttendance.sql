CREATE PROCEDURE [dbo].[AddStudentsAttendance]
	@Topic nvarchar(250),
	@DateLesson datetime, 
	@IdGroup int
	
AS
	declare @IdLesson int

	insert into Lessons (Topic, DateLesson, IdGroup)
	values(@Topic, @DateLesson, @IdGroup)
	SET @IdLesson = SCOPE_IDENTITY()

