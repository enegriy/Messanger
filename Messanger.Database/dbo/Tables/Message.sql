CREATE TABLE [dbo].[Message] (
    [MassageId]       INT           NOT NULL,
    [UserIdSender]    INT           NOT NULL,
    [UserIdRecipient] INT           NULL,
    [Text]            VARCHAR (MAX) NOT NULL,
    [SendDate]        DATETIME      NOT NULL,
    CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED ([MassageId] ASC),
    CONSTRAINT [FK_Message_User_Recipient] FOREIGN KEY ([UserIdRecipient]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_Message_User_Sender] FOREIGN KEY ([UserIdSender]) REFERENCES [dbo].[User] ([UserId])
);

