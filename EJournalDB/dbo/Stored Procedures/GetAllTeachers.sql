CREATE PROCEDURE GetAllTeachers
   AS
   SELECT  [Id]
      ,[Name]
  FROM [dbo].[Teachers]
  where IsDelete = 0