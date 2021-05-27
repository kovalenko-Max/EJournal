 CREATE PROCEDURE DeleteStudent
   @Id INT 
   AS
  UPDATE Students
  SET IsDelete=1
  WHERE Id=@Id