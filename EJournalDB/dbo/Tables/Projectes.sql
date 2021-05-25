﻿CREATE TABLE [dbo].[Projectes] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [IdProjectCroup] INT            NOT NULL,
    [Name]           NVARCHAR (50)  NOT NULL,
    [Description]    NVARCHAR (255) NOT NULL,
    [IsDelete]       BIT            CONSTRAINT [DF__Projects__IsDele__239E4DCF] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_PROJECTES] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Projectes_ProjectGroups_Id] FOREIGN KEY ([IdProjectCroup]) REFERENCES [dbo].[ProjectGroups] ([Id])
);
