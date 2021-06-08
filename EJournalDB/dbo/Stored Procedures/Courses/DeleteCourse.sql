CREATE PROCEDURE [dbo].[DeleteCourse] @Id INT
AS
UPDATE [EJournal].[Courses]
SET IsDelete = 1
WHERE Id = @Id
