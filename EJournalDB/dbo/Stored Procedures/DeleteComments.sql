CREATE PROCEDURE [dbo].[DeleteComments]
	  @Id INT 
   AS
  UPDATE Comments
  SET IsDelete=1
  WHERE Id=@Id
