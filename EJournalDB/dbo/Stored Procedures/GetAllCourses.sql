CREATE PROCEDURE [GetAllCourses] 
   AS
   SELECT  [Id]
      ,[Name]
  FROM [dbo].[Courses]
  where IsDelete = 0