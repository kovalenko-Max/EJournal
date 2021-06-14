CREATE PROCEDURE [EJournal].[UpdateStudent] @Id INT
	,@Name NVARCHAR(100)
	,@Surname NVARCHAR(100)
	,@Email NVARCHAR(100)
	,@Phone NVARCHAR(16)
	,@Git NVARCHAR(100) = NULL
	,@City NVARCHAR(100) NULL
	,@TeacherAssessment int
	,@AgreementNumber NVARCHAR(50)
AS
UPDATE [EJournal].[Students]
SET Name = @Name
	,Surname = @Surname
	,Email = @Email
	,Phone = @Phone
	,Git = @Git
	,City = @City
	,TeacherAssessment = @TeacherAssessment
	,AgreementNumber = @AgreementNumber
WHERE Id = @Id
