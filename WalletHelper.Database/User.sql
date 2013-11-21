CREATE TABLE [dbo].[User] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [AspNetUser_Id] NVARCHAR (128) NOT NULL,
    [FirstName]     VARCHAR (50)   NOT NULL,
    [Surname]       VARCHAR (50)   NOT NULL,
    [BirthDate]     DATE           NOT NULL,
    [City_Id]       INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_AspNetUsers] FOREIGN KEY ([AspNetUser_Id]) REFERENCES [dbo].[AspNetUsers] ([Id])
);



GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AspNetUser]
    ON [dbo].[User]([AspNetUser_Id] ASC);

