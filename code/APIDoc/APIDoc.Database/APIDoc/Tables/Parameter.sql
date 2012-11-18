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
