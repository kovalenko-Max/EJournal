CREATE PROCEDURE GetAllTeachers
   AS
   SELECT  [Id]
      ,[Name]
  FROM [AcademyDB].[dbo].[Teachers]
  where IsDelete = 0