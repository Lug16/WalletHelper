CREATE TABLE [dbo].[Hashtag] (
    [Id]      INT          IDENTITY (1, 1) NOT NULL,
    [Tag]     VARCHAR (50) NOT NULL,
    [User_Id] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Hashtag_User] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[User] ([Id])
);


