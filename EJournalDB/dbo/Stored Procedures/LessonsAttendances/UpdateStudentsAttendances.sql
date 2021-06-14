CREATE PROCEDURE [EJournal].[UpdateStudentsAttendances]
	@StudentAttendance [EJournal].[StudentAttendance] READONLY,
    @Id int,
    @Topic nvarchar(250),
    @DateLesson datetime
AS
    update [EJournal].[Lessons]
    set DateLesson = @DateLesson, Topic = @Topic
    where Lessons.Id = @Id

	MERGE [EJournal].[Attendances] AS A
    USING @StudentAttendance AS SA
      ON SA.LessonsIds = A.IdLesson and SA.StudentId = A.IdStudent
     WHEN MATCHED THEN
       UPDATE SET A.IsPresence = SA.isPresense;
       