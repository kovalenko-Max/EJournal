CREATE PROCEDURE [dbo].[AddProjectGroup]
	@Name NVARCHAR(100)
	,@IdStudent INT
	, @IdComments Int
AS
	INSERT INTO ProjectGroups ( Name, IdStudent, IdComments)
VALUES (@Name, @IdStudent, @IdComments)
