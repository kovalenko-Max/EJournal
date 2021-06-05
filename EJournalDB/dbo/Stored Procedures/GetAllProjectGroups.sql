CREATE PROCEDURE [dbo].[GetAllProjectGroups] @IdProject INT
AS
SELECT pg.[Id]
	,pg.[Name]
FROM ProjectGroups pg
INNER JOIN Projectes p ON p.Id = pg.IdProject
WHERE pg.IsDelete = 0
	AND p.Id = @IdProject
