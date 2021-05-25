CREATE TABLE [dbo].[GroupTeachers] (
    [IdTeacher] INT NOT NULL,
    [IdGroup]   INT NOT NULL,
    CONSTRAINT [GroupTeachers_fk0] FOREIGN KEY ([IdTeacher]) REFERENCES [dbo].[Teachers] ([Id]),
    CONSTRAINT [GroupTeachers_fk1] FOREIGN KEY ([IdGroup]) REFERENCES [dbo].[Groups] ([Id])
);

