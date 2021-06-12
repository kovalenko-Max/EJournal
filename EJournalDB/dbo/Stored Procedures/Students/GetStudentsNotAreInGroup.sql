CREATE PROCEDURE [EJournal].[GetStudentsNotAreInGroup]
	@IdGroup int
AS
	SELECT
S.[Id]
,S.[Name]
,S.[Surname]
,S.[Email]
,S.[Phone]
,S.[Git]
,S.[City]
,S.[Ranking]
,S.[AgreementNumber]

from [EJournal].[Students] S
where S.IsDelete = 0 and Id not in  
(select IdStudents from [EJournal].GroupStudents
where IdGroup = @IdGroup)
order by S.Name