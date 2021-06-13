CREATE PROCEDURE [EJournal].[DeleteProject] @Id INT
AS
UPDATE [EJournal].[Projectes]
SET IsDelete = 1
WHERE Id = @Id
