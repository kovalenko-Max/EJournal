CREATE PROCEDURE [dbo].[HardDeleteComment]
@Id INT
AS
DELETE [dbo].[Comments]
WHERE Id = @Id