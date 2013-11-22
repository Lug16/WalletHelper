CREATE TABLE [dbo].[NotificationType] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Description] VARCHAR (140) NOT NULL,
    CONSTRAINT [PK_NotificationType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

