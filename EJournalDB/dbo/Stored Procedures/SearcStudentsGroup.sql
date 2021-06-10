CREATE PROCEDURE [dbo].[SearcStudentsGroup]
	@Name NVARCHAR(50)
AS
SELECT
     s.[Id]
	,s.[Name]
	,s.[Surname]
	,s.[Email]
	,s.[Phone]
	,s.[Git]
	,s.[City]
	,s.[Ranking]
	,s.[AgreementNumber]
FROM [dbo].[Students] s
LEFT JOIN [dbo].[GroupStudents] GS on GS.IdGroup = S.Id
LEFT JOIN [dbo].[Groups] G on G.Id = GS.IdGroup
WHERE S.IsDelete = 0
	AND G.Name = @Name