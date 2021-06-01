CREATE PROCEDURE [dbo].[HardDeleteStudent]
@Id INT
AS
DELETE [dbo].[Students]
WHERE Id = @Id