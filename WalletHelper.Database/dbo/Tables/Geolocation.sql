CREATE TABLE [dbo].[Geolocation] (
    [Id]           INT               NOT NULL,
    [Geo]          [sys].[geography] NOT NULL,
    [LocationName] VARCHAR (100)     NULL,
    [Payment_Id]   INT               NOT NULL,
    CONSTRAINT [PK_Geolocation] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Geolocation_Payment] FOREIGN KEY ([Payment_Id]) REFERENCES [dbo].[Payment] ([Id])
);



