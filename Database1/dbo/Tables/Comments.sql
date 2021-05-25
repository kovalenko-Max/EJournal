CREATE TABLE [dbo].[Comments] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Comment]       NVARCHAR (255) NOT NULL,
    [IdStudent]     INT            NOT NULL,
    [IdTeacher]     INT            NOT NULL,
    [IdCommentType] INT            NOT NULL,
    [IsDelete]      BIT            DEFAULT ('0') NOT NULL,
    CONSTRAINT [PK_COMMENTS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Comments_fk0] FOREIGN KEY ([IdStudent]) REFERENCES [dbo].[Students] ([Id]),
    CONSTRAINT [Comments_fk1] FOREIGN KEY ([IdTeacher]) REFERENCES [dbo].[Teachers] ([Id]),
    CONSTRAINT [Comments_fk2] FOREIGN KEY ([IdCommentType]) REFERENCES [dbo].[CommentTypes] ([Id])
);

