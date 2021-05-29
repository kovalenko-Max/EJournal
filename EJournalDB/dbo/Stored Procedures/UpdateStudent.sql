CREATE PROCEDURE [dbo].[UpdateStudent]
	@Id INT ,
   @Name NVARCHAR (100) ,
   @Surname NVARCHAR(100),
   @Email NVARCHAR (100) ,
   @Phone NVARCHAR(16) ,
   @Git NVARCHAR(100) = NULL,
   @City NVARCHAR(100)  NULL,
   @Ranking INT ,
   @IdComment INT NULL,
   @IdProjectGroup INT NULL,
   @AgreementNumber NVARCHAR(50)
AS
	UPDATE Students

   SET Name = @Name,
   Surname = @Surname,
   Email = @Email,
   Phone =@Phone,
   Git =@Git,
   City=@City,
   Ranking=@Ranking,
   IdComment = @IdComment,
   IdProjectGroup= @IdProjectGroup,
  AgreementNumber =@AgreementNumber
   Where Id=@Id