CREATE PROCEDURE [dbo].[HardDeleteCourse]
@Id INT
AS
DELETE [dbo].[Courses]
WHERE Id = @Id