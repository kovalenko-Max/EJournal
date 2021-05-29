CREATE PROCEDURE [dbo].[AddStudent] 
   @Name NVARCHAR (100) ,
   @Surname NVARCHAR(100),
   @Email NVARCHAR(100) ,
   @Phone NVARCHAR(16) ,
   @Git NVARCHAR(100) NULL,
   @City NVARCHAR(100)  NULL,
   @Ranking INT ,
   @IdComment INT NULL,
   @IdProjectGroup INT NULL,
   @AgreementNumber NVARCHAR(50)
   , @Id INT output
   AS
   INSERT INTO Students(Name, Surname, Email, Phone, Git, City, Ranking,IdComment, IdProjectGroup, AgreementNumber)
   VALUES (@Name, @Surname, @Email, @Phone, @Git, @City, @Ranking, @IdComment, @IdProjectGroup, @AgreementNumber)

   