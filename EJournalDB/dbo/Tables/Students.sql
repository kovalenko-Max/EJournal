CREATE TABLE [dbo].[Students] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (100) NOT NULL,
    [Surname]         NVARCHAR (100) NOT NULL,
    [Email]           NVARCHAR (100) NOT NULL,
    [Phone]           NVARCHAR (16)  NOT NULL,
    [Git]             NVARCHAR (100) NULL,
    [City]            NVARCHAR (MAX) NULL,
    [Ranking]         INT            NULL,
    [AgreementNumber] NVARCHAR (50)  NOT NULL,
    [IsDelete]        BIT            NOT NULL,
    CONSTRAINT [PK_STUDENTS] PRIMARY KEY CLUSTERED ([Id] ASC)
);

