CREATE PROCEDURE [dbo].[AddProjectGroup]
	@Name NVARCHAR(100)
	, @IdProject Int
AS
	INSERT INTO ProjectGroups ( Name, IdProject)
VALUES (@Name, @IdProject)