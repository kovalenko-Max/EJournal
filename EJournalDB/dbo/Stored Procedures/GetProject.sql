CREATE PROCEDURE [dbo].[GetProject] @Id INT
AS
SELECT [Name]
	,[Description]
FROM [EJournal].[Projectes]
WHERE IsDelete = 0
	AND Id = @Id
