CREATE PROCEDURE GetAllStudents
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
  FROM [dbo].[Students]
  where IsDelete = 0