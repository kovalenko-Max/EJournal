CREATE PROCEDURE [dbo].[GetProject] @Id INT
AS
SELECT [Name]
	,[Description]
FROM [dbo].[Projectes]
WHERE IsDelete = 0
	AND Id = @Id
