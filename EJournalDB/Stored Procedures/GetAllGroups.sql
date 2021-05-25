CREATE PROCEDURE GetAllGroups
   AS
   SELECT  [Id]
      ,[Name]
      ,[IdCourse]
      ,[IsFinish]
  FROM [AcademyDB].[dbo].[Groups]
  where IsDelete = 0