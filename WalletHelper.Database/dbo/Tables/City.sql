CREATE TABLE [dbo].[City] (
    [Id]         INT          IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (50) NOT NULL,
    [Country_Id] VARCHAR (2)  NOT NULL,
    CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_City_Country] FOREIGN KEY ([Country_Id]) REFERENCES [dbo].[Country] ([Id])
);



