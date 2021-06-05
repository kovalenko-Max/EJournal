CREATE PROCEDURE [dbo].[AddStudentsAttendance]
	@Topic nvarchar(250),
	@DateLesson datetime, 
	@IdGroup int,
	@StudentAttendanceVariable as [dbo].[StudentAttendance] READONLY
AS
	declare @IdLesson int
	declare @StudentAttendance as [dbo].[StudentAttendance]

	insert into @StudentAttendance
	select *
	from @StudentAttendanceVariable

	insert into Lessons (Topic, DateLesson, IdGroup)
	values(@Topic, @DateLesson, @IdGroup)
	SET @IdLesson = SCOPE_IDENTITY()

	update @StudentAttendance
	set LessonsIds = @IdLesson

	insert into [dbo].[Attendances](IdLesson, IdStudent, IsPresence)
	select LessonsIds, StudentId, isPresense
	from @StudentAttendance
	
