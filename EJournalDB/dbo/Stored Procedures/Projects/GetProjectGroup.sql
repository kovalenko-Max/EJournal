CREATE PROCEDURE [EJournal].[GetProjectGroup] @Id INT
AS
SELECT [Id]
	,[Name]
	,[Mark]
FROM [EJournal].[ProjectGroups]
WHERE  Id = @Id
