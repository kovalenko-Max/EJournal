CREATE PROCEDURE [dbo].[DeleteLessonAndAttendances] @Id INT
AS
delete Attendances
where IdLesson = @Id
delete Lessons
WHERE Id = @Id
