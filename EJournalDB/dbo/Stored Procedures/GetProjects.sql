CREATE PROCEDURE GetProjects
AS
Select Id, Name, Description
From Projectes
Where IsDelete = 0