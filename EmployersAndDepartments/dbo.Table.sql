CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(200) NOT NULL, 
    [lastName] NVARCHAR(200) NOT NULL, 
    [secondName] NVARCHAR(200) NOT NULL, 
    [age] INT NOT NULL, 
    [salary] INT NOT NULL, 
    [depId] INT NULL
)
