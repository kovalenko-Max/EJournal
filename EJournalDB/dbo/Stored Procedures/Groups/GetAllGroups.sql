CREATE PROCEDURE [EJournal].[GetAllGroups]
AS
SELECT G.Id
	,G.Name
	,COUNT(S.Id) StudentsCount
	,C.Id
	,C.Name
	,G.IsFinish
FROM [EJournal].[Groups] G
left join [EJournal].Courses C on C.Id = G.IdCourse
LEFT JOIN [EJournal].[GroupStudents] GS ON G.Id = GS.IdGroup
left JOIN 
( select S.Id from [EJournal].Students S
where S.IsDelete = 0
) S on S.Id = GS.IdStudents
where G.IsDelete = 0 
GROUP BY G.id
	,G.Name
	,C.Id
	,G.IsFinish
	,C.Name