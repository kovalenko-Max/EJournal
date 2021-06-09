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
left JOIN [EJournal].[GroupStudents] GS on GS.IdStudents <> S.Id
where S.IsDelete = 0 and GS.IdGroup = @IdGroup