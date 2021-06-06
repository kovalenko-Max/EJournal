CREATE PROCEDURE [dbo].[GetLessonsByGroup]
	@groupId int
AS
	SELECT 
	   L.[Id]
      ,L.[IdGroup]
      ,L.[DateLesson]
      ,L.[Topic]
  FROM [dbo].[Lessons] L 
  join [dbo].[Groups] G on G.Id = L.IdGroup
  Where G.Id = @groupId