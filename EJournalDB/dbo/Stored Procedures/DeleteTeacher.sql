CREATE PROCEDURE [dbo].[DeleteTeacher] @Id INT
AS
UPDATE [dbo].[Teachers]
SET IsDelete = 1
WHERE Id = @Id
