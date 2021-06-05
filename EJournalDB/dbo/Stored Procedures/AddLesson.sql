CREATE PROCEDURE [dbo].[AddLesson] @Topic NVARCHAR(250)
	,@DateLesson DATETIME
	,@IdGroup INT
AS
INSERT INTO [dbo].[Lessons] (
	Topic
	,DateLesson
	,IdGroup
	)
VALUES (
	@Topic
	,Cast(@DateLesson as Datetime)
	,@IdGroup
	)
