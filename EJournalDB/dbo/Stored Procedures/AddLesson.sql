CREATE PROCEDURE [dbo].[AddLesson]
	@Topic NVARCHAR(250) ,
	@DateLesson datetime,
	@IdGroup int,
	@IdTeacher int
AS
	INSERT INTO Lessons(Topic, DateLesson, IdGroup, IdTeacher)
	VALUES (@Topic, @DateLesson, @IdGroup, @IdTeacher)