CREATE PROCEDURE [dbo].[GetAllProjectGroups]
AS
SELECT [Id]
	,[Name]
	,[IdComments]
FROM ProjectGroups
WHERE IsDelete = 0
