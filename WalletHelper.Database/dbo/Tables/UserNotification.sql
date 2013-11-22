CREATE TABLE [dbo].[UserNotification] (
    [Id]                  INT IDENTITY (1, 1) NOT NULL,
    [DayHour]             INT NOT NULL,
    [Status]              INT NOT NULL,
    [NotificationType_Id] INT NOT NULL,
    [User_Id]             INT NOT NULL,
    CONSTRAINT [PK_UserNotification] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserNotification_NotificationType] FOREIGN KEY ([NotificationType_Id]) REFERENCES [dbo].[NotificationType] ([Id]),
    CONSTRAINT [FK_UserNotification_User] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[User] ([Id])
);

