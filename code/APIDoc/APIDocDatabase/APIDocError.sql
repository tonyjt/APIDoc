CREATE TABLE [dbo].[APIDocErrorCode]
(
	[APIDocId] UNIQUEIDENTIFIER NOT NULL , 
    [ErrorCode] INT NOT NULL, 
    PRIMARY KEY ([ErrorCode], [APIDocId]), 
    CONSTRAINT [FK_APIDocErrorCode_APIDoc] FOREIGN KEY ([APIDocId]) REFERENCES [APIDoc]([APIDocId]), 
    CONSTRAINT [FK_APIDocErrorCode_ErrorCode] FOREIGN KEY ([ErrorCode]) REFERENCES [Error]([ErrorCode]) 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'错误代码',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'APIDocErrorCode',
    @level2type = N'COLUMN',
    @level2name = N'ErrorCode'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'API文档Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'APIDocErrorCode',
    @level2type = N'COLUMN',
    @level2name = 'APIDocId'