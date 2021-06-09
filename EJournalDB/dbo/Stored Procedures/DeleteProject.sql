CREATE PROCEDURE [dbo].[DeleteProject] @Id INT
AS
DELETE [dbo].[Projectes]
WHERE Id = @Id
