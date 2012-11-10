CREATE TABLE [dbo].[Parameter]
(
	[APIDocId] UNIQUEIDENTIFIER NOT NULL , 
    [Type] TINYINT NOT NULL, 
    [Key] VARCHAR(32) NOT NULL, 
    [ParameterType] NCHAR(10) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Indispensable] BIT NOT NULL, 
    PRIMARY KEY ([Key], [APIDocId], [Type]), 
    CONSTRAINT [FK_Parameter_APIDoc] FOREIGN KEY ([APIDocId]) REFERENCES [APIDoc]([APIDocId]) 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'APIDocId',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Parameter',
    @level2type = N'COLUMN',
    @level2name = N'APIDocId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'类型(0:Request 1:Response)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Parameter',
    @level2type = N'COLUMN',
    @level2name = N'Type'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Key',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Parameter',
    @level2type = N'COLUMN',
    @level2name = N'Key'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'值的类型',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Parameter',
    @level2type = N'COLUMN',
    @level2name = N'ParameterType'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'描述',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Parameter',
    @level2type = N'COLUMN',
    @level2name = N'Description'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否需要授权',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Parameter',
    @level2type = N'COLUMN',
    @level2name = N'Indispensable'