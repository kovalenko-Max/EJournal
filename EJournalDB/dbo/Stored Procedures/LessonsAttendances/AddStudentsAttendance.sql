CREATE PROCEDURE [EJournal].[AddStudentsAttendance]
	@Topic nvarchar(250),
	@DateLesson datetime, 
	@IdGroup int,
	@StudentAttendanceVariable as [EJournal].[StudentAttendance] READONLY

AS
	declare @IdLesson int
	declare @StudentAttendance as [EJournal].[StudentAttendance]

	insert into @StudentAttendance
	select *
	from @StudentAttendanceVariable

	insert into [EJournal].Lessons (Topic, DateLesson, IdGroup)
	values(@Topic, @DateLesson, @IdGroup)
	SET @IdLesson = SCOPE_IDENTITY()
	
	update @StudentAttendance
	set LessonsIds = @IdLesson

	insert into [EJournal].[Attendances](IdLesson, IdStudent, IsPresence)
	select LessonsIds, StudentId, isPresense
	from @StudentAttendance

	return @IdLesson