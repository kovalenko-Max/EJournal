CREATE PROCEDURE [dbo].[GetAttendancesByGroup]
	@GroupId int
AS
	SELECT 
	   L.[Id] LessonId
	  ,L.DateLesson
	  ,S.Id StudentId
      ,S.Name
      ,S.Surname
      ,A.IsPresence
  FROM [EJournalDB].[dbo].[Lessons] L 
  join [EJournalDB].[dbo].[Groups] G on G.Id = L.IdGroup
  join ( select 
	S.Id
	,S.Name
   ,S.Surname
   ,GS.IdGroup
	from GroupStudents GS
	inner join Students S on S.Id = GS.IdStudents
	) S on S.IdGroup = G.Id
 join Attendances A on A.IdStudent = S.Id
 Where G.Id = @GroupId