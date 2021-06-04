CREATE PROCEDURE [dbo].[CreateAttendence]
AS
SELECT DISTINCT IdLesson
	,L.Topic
	,L.DateLesson
	,IsPresence
	,IdStudent
	,S.Name
FROM [dbo].[Attendances] A
INNER JOIN (
	SELECT Id
		,DateLesson
		,Topic
	FROM Lessons
	) AS L ON A.IdLesson = L.Id
INNER JOIN (
	SELECT Id
		,(Name + Surname) AS Name
	FROM Students
	) AS S ON A.IdStudent = S.Id
ORDER BY IdLesson
