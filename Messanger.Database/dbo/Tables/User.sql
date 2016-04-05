CREATE TABLE [dbo].[User] (
    [UserId]   INT           IDENTITY (1, 1) NOT NULL,
    [Login]    VARCHAR (50)  NOT NULL,
    [Password] VARCHAR (MAX) NOT NULL,
    [NickName] VARCHAR (50)  NOT NULL,
    [IsActive] BIT           NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

