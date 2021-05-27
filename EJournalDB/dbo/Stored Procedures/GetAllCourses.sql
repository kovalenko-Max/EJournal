CREATE PROCEDURE [GetAllCourses] 
   AS
   SELECT  [Id]
      ,[Name]
  FROM [EJournalDB].[dbo].[Courses]
  where IsDelete = 0