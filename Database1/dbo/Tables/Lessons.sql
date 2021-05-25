CREATE TABLE [dbo].[Lessons] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Topic]      NVARCHAR (250) NULL,
    [DateLesson] DATETIME       NOT NULL,
    [IdGroup]    INT            NOT NULL,
    [IdTeacher]  INT            NOT NULL,
    [IsDelete]   BIT            DEFAULT ('0') NOT NULL,
    CONSTRAINT [PK_LESSONS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Lessons_fk0] FOREIGN KEY ([IdGroup]) REFERENCES [dbo].[Groups] ([Id]),
    CONSTRAINT [Lessons_fk1] FOREIGN KEY ([IdTeacher]) REFERENCES [dbo].[Teachers] ([Id])
);

