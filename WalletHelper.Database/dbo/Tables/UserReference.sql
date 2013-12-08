CREATE TABLE [dbo].[UserReference] (
    [Id]               INT  IDENTITY (1, 1) NOT NULL,
    [UserReference_Id] INT  NOT NULL,
    [User_Id]          INT  NOT NULL,
    [Date]             DATE NOT NULL,
    CONSTRAINT [PK_UserReference] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserReference_ReferencedUser] FOREIGN KEY ([UserReference_Id]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_UserReference_SponsorUser] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[User] ([Id])
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserReference]
    ON [dbo].[UserReference]([UserReference_Id] ASC, [User_Id] ASC);

