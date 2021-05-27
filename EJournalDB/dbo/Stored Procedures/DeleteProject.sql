CREATE PROCEDURE [dbo].[DeleteProject]
	@Id INT
AS
	 UPDATE Projects
  SET IsDelete=1
  WHERE Id=@Id
