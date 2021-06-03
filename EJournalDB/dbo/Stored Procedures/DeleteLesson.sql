CREATE PROCEDURE [dbo].[DeleteLesson] @Id INT
AS
UPDATE [dbo].[Lessons]
SET IsDelete = 1
WHERE Id = @Id
