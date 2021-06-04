CREATE PROCEDURE [dbo].[DeleteComments] @Id INT
AS
UPDATE [dbo].[Comments]
SET IsDelete = 1
WHERE Id = @Id
