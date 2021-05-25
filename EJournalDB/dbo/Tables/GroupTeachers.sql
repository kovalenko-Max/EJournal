CREATE TABLE [dbo].[GroupTeachers] (
    [IdTeacher] INT NOT NULL,
    [IdGroup]   INT NOT NULL,
    CONSTRAINT [GroupTeachers_Teachers_Id] FOREIGN KEY ([IdTeacher]) REFERENCES [dbo].[Teachers] ([Id]),
    CONSTRAINT [GroupTeachers_Groups_Id] FOREIGN KEY ([IdGroup]) REFERENCES [dbo].[Groups] ([Id])
);
