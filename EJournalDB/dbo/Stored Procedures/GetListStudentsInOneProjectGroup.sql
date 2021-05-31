CREATE PROCEDURE  GetListStudentsInOneProjectGroup
@IdProjectGroup INT
AS
Select pg.Id as ProjectGroupID, pg.Name, pg.IdComments
,s.Id , s.Name, s.Surname, s.Phone, s.Email, s.Git, s.City, s.Ranking, s.AgreementNumber, s.IsDelete
FROM StudetsProjectGroup AS spg
INNER JOIN ProjectGroups pg  ON pg.Id=spg.IdProjectGroup
INNER JOIN Students AS s ON spg.IdStudent = s.Id
Where spg.IdProjectGroup=@IdProjectGroup

