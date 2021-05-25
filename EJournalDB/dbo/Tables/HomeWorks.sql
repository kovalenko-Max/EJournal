CREATE TABLE [dbo].[HomeWorks] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [SRS]      NVARCHAR (255) NOT NULL,
    [Deadline] DATETIME       NULL,
    [IdGroup]  INT            NOT NULL,
    [IsDelete] BIT            DEFAULT ('0') NOT NULL,
    CONSTRAINT [PK_HOMEWORKES] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [HomeWorkes_fk0] FOREIGN KEY ([IdGroup]) REFERENCES [dbo].[Groups] ([Id])
);

