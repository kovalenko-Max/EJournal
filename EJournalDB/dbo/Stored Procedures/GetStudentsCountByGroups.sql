CREATE PROCEDURE [dbo].[GetStudentsCountByGroups]
AS
SELECT G.Id
	,G.Name
	,G.IdCourse
	,G.IsFinish
	,COUNT(S.Name) StudentsCount
FROM [dbo].[Groups] G
LEFT JOIN [dbo].[GroupStudents] GS ON G.Id = GS.IdGroup
LEFT JOIN [dbo].Students S ON S.Id = GS.IdStudents

GROUP BY G.id
	,G.Name
	,G.IdCourse
	,G.IsFinish