CREATE PROCEDURE [dbo].[GetAllGroups]
AS
SELECT G.Id
	,G.Name
	,COUNT(S.Id) StudentsCount
	,C.Id
	,C.Name
	,G.IsFinish
FROM [dbo].[Groups] G
left join [dbo].Courses C on C.Id = G.IdCourse
LEFT JOIN [dbo].[GroupStudents] GS ON G.Id = GS.IdGroup
left JOIN [dbo].Students S ON S.Id = GS.IdStudents
where G.IsDelete = 0
GROUP BY G.id
	,G.Name
	,C.Id
	,G.IsFinish
	,C.Name