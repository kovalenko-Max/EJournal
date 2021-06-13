CREATE PROCEDURE [EJournal].[AddExercises] @Description NVARCHAR(255)
	,@Deadline DATETIME
	,@IdGroup INT
AS
INSERT INTO [EJournal].[Exercises] (
	Description
	,Deadline
	,IdGroup
	)
VALUES (
	@Description
	,@Deadline
	,@IdGroup
	)
