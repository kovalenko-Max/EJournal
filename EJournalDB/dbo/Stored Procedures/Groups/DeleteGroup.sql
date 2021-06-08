CREATE PROCEDURE [EJournal].[DeleteGroup] @Id INT
AS
UPDATE [EJournal].[Groups]
SET IsDelete = 1
WHERE Id = @Id
