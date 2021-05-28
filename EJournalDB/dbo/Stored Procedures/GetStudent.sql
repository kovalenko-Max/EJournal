CREATE PROCEDURE [dbo].[GetStudent]
 @Id INT 
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
  Where IsDelete=0 AND Id=@Id