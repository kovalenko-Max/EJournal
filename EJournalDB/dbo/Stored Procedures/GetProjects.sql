CREATE PROCEDURE [dbo].[GetProjects]
AS
SELECT Id
	,Name
	,Description
FROM [EJournal].[Projectes]
WHERE IsDelete = 0
