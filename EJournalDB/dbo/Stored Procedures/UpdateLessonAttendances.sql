CREATE PROCEDURE [dbo].[UpdateLessonAttendances]
	@StudentAttendance [dbo].[StudentAttendance] READONLY
AS
	MERGE dbo.Attendances AS A
    USING @StudentAttendance AS SA
      ON SA.LessonsIds = A.IdLesson and SA.StudentId = A.IdStudent
     WHEN MATCHED THEN
       UPDATE SET A.IsPresence = SA.isPresense;
       