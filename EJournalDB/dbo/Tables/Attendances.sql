CREATE TABLE [dbo].[Attendances] (
    [IdLesson]   INT NOT NULL,
    [IdStudent]  INT NOT NULL,
    [IsPresence] BIT NOT NULL,
    CONSTRAINT [Attendances_Lessons_Id] FOREIGN KEY ([IdLesson]) REFERENCES [dbo].[Lessons] ([Id]),
    --CONSTRAINT [Attendances_Students_Id] FOREIGN KEY ([IdStudent]) REFERENCES [dbo].[Students] ([Id])
);

