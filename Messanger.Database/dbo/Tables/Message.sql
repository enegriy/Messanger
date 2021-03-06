﻿CREATE TABLE [dbo].[Message] (
    [MassageId]       INT           IDENTITY (1, 1) NOT NULL,
    [UserIdSender]    INT           NOT NULL,
    [UserIdRecipient] INT           NULL,
    [Text]            VARCHAR (MAX) NOT NULL,
    [SendDate]        DATETIME      NOT NULL,
    CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED ([MassageId] ASC),
    CONSTRAINT [FK_Message_User_Recip] FOREIGN KEY ([UserIdRecipient]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_Message_User_Send] FOREIGN KEY ([UserIdSender]) REFERENCES [dbo].[User] ([UserId]) ON DELETE CASCADE
);

