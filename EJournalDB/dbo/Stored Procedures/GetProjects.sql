CREATE PROCEDURE [dbo].[GetProjects]
	
AS
	SELECT Id
	,Name
	,IdProjectCroup
FROM Projects
WHERE IsDelete =0
