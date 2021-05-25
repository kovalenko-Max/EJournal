CREATE TABLE [dbo].[Exercises] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [IdGroup]     INT            NOT NULL,
    [Description] NVARCHAR (255) NOT NULL,
    [Deadline]     DATETIME       NULL,
    [IsDelete]    BIT            CONSTRAINT [DF__Exercises__IsDele__239E4DCF] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_EXERCISES] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Exercises_Groups_Id] FOREIGN KEY ([IdGroup]) REFERENCES [dbo].[Groups] ([Id])
);

