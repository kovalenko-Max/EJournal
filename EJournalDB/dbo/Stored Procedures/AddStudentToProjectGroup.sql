CREATE PROCEDURE AddStudentToProjectGroup @IdStudent INT
	,@IdProjectGroup INT
AS
INSERT INTO [EJournal].StudetsProjectGroup (
	IdStudent
	,IdProjectGroup
	)
VALUES (
	@IdStudent
	,@IdProjectGroup
	)
