CREATE PROCEDURE [dbo].[GetStudent]
 @Id INT 
AS
	SELECT [Id]
      ,[Name]
      ,[Surname]
      ,[Email]
      ,[Phone]
      ,[Git]
      ,[AgreementNumber]
  FROM [Students]
  Where IsDelete=0 AND Id=@Id