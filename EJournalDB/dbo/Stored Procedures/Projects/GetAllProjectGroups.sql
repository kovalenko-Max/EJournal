CREATE PROCEDURE [EJournal].[GetAllProjectGroups] @IdProject INT
AS
SELECT pg.[Id]
	,pg.[Name]
	,pg.Mark
FROM [EJournal].ProjectGroups pg
INNER JOIN [EJournal].Projectes p ON p.Id = pg.IdProject
WHERE p.Id = @IdProject
