CREATE PROCEDURE [dbo].[GetLessonsByGroup]
	@groupId int
AS
	SELECT 
	   L.[Id]
      ,L.[IdGroup]
      ,L.[IdTeacher]
      ,L.[DateLesson]
      ,L.[Topic]
  FROM [EJournalDB].[dbo].[Lessons] L 
  join [EJournalDB].[dbo].[Groups] G on G.Id = L.IdGroup
  Where G.Id = @groupId
