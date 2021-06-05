CREATE PROCEDURE [dbo].[DeleteLessonAndAttendances] @Id INT
AS
UPDATE [dbo].[Lessons]
SET IsDelete = 1
WHERE Id = @Id
