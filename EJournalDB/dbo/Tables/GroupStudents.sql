CREATE TABLE [dbo].[GroupStudents] (
    [IdGroup]    INT NOT NULL,
    [IdStudents] INT NOT NULL,
    CONSTRAINT [GroupStudents_fk0] FOREIGN KEY ([IdGroup]) REFERENCES [dbo].[Groups] ([Id]),
    CONSTRAINT [GroupStudents_fk1] FOREIGN KEY ([IdStudents]) REFERENCES [dbo].[Students] ([Id])
);

