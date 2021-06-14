CREATE PROCEDURE [EJournal].[DeleteLessonAndStudentsAttendances] @Id INT
AS
delete [EJournal].Attendances
where IdLesson = @Id
delete [EJournal].Lessons
WHERE Id = @Id
