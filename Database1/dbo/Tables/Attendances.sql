CREATE TABLE [dbo].[Attendances] (
    [IdLesson]   INT NOT NULL,
    [IdStudent]  INT NOT NULL,
    [IsPresence] BIT NOT NULL,
    CONSTRAINT [Attendances_fk0] FOREIGN KEY ([IdLesson]) REFERENCES [dbo].[Lessons] ([Id]),
    CONSTRAINT [Attendances_fk1] FOREIGN KEY ([IdStudent]) REFERENCES [dbo].[Students] ([Id])
);

