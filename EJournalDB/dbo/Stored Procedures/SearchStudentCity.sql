﻿CREATE PROCEDURE [EJournal].[SearchStudentCity]
@City NVARCHAR(100)
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
	AND City = @City