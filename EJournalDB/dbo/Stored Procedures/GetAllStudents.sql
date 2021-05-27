CREATE PROCEDURE GetAllStudents
   AS
   SELECT [Id]
      ,[Name]
      ,[Surname]
      ,[Email]
      ,[Phone]
      ,[Git]
      ,[AgreementNumber]
  FROM [EJournalDB].[dbo].[Students]
  where IsDelete = 0