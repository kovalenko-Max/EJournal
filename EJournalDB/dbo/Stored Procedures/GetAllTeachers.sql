CREATE PROCEDURE GetAllTeachers
   AS
   SELECT  [Id]
      ,[Name]
  FROM [EJournalDB].[dbo].[Teachers]
  where IsDelete = 0