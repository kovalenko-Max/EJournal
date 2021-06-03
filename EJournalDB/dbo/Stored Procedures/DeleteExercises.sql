CREATE PROCEDURE [dbo].[DeleteExercises] @Id INT
AS
UPDATE [dbo].[Exercises]
SET IsDelete = 1
WHERE Id = @Id
