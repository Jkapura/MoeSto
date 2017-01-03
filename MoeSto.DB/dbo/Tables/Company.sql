CREATE TABLE [dbo].[Company] (
    [Id]          INT           NOT NULL,
    [Name]        VARCHAR (50)  NOT NULL,
    [Address]     NVARCHAR (50) NULL,
    [Coordinates] NCHAR (10)    NOT NULL,
    CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED ([Id] ASC)
);

