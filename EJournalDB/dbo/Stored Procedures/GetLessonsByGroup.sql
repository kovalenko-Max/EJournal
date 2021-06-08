CREATE PROCEDURE [EJournal].[GetLessonsByGroup]
	@groupId int
AS
	SELECT 
	   L.[Id]
      ,L.[IdGroup]
      ,L.[DateLesson]
      ,L.[Topic]
  FROM [EJournal].[Lessons] L 
  join [EJournal].[Groups] G on G.Id = L.IdGroup
  Where G.Id = @groupId