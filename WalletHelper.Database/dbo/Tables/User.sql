CREATE TABLE [dbo].[User] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [AspNetUser_Id]     NVARCHAR (128) NOT NULL,
    [FirstName]         VARCHAR (50)   NOT NULL,
    [Surname]           VARCHAR (50)   NOT NULL,
    [BirthDate]         DATE           NOT NULL,
    [CreationDate]      DATE           NOT NULL,
    [LastSessionDate]   DATE           NULL,
    [LastDeviceUsed_Id] INT            NOT NULL,
    [City_Id]           INT            NOT NULL,
    [Status_Id]         INT            NOT NULL,
    CONSTRAINT [PK__User__3214EC0744275468] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_AspNetUsers] FOREIGN KEY ([AspNetUser_Id]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_User_City] FOREIGN KEY ([City_Id]) REFERENCES [dbo].[City] ([Id]),
    CONSTRAINT [FK_User_Status] FOREIGN KEY ([Status_Id]) REFERENCES [dbo].[Status] ([Id]) 
);





GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AspNetUser]
    ON [dbo].[User]([AspNetUser_Id] ASC);

