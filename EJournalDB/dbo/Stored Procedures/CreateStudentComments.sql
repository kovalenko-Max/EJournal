CREATE PROCEDURE [EJournal].[CreateStudentComments]
    @IdCommentType INT,
    @Comment nvarchar(255),
	@StudentCommentVarible as [EJournal].[StudentsComment] READONLY
AS
	DECLARE @IdComment INT
	DECLARE @StudentsComment as [EJournal].[StudentsComment]

	Insert into @StudentsComment
	Select *
	from @StudentCommentVarible 

    Insert INTO [EJournal].Comments( Comment, IdCommentType  )
    Values(@Comment,@IdCommentType )

	Set @IdComment= SCOPE_IDENTITY()

	Update @StudentsComment 
	Set IdComment=@IdComment

	InSERT INTO [EJournal].StudentsComments(IdStudent, IdComment)
 Select IdStudent, IdComment
 from @StudentsComment

 return @IdComment
