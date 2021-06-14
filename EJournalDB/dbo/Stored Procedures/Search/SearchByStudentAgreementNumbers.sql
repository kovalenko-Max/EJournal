CREATE PROCEDURE [EJournal].[SearchByStudentAgreementNumbers]
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
	AND [AgreementNumber] like ('%' + LTRIM(RTRIM(@AgreementNumber))+ '%')