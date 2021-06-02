CREATE PROCEDURE [dbo].[GetStudentsCountByGroups]
AS
select
  G.Id
, G.Name
, G.IdCourse
, G.IsFinish
, COUNT(S.Name) StudentsCount

from [EJournalDB].[dbo].[Groups] G
left join [EJournalDB].[dbo].[GroupStudents] GS on G.Id = GS.IdGroup
Left join [EJournalDB].[dbo].Students S on S.Id = GS.IdStudents
WHERE S.IsDelete = 0
Group By G.id, G.Name, G.IdCourse, G.IsFinish