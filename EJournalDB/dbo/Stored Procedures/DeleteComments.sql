CREATE PROCEDURE [dbo].[DeleteComments] @Id INT
AS
UPDATE [EJournal].[Comments]
SET IsDelete = 1
WHERE Id = @Id
