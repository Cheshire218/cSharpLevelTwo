CREATE TABLE [dbo].[Emp] (
    [Id]         INT            NOT NULL,
    [name]       NVARCHAR (200) NOT NULL,
    [lastName]   NVARCHAR (200) NOT NULL,
    [secondName] NVARCHAR (200) NOT NULL,
    [age]        INT            NOT NULL,
    [salary]     INT            NOT NULL,
    [depId]      INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Table_ToDepartments] FOREIGN KEY ([depId]) REFERENCES [dbo].[Departments] ([Id])
);

