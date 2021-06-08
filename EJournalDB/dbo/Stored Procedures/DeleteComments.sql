CREATE PROCEDURE [EJournal].[DeleteComments] @Id INT
AS
UPDATE [EJournal].[Comments]
SET IsDelete = 1
WHERE Id = @Id
