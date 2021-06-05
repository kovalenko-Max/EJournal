CREATE PROCEDURE [dbo].[UpdateLessonAttendances]
	@StudentAttendance [dbo].[StudentAttendance] READONLY,
    @Id int,
    @Topic nvarchar,
    @DateLesson datetime
AS
    update Lessons
    set DateLesson = @DateLesson, Topic = @Topic
    where Lessons.Id = @Id

	MERGE dbo.Attendances AS A
    USING @StudentAttendance AS SA
      ON SA.LessonsIds = A.IdLesson and SA.StudentId = A.IdStudent
     WHEN MATCHED THEN
       UPDATE SET A.IsPresence = SA.isPresense;
       