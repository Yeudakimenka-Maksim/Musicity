CREATE TABLE [dbo].[Role] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.Role] PRIMARY KEY CLUSTERED ([Id] ASC)
);

SET IDENTITY_INSERT [dbo].[Role] ON
INSERT INTO [dbo].[Role] ([Id], [Name]) VALUES (1, N'Admin')
INSERT INTO [dbo].[Role] ([Id], [Name]) VALUES (2, N'User')
INSERT INTO [dbo].[Role] ([Id], [Name]) VALUES (3, N'Anonym')
SET IDENTITY_INSERT [dbo].[Role] OFF

CREATE TABLE [dbo].[User] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NOT NULL,
    [Password]     NVARCHAR (MAX) NOT NULL,
    [DateOfBirth]  DATETIME       NULL,
    [JoinDate]     DATETIME       NOT NULL,
    [LastActivity] DATETIME       NOT NULL,
    [Location]     NVARCHAR (MAX) NULL,
    [IsOnline]     BIT            NOT NULL,
    [RoleId]       INT            NOT NULL,
    CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.User_dbo.Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_RoleId]
    ON [dbo].[User]([RoleId] ASC);

SET IDENTITY_INSERT [dbo].[User] ON
INSERT INTO [dbo].[User] ([Id], [Name], [Password], [DateOfBirth], [JoinDate], [LastActivity], [Location], [IsOnline], [RoleId]) VALUES (1, N'Maxim', N'123', NULL, N'2014-12-29 00:00:00', N'2014-12-29 00:00:00', NULL, 0, 2)
INSERT INTO [dbo].[User] ([Id], [Name], [Password], [DateOfBirth], [JoinDate], [LastActivity], [Location], [IsOnline], [RoleId]) VALUES (2, N'Admin', N'123', NULL, N'2014-12-29 00:00:00', N'2014-12-29 00:00:00', NULL, 0, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
	
CREATE TABLE [dbo].[Category] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Category] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Topic] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Category_Id] INT            NULL,
    CONSTRAINT [PK_dbo.Topic] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Topic_dbo.Category_Category_Id] FOREIGN KEY ([Category_Id]) REFERENCES [dbo].[Category] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Category_Id]
    ON [dbo].[Topic]([Category_Id] ASC);

CREATE TABLE [dbo].[Post] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [CreatorId]   INT            NOT NULL,
    [Topic_Id]    INT            NULL,
    CONSTRAINT [PK_dbo.Post] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Post_dbo.User_CreatorId] FOREIGN KEY ([CreatorId]) REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Post_dbo.Topic_Topic_Id] FOREIGN KEY ([Topic_Id]) REFERENCES [dbo].[Topic] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_CreatorId]
    ON [dbo].[Post]([CreatorId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Topic_Id]
    ON [dbo].[Post]([Topic_Id] ASC);

CREATE TABLE [dbo].[Message] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [WrittenTime] DATETIME       NOT NULL,
    [IsSubject]   BIT            NOT NULL,
    [Content]     NVARCHAR (MAX) NOT NULL,
    [WriterId]    INT            NOT NULL,
    [Post_Id]     INT            NULL,
    CONSTRAINT [PK_dbo.Message] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Message_dbo.User_WriterId] FOREIGN KEY ([WriterId]) REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Message_dbo.Post_Post_Id] FOREIGN KEY ([Post_Id]) REFERENCES [dbo].[Post] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_WriterId]
    ON [dbo].[Message]([WriterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Post_Id]
    ON [dbo].[Message]([Post_Id] ASC);

