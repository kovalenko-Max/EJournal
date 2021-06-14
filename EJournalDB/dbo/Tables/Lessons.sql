CREATE TABLE [EJournal].[Lessons] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [IdGroup]    INT            NOT NULL,
    [DateLesson] DATETIME       NOT NULL,
    [Topic]      NVARCHAR (250) NULL,
    CONSTRAINT [PK_LESSONS] PRIMARY KEY CLUSTERED ([Id] ASC)
);

