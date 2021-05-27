CREATE PROCEDURE [dbo].[UpdateStudents]
	@Id INT ,
   @Name NVARCHAR (100) ,
   @Surname NVARCHAR(100),
   @Email NVARCHAR (100) ,
   @Phone NVARCHAR(16) ,
   @Git NVARCHAR(100) = NULL,
   @AgreementNumber NVARCHAR(50)
AS
	UPDATE Students

   SET Name = @Name,
   Surname = @Surname,
   Email = @Email,
   Phone =@Phone,
   Git =@Git,
  AgreementNumber =@AgreementNumber
   Where Id=@Id