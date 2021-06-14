CREATE PROCEDURE DeleteStudentFromProjectGroup @IdStudent INT
	,@IdProjectGroup INT
AS
DELETE [dbo].StudetsProjectGroup
WHERE IdStudent = @IdStudent
	AND IdProjectGroup = @IdProjectGroup
