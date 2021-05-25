CREATE PROCEDURE [dbo].[GetLesson]
		@Id INT
AS
	SELECT Id,
	Topic
	,DateLesson
	,IdGroup
	,IdTeacher
FROM Lessons
WHERE IsDelete=0 AND Id=@Id
