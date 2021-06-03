CREATE PROCEDURE [dbo].[GetProjectGroup]
	@Id INT
AS
	SELECT [Id]
	,[Name]
	,[IdComments]
FROM [dbo].[ProjectGroups]
WHERE IsDelete =0 AND Id = @Id
