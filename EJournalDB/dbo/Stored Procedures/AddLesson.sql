CREATE PROCEDURE [dbo].[AddLesson] @Topic NVARCHAR(250)
	,@DateLesson DATETIME
	,@IdGroup INT
	,@IdTeacher INT
AS
INSERT INTO [dbo].[Lessons] (
	Topic
	,DateLesson
	,IdGroup
	,IdTeacher
	)
VALUES (
	@Topic
	,@DateLesson
	,@IdGroup
	,@IdTeacher
	)
