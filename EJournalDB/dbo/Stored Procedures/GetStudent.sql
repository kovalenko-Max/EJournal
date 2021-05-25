   CREATE PROCEDURE [dbo].[GetStudent] 
   @Id int 
   AS
   SELECT [Id]
      ,[Name]
      ,[Surname]
      ,[Email]
      ,[Phone]
      ,[Git]
      ,[AgreementNumber]
  FROM [AcademyDB].[dbo].[Students]
  where Id = @Id and IsDelete = 0