CREATE PROCEDURE [dbo].[GetGroupsAndNumberOfStudentsInThemAndGroupStatus]
AS
SELECT GS.IdGroup, G.Name, COUNT(*) NumberOfStudents, G.IsFinish
FROM dbo.GroupStudents GS
INNER JOIN dbo.Groups G ON GS.IdGroup = G.Id
GROUP BY GS.IdGroup, G.Name, G.IsFinish