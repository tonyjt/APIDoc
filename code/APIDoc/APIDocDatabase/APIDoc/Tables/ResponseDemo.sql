CREATE TABLE [dbo].[ResponseDemo]
(
	[APIDocId] UNIQUEIDENTIFIER NOT NULL , 
    [ResponseType] TINYINT NOT NULL, 
    [Demo] NVARCHAR(MAX) NOT NULL, 
    PRIMARY KEY ([APIDocId], [ResponseType]), 
    CONSTRAINT [FK_ResponseDemo_APIDoc] FOREIGN KEY ([APIDocId]) REFERENCES [APIDoc]([APIDocId])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'实例',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ResponseDemo',
    @level2type = N'COLUMN',
    @level2name = N'Demo'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'相应类型(xml/json)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ResponseDemo',
    @level2type = N'COLUMN',
    @level2name = N'ResponseType'