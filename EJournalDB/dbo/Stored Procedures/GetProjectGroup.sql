CREATE PROCEDURE [dbo].[GetProjectGroup]
	@Id INT
AS
	SELECT [Id]
	,[Name]
	,[IdComments]
FROM ProjectGroups
WHERE IsDelete =0 AND Id = @Id
