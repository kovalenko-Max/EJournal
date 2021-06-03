CREATE PROCEDURE UpdateExercise @Id INT
	,@Description NVARCHAR(255)
	,@Deadline DATETIME
	,@IdGroup INT
AS
UPDATE Exercises
SET Description = @Description
	,Deadline = @Deadline
	,IdGroup = @IdGroup
WHERE Id = @Id
