CREATE PROCEDURE [dbo].[AddExercises] @Description NVARCHAR(255)
	,@Deadline DATETIME
	,@IdGroup INT
AS
INSERT INTO [dbo].[Exercises] (
	Description
	,Deadline
	,IdGroup
	)
VALUES (
	@Description
	,@Deadline
	,@IdGroup
	)
