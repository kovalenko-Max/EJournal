CREATE PROCEDURE [EJournal].[AddStudent] @Name NVARCHAR(100)
	,@Surname NVARCHAR(100)
	,@Email NVARCHAR(100)
	,@Phone NVARCHAR(16)
	,@Git NVARCHAR(100) = NULL
	,@City NVARCHAR(MAX)
	,@Ranking INT
	,@AgreementNumber NVARCHAR(50)
AS
INSERT INTO [EJournal].[Students] (
	Name
	,Surname
	,Email
	,Phone
	,Git
	,City
	,Ranking
	,AgreementNumber
	)
VALUES (
	@Name
	,@Surname
	,@Email
	,@Phone
	,@Git
	,@City
	,@Ranking
	,@AgreementNumber
	)
	SELECT CAST(SCOPE_IDENTITY() AS INT)
