CREATE PROCEDURE GetAllStudents
   AS
   SELECT [Id]
      ,[Name]
      ,[Surname]
      ,[Email]
      ,[Phone]
      ,[Git]
      ,[AgreementNumber]
  FROM [AcademyDB].[dbo].[Students]
  where IsDelete = 0