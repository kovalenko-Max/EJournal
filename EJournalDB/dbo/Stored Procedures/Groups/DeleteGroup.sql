CREATE PROCEDURE [dbo].[DeleteGroup] @Id INT
AS
UPDATE [dbo].[Groups]
SET IsDelete = 1
WHERE Id = @Id
