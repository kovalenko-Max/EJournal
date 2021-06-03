CREATE PROCEDURE [dbo].[GetStudentsCountByGroups]
AS
select
  G.Id
, G.Name
, G.IdCourse
, G.IsFinish
, COUNT(S.Name) StudentsCount

from [dbo].[Groups] G
left join [dbo].[GroupStudents] GS on G.Id = GS.IdGroup
Left join [dbo].Students S on S.Id = GS.IdStudents
Group By G.id, G.Name, G.IdCourse, G.IsFinish