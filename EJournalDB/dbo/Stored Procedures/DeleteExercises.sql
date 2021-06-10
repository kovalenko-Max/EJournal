CREATE PROCEDURE [EJournal].[DeleteExercises] @Id INT
AS
UPDATE [EJournal].[Exercises]
SET IsDelete = 1
WHERE Id = @Id
