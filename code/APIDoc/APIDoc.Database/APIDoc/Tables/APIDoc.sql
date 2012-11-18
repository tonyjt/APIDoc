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
