CREATE PROCEDURE [dbo].[DeleteStudent] @Id INT
AS
UPDATE [dbo].[Students]
SET IsDelete = 1
WHERE Id = @Id
