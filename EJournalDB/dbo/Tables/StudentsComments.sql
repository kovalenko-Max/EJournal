CREATE TABLE [dbo].[StudentsComments]
(    [IdComment] INT NOT NULL,
	 [IdStudent] INT NOT NULL,
	 CONSTRAINT [StudentsComments_Comments_Id] FOREIGN KEY ([IdComment]) REFERENCES [dbo].[Comments] ([Id]),
     CONSTRAINT [StudentsComments_Students_Id] FOREIGN KEY ([IdStudent]) REFERENCES [dbo].[Students] ([Id])
);
