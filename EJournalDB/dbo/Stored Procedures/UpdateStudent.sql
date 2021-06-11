CREATE PROCEDURE [EJournal].[UpdateStudent] @Id INT
	,@Name NVARCHAR(100)
	,@Surname NVARCHAR(100)
	,@Email NVARCHAR(100)
	,@Phone NVARCHAR(16)
	,@Git NVARCHAR(100) = NULL
	,@City NVARCHAR(100) NULL
	,@Ranking INT
	,@AgreementNumber NVARCHAR(50)
AS
UPDATE [EJournal].[Students]
SET Name = @Name
	,Surname = @Surname
	,Email = @Email
	,Phone = @Phone
	,Git = @Git
	,City = @City
	,Ranking = @Ranking
	,AgreementNumber = @AgreementNumber
WHERE Id = @Id
