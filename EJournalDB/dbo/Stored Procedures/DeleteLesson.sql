CREATE PROCEDURE [dbo].[DeleteLesson]
	  @Id INT 
   AS
  UPDATE Lessons
  SET IsDelete=1
  WHERE Id=@Id