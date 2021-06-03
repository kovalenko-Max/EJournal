CREATE PROCEDURE [dbo].[AddProjectGroup]
	@Name NVARCHAR(100)
	, @IdComments Int
AS
	INSERT INTO ProjectGroups ( Name, IdComments)
VALUES (@Name, @IdComments)
