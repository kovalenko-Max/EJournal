CREATE PROCEDURE [dbo].[DeleteProjectGroup] @Id INT
AS
DELETE [dbo].[ProjectGroups]
WHERE Id = @Id
