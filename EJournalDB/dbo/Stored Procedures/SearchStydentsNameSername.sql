﻿CREATE PROCEDURE [EJournal].[SearchStydentsNameSername]
@Name NVARCHAR(100)
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
	AND Name = @Name 