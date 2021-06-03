CREATE PROCEDURE [dbo].[DeleteProjectGroup]
	@Id INT
AS
	 UPDATE ProjectGroups
  SET IsDelete=1
  WHERE Id=@Id