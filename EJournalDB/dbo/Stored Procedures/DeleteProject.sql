CREATE PROCEDURE [dbo].[DeleteProject] @Id INT
AS
UPDATE [dbo].[Projects]
SET IsDelete = 1
WHERE Id = @Id
