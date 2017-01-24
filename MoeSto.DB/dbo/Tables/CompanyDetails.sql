CREATE TABLE [dbo].[CompanyDetails] (
    [Id]                    INT            NOT NULL,
    [Name]                  NVARCHAR (MAX) NOT NULL,
    [Unp]                   INT            NULL,
    [CatalogUrl]            NVARCHAR (MAX) NULL,
    [Address]               NVARCHAR (MAX) NULL,
    [Email]                 NVARCHAR (MAX) NULL,
    [Phones]                NVARCHAR (MAX) NULL,
    [FoundOnCardone]        BIT            NULL,
    [CardoneStatus]         NVARCHAR (MAX) NULL,
    [CardoneContractNo]     INT            NULL,
    [CardoneContractStatus] NVARCHAR (MAX) NULL,
    [Latitude]              FLOAT (53)     NOT NULL,
    [Longitude]             FLOAT (53)     NOT NULL,
    [MainImageId]           INT            NULL,
    [City]                  NVARCHAR (50)  NULL,
    CONSTRAINT [PK_CompanyDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CompanyDetails_Companies] FOREIGN KEY ([Id]) REFERENCES [dbo].[Companies] ([Id]),
    CONSTRAINT [FK_CompanyDetails_Images] FOREIGN KEY ([MainImageId]) REFERENCES [dbo].[Images] ([Id])
);



