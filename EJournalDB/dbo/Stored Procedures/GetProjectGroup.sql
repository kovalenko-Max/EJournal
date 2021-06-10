CREATE PROCEDURE [EJournal].[GetProjectGroup] @Id INT
AS
SELECT [Id]
	,[Name]
FROM [EJournal].[ProjectGroups]
WHERE IsDelete = 0
	AND Id = @Id
