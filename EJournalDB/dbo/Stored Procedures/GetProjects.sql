CREATE PROCEDURE [dbo].[GetProjects]
	
AS
	SELECT 
	Name
	,Desription

FROM Projects
WHERE IsDelete =0
