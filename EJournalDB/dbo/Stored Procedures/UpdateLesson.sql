CREATE PROCEDURE [dbo].[UpdateLesson] @Id INT
	,@Topic NVARCHAR(250)
	,@DateLesson DATETIME
	,@IdGroup INT
	,@IdTeacher INT
AS
UPDATE [dbo].[Lessons]
SET Topic = @Topic
	,DateLesson = @DateLesson
	,IdGroup = @IdGroup
	,IdTeacher = @IdTeacher
WHERE Id = @Id
