CREATE PROCEDURE [EJournal].[GetListStudentsNotInTheConcreeteProjectGroup] @IdProjectGroup INT
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
FROM [EJournal].[Students] AS s
left join  [EJournal].StudetsProjectGroup AS spg On s.Id=spg.IdStudent
where spg.IdProjectGroup <> @IdProjectGroup or spg.IdProjectGroup is NULL
