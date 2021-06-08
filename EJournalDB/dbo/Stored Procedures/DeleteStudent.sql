CREATE PROCEDURE [dbo].[DeleteStudent] @Id INT
AS
UPDATE [EJournal].[Students]
SET IsDelete = 1
WHERE Id = @Id
