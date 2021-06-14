CREATE PROCEDURE [EJournal].[AddLesson] @Topic NVARCHAR(250)
	,@DateLesson DATETIME
	,@IdGroup INT
AS
INSERT INTO [EJournal].[Lessons] (
	Topic
	,DateLesson
	,IdGroup
	)
VALUES (
	@Topic
	,Cast(@DateLesson as Datetime)
	,@IdGroup
	)
