CREATE PROCEDURE AddStudentToProjectGroup @IdStudent INT
	,@IdProjectGroup INT
AS
INSERT INTO [dbo].StudetsProjectGroup (
	IdStudent
	,IdProjectGroup
	)
VALUES (
	@IdStudent
	,@IdProjectGroup
	)
