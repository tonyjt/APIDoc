CREATE TABLE [dbo].[Error]
(
	[ErrorCode] INT NOT NULL PRIMARY KEY, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Message] NVARCHAR(256) NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'描述',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Error',
    @level2type = N'COLUMN',
    @level2name = N'Description'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'错误信息',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Error',
    @level2type = N'COLUMN',
    @level2name = N'Message'