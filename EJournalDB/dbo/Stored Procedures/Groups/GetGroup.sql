CREATE PROCEDURE [EJournal].[GetGroup] @Id INT
AS
SELECT [Id]
	,[Name]
	,[IdCourse]
	,[IsFinish]
FROM [EJournal].[Groups]
WHERE Id = @Id
	AND IsDelete = 0
