CREATE TABLE [dbo].[Capture] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [Image]      VARBINARY (MAX) NOT NULL,
    [Payment_Id] INT             NOT NULL,
    CONSTRAINT [PK_Capture] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Capture_Payment] FOREIGN KEY ([Payment_Id]) REFERENCES [dbo].[Payment] ([Id])
);

