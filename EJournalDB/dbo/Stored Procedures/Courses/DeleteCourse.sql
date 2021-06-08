CREATE PROCEDURE [dbo].[DeleteCourse] @Id INT
AS
UPDATE [dbo].[Courses]
SET IsDelete = 1
WHERE Id = @Id
