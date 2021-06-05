CREATE PROCEDURE [dbo].[UpdateLessonAttendances]
	@LessonsIds [dbo].[LessonsIds] READONLY
AS
	MERGE dbo.Attendances AS A
    USING @LessonsIds AS LIds
      ON LIds.LessonsIds = A.IdLesson and LIds.StudentId = A.IdStudent
     WHEN MATCHED THEN
       UPDATE SET A.IsPresence = LIds.isPresense;
       