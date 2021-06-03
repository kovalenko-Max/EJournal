CREATE PROCEDURE [dbo].[UpdateLessonAttendances]
	@LessonsIds as dbo.LessonsIds READONLY
AS
	SELECT *
	from Lessons
	where Id in @LessonsIds