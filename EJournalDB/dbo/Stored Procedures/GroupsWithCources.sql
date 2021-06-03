CREATE PROCEDURE [dbo].[GroupsWithCources]
AS
SELECT c.Id
	,c.Name
	,g.Id
	,g.Name
	,g.IsFinish
FROM [dbo].[Courses] c
INNER JOIN [dbo].[Groups] g ON g.IdCourse = c.Id
