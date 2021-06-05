CREATE PROCEDURE [dbo].[GetProjectGroup] @Id INT
AS
SELECT [Id]
	,[Name]
FROM [dbo].[ProjectGroups]
WHERE IsDelete = 0
	AND Id = @Id
