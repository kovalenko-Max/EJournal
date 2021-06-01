CREATE PROCEDURE [dbo].[HardDeleteProject]
@Id INT
AS
DELETE [dbo].[Projects]
WHERE Id = @Id