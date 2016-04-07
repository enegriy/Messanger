CREATE TABLE [dbo].[User] (
    [UserId]   INT           IDENTITY (1, 1) NOT NULL,
    [Login]    VARCHAR (50)  NOT NULL,
    [Password] VARCHAR (MAX) NOT NULL,
    [NickName] VARCHAR (50)  NOT NULL,
    [IsActive] BIT           NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_User_NickName]
    ON [dbo].[User]([NickName] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_User_Login]
    ON [dbo].[User]([Login] ASC);

