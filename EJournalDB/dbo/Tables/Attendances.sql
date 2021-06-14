CREATE TABLE [EJournal].[Attendances] (
    [IdLesson]   INT NOT NULL,
    [IdStudent]  INT NOT NULL,
    [IsPresence] BIT DEFAULT ((1)) NOT NULL,
    CONSTRAINT [Attendances_Lessons_Id] FOREIGN KEY ([IdLesson]) REFERENCES [EJournal].[Lessons] ([Id])
);

