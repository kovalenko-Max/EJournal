CREATE PROCEDURE [EJournal].[GetAllGroupsWithCourses]
AS
SELECT c.Id
	,c.Name
	,g.Id
	,g.Name
	,g.IsFinish
FROM [EJournal].[Courses] c
INNER JOIN [EJournal].[Groups] g ON g.IdCourse = c.Id
