CREATE PROCEDURE [dbo].[GetProject] @Id INT
AS
SELECT [Name]
	,[Description]
FROM [dbo].[Projects]
WHERE IsDelete = 0
	AND Id = @Id
