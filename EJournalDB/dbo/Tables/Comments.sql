﻿CREATE TABLE [dbo].[Comments] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Comment]       NVARCHAR (255) NOT NULL,
    [IdCommentType] INT            NOT NULL,
    [IsDelete]      BIT            CONSTRAINT [DF__Comments__IsDele__239E4DCF] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_COMMENTS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Comments_CommentTypes_Id] FOREIGN KEY ([IdCommentType]) REFERENCES [dbo].[CommentTypes] ([Id]),
);

