CREATE PROCEDURE [dbo].[DeleteProjectGroup] @Id INT
AS
UPDATE [dbo].[ProjectGroups]
SET IsDelete = 1
WHERE Id = @Id
