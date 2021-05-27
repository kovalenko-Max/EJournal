CREATE PROCEDURE GetAllGroups
   AS
   SELECT  [Id]
      ,[Name]
      ,[IdCourse]
      ,[IsFinish]
  FROM [EJournalDB].[dbo].[Groups]
  where IsDelete = 0