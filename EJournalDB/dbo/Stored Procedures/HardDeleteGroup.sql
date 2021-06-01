CREATE PROCEDURE [dbo].[HardDeleteGroup]
@Id INT
AS
DELETE [dbo].[Groups]
WHERE Id = @Id