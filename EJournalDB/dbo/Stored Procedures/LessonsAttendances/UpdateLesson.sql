CREATE PROCEDURE [EJournal].[UpdateLesson] @Id INT
	,@Topic NVARCHAR(250)
	,@DateLesson DATETIME
	,@IdGroup INT
AS
UPDATE [EJournal].[Lessons]
SET Topic = @Topic
	,DateLesson = @DateLesson
	,IdGroup = @IdGroup
WHERE Id = @Id
