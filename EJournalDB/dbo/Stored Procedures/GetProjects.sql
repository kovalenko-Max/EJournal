CREATE PROCEDURE [dbo].[GetProjects]
AS
Select Id, Name, Description
From [dbo].[Projectes]
Where IsDelete = 0