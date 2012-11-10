CREATE TABLE [dbo].[APIDoc]
(
	[APIDocId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(128) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [CategoryId] UNIQUEIDENTIFIER NOT NULL, 
    [RequestUrl] NVARCHAR(128) NOT NULL, 
    [RequestType] TINYINT NOT NULL, 
    [NeedAuth] BIT NOT NULL, 
    [ActionTypes] VARCHAR(32) NOT NULL, 
    CONSTRAINT [FK_APIDoc_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([CategoryId])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Guid',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'APIDoc',
    @level2type = N'COLUMN',
    @level2name = N'APIDocId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'标题',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'APIDoc',
    @level2type = N'COLUMN',
    @level2name = N'Title'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'CategoryId',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'APIDoc',
    @level2type = N'COLUMN',
    @level2name = N'CategoryId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'描述',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'APIDoc',
    @level2type = N'COLUMN',
    @level2name = N'Description'