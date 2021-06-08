CREATE PROCEDURE [EJournal].[GetAllProjectGroups] @IdProject INT
AS
SELECT pg.[Id]
	,pg.[Name]
FROM [EJournal].ProjectGroups pg
INNER JOIN [EJournal].Projectes p ON p.Id = pg.IdProject
WHERE pg.IsDelete = 0
	AND p.Id = @IdProject
