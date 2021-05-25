CREATE PROCEDURE [dbo].[GetProjectGroups]
	
AS
		SELECT Id
	,Name
	,IdStudent
	,IdComments
FROM ProjectGroups
WHERE IsDelete =0
