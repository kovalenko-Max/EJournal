CREATE PROCEDURE [GetAllCourses] 
   AS
   SELECT  [Id]
      ,[Name]
  FROM [AcademyDB].[dbo].[Courses]
  where IsDelete = 0