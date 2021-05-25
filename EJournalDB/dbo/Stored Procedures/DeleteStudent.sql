CREATE PROCEDURE [dbo].[DeleteStudent]
   @Id int
   AS
   update Students
   set IsDelete = 1 
   where Id = @id