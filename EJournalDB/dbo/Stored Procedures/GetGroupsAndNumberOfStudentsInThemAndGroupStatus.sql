CREATE PROCEDURE [EJournal].[GetGroupsAndNumberOfStudentsInThemAndGroupStatus]
AS
SELECT GS.IdGroup
	,G.Name
	,COUNT(*) NumberOfStudents
	,G.IsFinish
FROM [EJournal].[GroupStudents] GS
INNER JOIN [EJournal].[Groups] G ON GS.IdGroup = G.Id
GROUP BY GS.IdGroup
	,G.Name
	,G.IsFinish
