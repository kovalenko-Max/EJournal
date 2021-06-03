CREATE PROCEDURE [dbo].[GetProjects]
AS
SELECT Id
	,Name
	,Description
FROM [dbo].[Projectes]
WHERE IsDelete = 0
