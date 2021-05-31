CREATE PROCEDURE  GetListStudentsInOneProjectGroup
@IdProjectGroup INT
AS
Select pg.ProjectId, pg.ProjectName, pg.Id as ProjectGroupID, pg.Name, pg.IdComments
,s.Id as StudentID , s.Name, s.Surname, s.Phone, s.Email, s.Git, s.City, s.Ranking, s.AgreementNumber, s.IsDelete
FROM StudetsProjectGroup AS spg
INNER JOIN (Select p.Id as ProjectId, p.Name as ProjectName, pg.Id, pg.Name, pg.IdComments From ProjectGroups pg
INNER JOIN Projectes AS p ON p.Id=pg.IdProject) pg  ON pg.Id=spg.IdProjectGroup
INNER JOIN Students AS s ON spg.IdStudent = s.Id
Where spg.IdProjectGroup=@IdProjectGroup

