CREATE PROCEDURE [dbo].[GetProjectGroups]
	
AS
		SELECT Id
	,Name
	,IdComments
FROM ProjectGroups
WHERE IsDelete =0
