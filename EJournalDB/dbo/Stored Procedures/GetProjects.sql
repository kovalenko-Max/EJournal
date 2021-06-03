CREATE PROCEDURE [dbo].[GetProjects]
AS
SELECT Id
	,Name
	,Description
FROM [dbo].[Projects]
WHERE IsDelete = 0
