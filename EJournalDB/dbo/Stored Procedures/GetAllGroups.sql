CREATE PROCEDURE [dbo].[GetAllGroups]
AS
SELECT [Id]
	,[Name]
	,[IdCourse]
	,[IsFinish]
FROM.[dbo].[Groups]
WHERE IsDelete = 0
