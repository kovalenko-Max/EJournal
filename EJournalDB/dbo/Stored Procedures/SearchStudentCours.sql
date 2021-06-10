CREATE PROCEDURE [dbo].[SearchStudentCours]
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
LEFT JOIN [dbo].[Courses] C on C.Id = G.IdCourse
WHERE S.IsDelete = 0
	AND C.Name = @Name
