CREATE TABLE [dbo].[User] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [UserName]     NVARCHAR (MAX) NOT NULL,
    [DateOfBirth]  DATETIME       NULL,
    [JoinDate]     DATETIME       NOT NULL,
    [LastActivity] DATETIME       NOT NULL,
    [Location]     NVARCHAR (MAX) NULL,
    [IsOnline]     BIT            NOT NULL,
    CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

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
    [CategoryId]  INT            NULL,
    CONSTRAINT [PK_dbo.Topic] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Topic_dbo.Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_CategoryId]
    ON [dbo].[Topic]([CategoryId] ASC);

CREATE TABLE [dbo].[Post] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [CreatorId]   INT            NOT NULL,
    [TopicId]     INT            NULL,
    CONSTRAINT [PK_dbo.Post] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Post_dbo.User_CreatorId] FOREIGN KEY ([CreatorId]) REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Post_dbo.Topic_TopicId] FOREIGN KEY ([TopicId]) REFERENCES [dbo].[Topic] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_CreatorId]
    ON [dbo].[Post]([CreatorId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TopicId]
    ON [dbo].[Post]([TopicId] ASC);

CREATE TABLE [dbo].[Message] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [WrittenTime] DATETIME       NOT NULL,
    [IsSubject]   BIT            NOT NULL,
    [Content]     NVARCHAR (MAX) NOT NULL,
    [WriterId]    INT            NOT NULL,
    [PostId]      INT            NOT NULL,
    CONSTRAINT [PK_dbo.Message] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Message_dbo.User_WriterId] FOREIGN KEY ([WriterId]) REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Message_dbo.Post_PostId] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Post] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_WriterId]
    ON [dbo].[Message]([WriterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PostId]
    ON [dbo].[Message]([PostId] ASC);

