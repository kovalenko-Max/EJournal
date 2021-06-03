CREATE PROCEDURE [dbo].[DeleteProject]
	@Id INT
AS
	 UPDATE [dbo].[Projectes]
  SET IsDelete=1
  WHERE Id=@Id
