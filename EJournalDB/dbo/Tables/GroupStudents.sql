CREATE TABLE [dbo].[GroupStudents] (
    [IdGroup]    INT NOT NULL,
    [IdStudents] INT NOT NULL,
    CONSTRAINT [GroupStudents_Groups_Id] FOREIGN KEY ([IdGroup]) REFERENCES [dbo].[Groups] ([Id]),
    CONSTRAINT [GroupStudents_Students_Id] FOREIGN KEY ([IdStudents]) REFERENCES [dbo].[Students] ([Id])
);

