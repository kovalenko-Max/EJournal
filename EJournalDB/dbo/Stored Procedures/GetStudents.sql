CREATE PROCEDURE [dbo].[GetStudents]
AS
	SELECT [Id]
      ,[Name]
      ,[Surname]
      ,[Email]
      ,[Phone]
      ,[Git]
      ,[AgreementNumber]
  FROM [Students]
  Where IsDelete=0