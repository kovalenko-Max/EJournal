CREATE PROCEDURE [EJournal].[DeleteStudent] @Id INT
AS
UPDATE [EJournal].[Students]
SET IsDelete = 1
WHERE Id = @Id
