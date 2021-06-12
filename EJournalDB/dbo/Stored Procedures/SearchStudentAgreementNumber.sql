CREATE PROCEDURE [EJournal].[SearchStudentAgreementNumber]
@AgreementNumber NVARCHAR(50)
AS
	SELECT [Id]
	,[Name]
	,[Surname]
	,[Email]
	,[Phone]
	,[Git]
	,[City]
	,[Ranking]
	,[AgreementNumber]
FROM [EJournal].[Students]
WHERE IsDelete = 0
	AND AgreementNumber = @AgreementNumber