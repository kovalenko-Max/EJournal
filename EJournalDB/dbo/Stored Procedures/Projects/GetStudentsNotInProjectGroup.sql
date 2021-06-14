CREATE PROCEDURE [EJournal].[GetStudentsNotInProjectGroup] @IdProjectGroup INT
AS
SELECT Distinct s.Id
	,s.Name
	,s.Surname
	,s.Phone
	,s.Email
	,s.Git
	,s.City
	,s.Ranking
	,s.TeacherAssessment
	,s.AgreementNumber
	,s.IsDelete
FROM [EJournal].[Students] AS s
where S.IsDelete = 0 and Id not in 
(SELECT IdStudent FROM [EJournal].StudetsProjectGroup
Where IdProjectGroup=@IdProjectGroup)
order by S.Name
