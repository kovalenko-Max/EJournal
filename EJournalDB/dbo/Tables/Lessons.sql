CREATE TABLE [dbo].[Lessons] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [IdGroup]    INT            NOT NULL,
    [DateLesson] DATETIME       NOT NULL,
    [Topic]      NVARCHAR (250) NULL,
    [IsDelete]   BIT            CONSTRAINT [DF__Lessons__IsDele__239E4DCF] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_LESSONS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Lessons_Groups_Id] FOREIGN KEY ([IdGroup]) REFERENCES [dbo].[Groups] ([Id]),
);

