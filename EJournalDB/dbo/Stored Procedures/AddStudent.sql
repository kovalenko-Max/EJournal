CREATE PROCEDURE [dbo].[AddStudent] 
   @Name NVARCHAR (100) ,
   @Surname NVARCHAR(100),
   @Email NVARCHAR(100) ,
   @Phone NVARCHAR(16) ,
   @Git NVARCHAR(100) = NULL,
   @AgreementNumber NVARCHAR(50)
   AS
   INSERT INTO Students(Name, Surname, Email, Phone, Git, AgreementNumber)
   VALUES (@Name, @Surname, @Email, @Phone, @Git, @AgreementNumber)