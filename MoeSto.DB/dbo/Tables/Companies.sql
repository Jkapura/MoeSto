CREATE TABLE [dbo].[Companies] (
    [Id]        INT        IDENTITY (1, 1) NOT NULL,
    [Latitude]  FLOAT (53) NOT NULL,
    [Longitude] FLOAT (53) NOT NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED ([Id] ASC)
);



