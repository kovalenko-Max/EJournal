CREATE PROCEDURE [EJournal].[GetAllProjects]
AS
SELECT Id
	,Name
	,Description
FROM [EJournal].[Projectes]
WHERE IsDelete = 0
