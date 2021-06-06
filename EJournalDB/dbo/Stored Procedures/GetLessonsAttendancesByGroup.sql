CREATE PROCEDURE [dbo].[GetLessonsAttendancesByGroup]
	@GroupId int
AS
	SELECT 
L.[Id]
,L.DateLesson
,L.Topic
,S.Id IdStudent
,S.Name
,S.Surname
,A.IsPresence
  FROM[dbo].[Lessons] L 
  join [dbo].[Groups] G on G.Id = L.IdGroup
  join [dbo].Attendances A on A.IdLesson = L.Id
  join [dbo].Students S on A.IdStudent = S.Id
  where G.Id = @GroupId
  order by L.Id