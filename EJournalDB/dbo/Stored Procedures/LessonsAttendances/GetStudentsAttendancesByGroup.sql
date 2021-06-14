CREATE PROCEDURE [EJournal].[GetStudentsAttendancesByGroup]
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
  FROM [EJournal].[Lessons] L 
  join [EJournal].[Groups] G on G.Id = L.IdGroup
  left join [EJournal].Attendances A on A.IdLesson = L.Id
  left join [EJournal].Students S on A.IdStudent = S.Id
  where G.Id = @GroupId
  order by L.DateLesson desc