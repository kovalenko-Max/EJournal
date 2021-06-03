CREATE PROCEDURE [dbo].[GetGroup] @Id INT
AS
SELECT [Id]
	,[Name]
	,[IdCourse]
	,[IsFinish]
FROM [dbo].[Groups]
WHERE Id = @Id
	AND IsDelete = 0
