CREATE PROCEDURE [dbo].[GetStudentsByGroup]
@IdGroup INT
AS
SELECT [dbo].[Groups].[Id]
,[dbo].[Students].[Id]
,[dbo].[Students].[Name]
,[dbo].[Students].[Surname]
,[dbo].[Students].[Email]
,[dbo].[Students].[Phone]
,[dbo].[Students].[Git]
,[dbo].[Students].[AgreementNumber]
FROM [dbo].[GroupStudents]
INNER JOIN [dbo].[Groups] ON [dbo].[Groups].[Id] = [dbo].[GroupStudents].[IdGroup]
INNER JOIN [dbo].[Students] ON [dbo].[Students].[Id] = [dbo].[GroupStudents].[IdStudents]
WHERE [dbo].[Groups].[Id] = @IdGroup