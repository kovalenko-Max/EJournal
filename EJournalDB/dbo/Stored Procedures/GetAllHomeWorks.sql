CREATE PROCEDURE GetAllHomeWorks
   AS
   SELECT  [Id]
      ,[SRS]
      ,[Deadline]
      ,[IdGroup]
  FROM [AcademyDB].[dbo].[HomeWorks]
  where IsDelete = 0