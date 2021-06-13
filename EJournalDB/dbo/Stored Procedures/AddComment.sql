CREATE PROCEDURE [EJournal].[AddComment] 
	@IdStudent int,
	@Comments NVARCHAR(255),
	@CommentType nvarchar(100),
	@CommentDate DATETIME
AS

declare @IdComment int

INSERT INTO [EJournal].[Comments] (
	[EJournal].[Comments].[Comment]
	,[EJournal].[Comments].[CommentType]
	,[EJournal].[Comments].[CommentDate]
	)
VALUES (
	 @Comments
	,@CommentType
	,@CommentDate
	)
	SET @IdComment = SCOPE_IDENTITY()

	insert into [EJournal].[StudentsComments] (IdComment, IdStudent)
	values(@IdComment, @IdStudent)

	return @IdComment;