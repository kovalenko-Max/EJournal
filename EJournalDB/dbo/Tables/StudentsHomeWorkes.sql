CREATE TABLE [dbo].[StudentsHomeWorkes] (
    [IdHomeWork] INT NOT NULL,
    [IdStudents] INT NOT NULL,
    [IsChecked]  BIT DEFAULT ('0') NOT NULL,
    CONSTRAINT [StudentsHomeWorkes_fk0] FOREIGN KEY ([IdHomeWork]) REFERENCES [dbo].[HomeWorks] ([Id]),
    CONSTRAINT [StudentsHomeWorkes_fk1] FOREIGN KEY ([IdStudents]) REFERENCES [dbo].[Students] ([Id])
);

