CREATE PROCEDURE [dbo].[GetListStudentsInOneProjectGroup] @IdProjectGroup INT
AS
SELECT s.Id
	,s.Name
	,s.Surname
	,s.Phone
	,s.Email
	,s.Git
	,s.City
	,s.Ranking
	,s.AgreementNumber
	,s.IsDelete
FROM [EJournal].[StudetsProjectGroup] AS spg
INNER JOIN [EJournal].[ProjectGroups] pg ON pg.Id = spg.IdProjectGroup
INNER JOIN [EJournal].[Students] AS s ON spg.IdStudent = s.Id
WHERE spg.IdProjectGroup = @IdProjectGroup
